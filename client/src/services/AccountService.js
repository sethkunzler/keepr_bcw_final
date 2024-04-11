import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Profile } from "../models/Profile.js"
import { Vault } from "../models/Vault.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getProfile(profileId) {
    try {
      const res = await api.get(`api/profiles/${profileId}`)
      const foundProfile = res.data
      return foundProfile
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async setActiveProfile(profileId) {
    const selectedProfile = await this.getProfile(profileId)
    AppState.activeProfile = new Profile(selectedProfile)
  } 
  async getMyVaults() {
    try {
      const res = await api.get('/account/vaults')
      const myVaults = res.data.map(pojo => new Vault(pojo))
      AppState.myVaults = myVaults
    } catch (error) {
      logger.error('Have you started your server yet', error)
    }
  }
}

export const accountService = new AccountService()
