<template>
  <div v-if="vault">
    <div class="text-center">
      <img class="img-fluid" :src="vault.img" :alt="vault.name">
    </div>
    <div class="p-2">
      <h1 class="text-center">This is the {{ vault.name }} Vault Page</h1>
      <div v-if="account.id == vault.creatorId" class="text-end">
        <button  @click="deleteVault(vault.id)" class="btn btn-danger">DELETE THE VAULT</button>
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { AppState } from "../AppState.js";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";

export default {
setup(){
  const route = useRoute();
  const router = useRouter();
  async function setActiveVault() {
    try {
      const vaultId = route.params.vaultId;
      await vaultsService.setActiveVault(vaultId);
    }
    catch (error){
      Pop.error(error);
      if (error.response.data.includes('😉🤚❌')){
        router.push({ name: 'Home' })
      }
    }
  } 
  onMounted(() => {
    setActiveVault(); 
  })
  return{
    vault: computed(() => AppState.activeVault),
    account: computed(() => AppState.account),

    async deleteVault(vaultId) {
      try {
        const yes = await Pop.confirm()
        if (!yes) return
        const positive = await Pop.confirm("Are you actually Sure THOuGh? This could be gone fOREevEr!")
        if(!positive) return
        await vaultsService.deleteVault(vaultId)
        router.push({ name: 'Home' })
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