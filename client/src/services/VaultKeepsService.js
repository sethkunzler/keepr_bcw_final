import { AppState } from "../AppState.js";
import { KeptKeep } from "../models/KeptKeep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultKeepsService { 
  async AddKeepToVaultById(data)
  {
    await api.post('api/vaultKeeps', data)
    AppState.activeKeep.kept ++
  }
  async getKeepsByVaultId(vaultId) {
    AppState.vaultKeeps = []
    const res = await api.get(`api/vaults/${vaultId}/keeps`);
    logger.log('The vaults keeps returned from the api', res);
    const keeps = res.data.map(pojo => new KeptKeep(pojo));
    AppState.vaultKeeps = keeps
  }

  setActiveVaultKeepId(vaultKeepId) {
    AppState.activeVaultKeepId = vaultKeepId
  }

  async removeKeepFromVault(keepId, vaultKeepId) {
    const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    logger.log('deleted keep', res.data)

    const keepIndex = AppState.vaultKeeps.findIndex(keep => keep.id == keepId)
    if (keepIndex == -1) throw new Error("Please contact tech support for help. Could not find the correct index. Found vault keep -1")
    AppState.vaultKeeps.splice(keepIndex, 1)
    AppState.activeVaultKeepId = 0
    AppState.activeKeep = null
  }

}
export const vaultKeepsService = new VaultKeepsService();