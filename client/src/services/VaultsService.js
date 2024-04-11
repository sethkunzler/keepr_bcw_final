import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {
  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('Created Vault', res.data)
    const newVault = new Vault(res.data)
    // TODO make reactive
    return newVault
  }
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
    AppState.activeVault = null
    const newVault = await this.getVaultById(vaultId)
    AppState.activeVault = newVault
    // logger.log('This is the Active Vault in the App State', AppState.activeVault)
  }
  async deleteVault(vaultId) {
    const res = await api.delete(`api/vaults/${vaultId}`)
    logger.log('deleted vault', res.data)

    const vaultIndex = AppState.vaults.findIndex(vault => vault.id == vaultId)
    if (vaultIndex == -1) throw new Error("Please contact tech support for help. Could not find the correct index. Found vault -1")
    AppState.vaults.splice(vaultIndex, 1)
    AppState.activeVault = null
  }
}

export const vaultsService = new VaultsService()