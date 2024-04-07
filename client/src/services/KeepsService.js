import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {
  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    // logger.log('Created Keep', res.data)
    const newKeep = new Keep(res.data)
    AppState.keeps.push(newKeep)
    return newKeep

  }
  async getKeeps() {
    const res = await api.get("api/keeps")
    // logger.log("these are all the keeps returned from the api", res.data)
    const newKeeps = res.data.map(pojo => new Keep(pojo))
    AppState.keeps = newKeeps
    // logger.log("Keeps in my AppState", AppState.keeps)
  }
  async getKeepById(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    logger.log("Found this keep", res.data)
    const foundKeep = new Keep(res.data)
    return foundKeep
  }
  async setActiveKeep(keepId) {
    AppState.activeKeep = {}
    const newKeep = await this.getKeepById(keepId)
    AppState.activeKeep = newKeep
  }
}

export const keepsService = new KeepsService()