import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  // @ts-ignore
  account: {},
  /** @type {import('./models/Profile.js').Profile | null} */
  activeProfile: null,
  /** @type {import('./models/Keep.js').Keep[]} */
  profileKeeps: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: [], //profile Vaults
  /** @type {import('./models/Vault.js').Vault[]} */
  myVaults: [], //logged in user's Vaults
  /** @type {import('./models/Vault.js').Vault | null} */
  activeVault: null,
  /** @type {import('./models/KeptKeep.js').KeptKeep[]} */
  vaultKeeps: [],
  /** @type Number */
  activeVaultKeepId: 0,
})
