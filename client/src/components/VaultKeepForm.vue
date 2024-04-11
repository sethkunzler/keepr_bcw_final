<template>
  <form v-if="keepId" @submit.prevent="AddToVault">
    <select v-model="editableData.vaultId" class="form-select" aria-label="Select Vault">
      <option disabled>Choose a Vault</option>
      <option v-for="vault in vaults" :value="vault.id">{{ vault.name }}</option>
    </select>
    <button type="submit" class="selectable border text-decoration-none text-end my-2 mx-3">Save</button>
  </form>
</template>


<script>
import { computed, onMounted, ref } from 'vue'
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import { accountService } from "../services/AccountService.js";
import { logger } from "../utils/Logger.js";

export default {
  props: {
    keepId: {
      type: Number,
      required: true
    }
  },
  setup(props){
    const editableData = ref({ vaultId: 0, keepId: 0})
    onMounted(getMyVaults)
    async function getMyVaults() {
      await accountService.getMyVaults();
    }
    return{
      props,
      editableData,
      vaults: computed(() => AppState.myVaults),
      
      async AddToVault() {
        try {
          editableData.value.keepId = props.keepId 
          logger.log(editableData.value)
          await vaultKeepsService.AddKeepToVaultById(editableData.value)
          Pop.success(`This Keep was successfully saved`)
          editableData.value = {vaultId: 0, keepId: 0}
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