import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {
  async getVaultsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    // logger.log("These are all the vaults returned for the profile ID", res.data)
    const newVaults = res.data.map(pojo => new Vault(pojo))
    AppState.vaults = newVaults
    logger.log('These are the Vaults in the App State', AppState.vaults)
  } 

  async getVaultById(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    const foundVault = new Vault(res.data)
    return foundVault
  }
  async setActiveVault(vaultId) {
    AppState.activeVault = {}
    const newVault = await this.getVaultById(vaultId)
    AppState.activeVault = newVault
    logger.log('This is the Active Vault in the App State', AppState.activeVault)
  }
}

export const vaultsService = new VaultsService()