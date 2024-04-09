<template>
  <div v-if="vault">
    <h1>This is the {{ vault.name }} Vault Page</h1>
  </div>
</template>


<script>
import { computed, onMounted } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";

export default {
setup(){
  const route = useRoute();
  async function setActiveVault() {
    try {
      const vaultId = route.params.vaultId;
      await vaultsService.setActiveVault(vaultId);
    }
    catch (error){
      Pop.error(error);
    }
  } 
  onMounted(() => {
    setActiveVault(); 
  })
  return{
    vault: computed(() => AppState.activeVault)
  }
}
}
</script>


<style lang="scss" scoped>

</style>