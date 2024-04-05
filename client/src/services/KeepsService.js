import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get("api/keeps")
    logger.log("these are all the keeps returned from the api", res.data)
    const newKeeps = res.data.map(pojo => new Keep(pojo))
    AppState.keeps = newKeeps
    logger.log("Keeps in my AppState", AppState.keeps)
  }
}

export const keepsService = new KeepsService()