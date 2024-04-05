import { DatabaseItem } from "./DatabaseItem.js";

export class Keep extends DatabaseItem {
  constructor(data) {
    super(data)
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.views = data.views
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.kept = data.kept
  }
}

// const objectData = {
//   "name": "Makes you Wonder",
//   "description": "Nowhere is it disputed that the tricksome yarn comes from a tender back. The styleless geometry reveals itself as an undealt europe to those who look. A zone is the sidewalk of a pizza. If this was somewhat unclear, the first undrawn manager is, in its own way, a call.",
//   "img": "https://images.unsplash.com/photo-1470770903676-69b98201ea1c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=651&h=454&q=60",
//   "views": 0,
//   "creatorId": "65e9fb59e1423c341b6d36f6",
//   "creator": {
//       "name": "goodboi@nice.com",
//       "picture": "https://s.gravatar.com/avatar/217c84279b9299595edf3727755a2c54?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fgo.png",
//       "id": "65e9fb59e1423c341b6d36f6",
//       "createdAt": "2024-03-26T21:05:58",
//       "updatedAt": "2024-03-26T21:05:58"
//   },
//   "kept": 0,
//   "id": 1,
//   "createdAt": "2024-04-05T21:41:20",
//   "updatedAt": "2024-04-05T21:41:20"
// }