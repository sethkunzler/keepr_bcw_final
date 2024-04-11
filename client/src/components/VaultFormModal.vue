<template>
  <!-- Modal -->
    <div class="modal fade" id="vaultFormModal" aria-labelledby="vaultFormModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-scrollable">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="vaultFormModalLabel">Create a New Vault</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createVault">
              <!-- Name description img -->
              <div class="form-floating my-2">
                <input v-model="editableData.name" type="text" class="form-control" id="name" placeholder="Name" minlength="2" maxlength="25" required>
                <label for="name">Name</label>
              </div>
              <div class="form-floating my-2">
                <input v-model="editableData.img" type="url" class="form-control" id="img" placeholder="https://..." maxlength="1000" required>
                <label for="img">Image Link</label>
              </div>
              <div class="form-floating my-2">
                <textarea v-model="editableData.description" class="form-control" placeholder="Write the description here" id="description" style="height: 100px" maxlength="1000" required></textarea>
                <label for="description">Description</label>  
              </div>
              <!-- TODO isPrivate -->
              <!-- <div class="p-3 my-3 border rounded">
                <div>
                  <span class="italic">Private vaults can only be seen by you</span>
                </div>
                <div class="form-check form-switch">
                  <input v-model="editableData.isPrivate" class="form-check-input mt-2" type="checkbox" role="switch" id="isPrivate">
                  <label class="form-check-label fs-5" for="isPrivate">Make Vault Private?</label>
                </div>
              </div> -->
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" maxlength="500" required>Close</button>
                <button type="submit" class="btn btn-primary">Submit</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  
  <script>
  import { ref } from 'vue'
  import Pop from '../utils/Pop.js'
  import { Modal } from 'bootstrap'
  import { vaultsService } from '../services/VaultsService.js'
  export default {
    setup(){
      const editableData = ref({ name: '', description: '', img: ''})
      return{
        editableData,
        async createVault() {
          try {
            const vault = await vaultsService.createVault(editableData.value)
            // editableData.value = ref({ name: '', description: '', img: '', isPrivate: false})
            Modal.getOrCreateInstance('#vaultFormModal').hide()
            Pop.success(`${vault.name} has been created`)
          }
          catch (error){
            Pop.error(error);
          }
        }
      }
    }
  }
  </script>
  
  
  <style lang="scss" scoped>
  
  </style>