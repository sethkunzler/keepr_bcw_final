<template>
<!-- Modal -->
<div class="modal fade" id="editAccountModal" tabindex="-1" aria-labelledby="editAccountModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="editAccountModalLabel">Modal title</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <!-- TODO Edit Name, img and coverImg -->
        <form @submit.prevent="updateAccount">
          <div class="form-floating my-2">
            <input v-model="editableData.name" type="text" class="form-control" id="name" placeholder="Display Name">
            <label for="name">Profile Name</label>
          </div>
          <div class="form-floating my-2">
            <input v-model="editableData.picture" type="url" class="form-control" id="picture" placeholder="https://">
            <label for="picture">Profile Picture</label>
          </div>
          <div class="form-floating my-2">
            <input v-model="editableData.coverImg" type="url" class="form-control" id="coverImg" placeholder="https://">
            <label for="coverImg">Cover Image</label>
          </div>
          <div class="modal-footer mt-3">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="submit" class="btn btn-primary">Save changes</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</div>
</template>


<script>
import {computed, ref, watch} from "vue"
import { AppState } from "../AppState.js"
import Pop from "../utils/Pop.js"
import { accountService } from "../services/AccountService.js"
export default {
setup(){
  const account = computed(() => AppState.account)
  const editableData = ref({})
  watch(account, () => { editableData.value = { ...account.value } }, { immediate: true })
  return{
    editableData,
    async updateAccount() {
      try {
        await accountService.updateAccount(editableData.value)
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