import { Keep } from "./Keep.js"

export class KeptKeep extends Keep {
  constructor(data) {
    super(data)
    this.vaultKeepId = data.vaultKeepId | 0
    this.keepId = data.keepId | 0
    this.vaultId = data.vaultId | 0
  }
}

// const VaultKeepObjData = {
//   "vaultKeepId": 1,
//   "keepId": 19,
//   "vaultId": 15,
//   "name": "One of a Kind",
//   "description": "A wilderness of the children is assumed to be a fictile wholesaler.",
//   "img": "https://images.unsplash.com/photo-1514888286974-6c03e2ca1dba?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=638&h=503&q=60",
//   "views": 0,
//   "creatorId": "65e9fb59e1423c341b6d36f6",
//   "creator": {
//       "name": "goodboi@nice.com",
//       "picture": "https://s.gravatar.com/avatar/217c84279b9299595edf3727755a2c54?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fgo.png",
//       "coverImg": "https://images.unsplash.com/34/BA1yLjNnQCI1yisIZGEi_2013-07-16_1922_IMG_9873.jpg?q=80&w=3871&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
//       "id": "65e9fb59e1423c341b6d36f6",
//       "createdAt": "2024-03-26T21:05:58",
//       "updatedAt": "2024-03-26T21:05:58"
//   },
//   "kept": 0,
//   "id": 19,
//   "createdAt": "2024-04-10T17:22:22",
//   "updatedAt": "2024-04-10T17:22:22"
// }