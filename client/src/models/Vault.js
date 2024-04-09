import { DatabaseItem } from "./DatabaseItem.js";

export class Vault extends DatabaseItem {
  constructor(data) {
    super(data)
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.creatorId = data.creatorId
    this.isPrivate = data.isPrivate
    this.creator = data.creator
  }
}

// const vaultData = {
//   "name": "My Favorite stuff",
//   "description": "Cool Cool Cool",
//   "img": "https://images.unsplash.com/photo-1556912173-3bb406ef7e77?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&h=400&q=60",
//   "creatorId": "65e9ef031cc276335a76f00f",
//   "isPrivate": false,
//   "creator": {
//       "name": "badboi@naughty.gov",
//       "picture": "https://s.gravatar.com/avatar/2ef5ed6808163c2b71e6c17c6a6e8d62?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fba.png",
//       "coverImg": "https://images.unsplash.com/34/BA1yLjNnQCI1yisIZGEi_2013-07-16_1922_IMG_9873.jpg?q=80&w=3871&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
//       "id": "65e9ef031cc276335a76f00f",
//       "createdAt": "2024-04-06T18:57:28",
//       "updatedAt": "2024-04-06T18:57:28"
//   },
//   "id": 5,
//   "createdAt": "2024-04-09T01:58:57",
//   "updatedAt": "2024-04-09T01:58:57"
// }