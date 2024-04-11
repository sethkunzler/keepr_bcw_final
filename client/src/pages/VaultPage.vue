<template>
  <div v-if="vault != null">
    <div class="banner-container text-center bg-success bg-opacity-50">
      <img class=" banner img-fluid rounded shadow-inset" :src="vault.img" :alt="vault.name">
    </div>
    <div class="p-2 rounded shadow">
      <h1 class="text-center">This is the {{ vault.name }} Vault Page</h1>
      <div class="text-center px-5 mx-4">
        <span class="text-center italic">Vault by <router-link :to="{ name: 'Profile', params: {profileId: vault.creatorId }}" class="text-success bold"> {{ vault.creator.name }} </router-link></span>
        <div class="my-2 p-1 bg-success bg-opacity-25 shadow-sm rounded border"></div>
      </div>
      <div class="d-flex justify-content-center align-items-center my-2 px-2">
        <h2 class="text-center mx-3 border p-2 rounded shadow">{{ keeps.length }}  Keeps</h2>
        <div>
          <div class="p-1">
            <h6>About:</h6>
            <h4>{{ vault.description }}</h4>
          </div>
        </div>
      </div>
      <div v-if="account.id == vault.creatorId" class="d-flex justify-content-around align-items-center">
        <div class="user-select-none">
          <span class="mdi py-2 px-3 rounded fs-5 text-light text-shadow" 
          :class="vault.isPrivate == true ? 'mdi-lock bg-danger' : 'mdi-lock-open bg-success' " 
          :title="vault.isPrivate == true ? 'vault is private' : 'vault is public' "></span>
        </div>
        <div></div>
        <button  @click="deleteVault(vault.id, vault.creatorId)" class="btn btn-danger">
          <span class="mdi mdi-trash-can fs-5"></span>
        </button>
      </div>
    </div>
    <div v-if="keeps.length > 0">
      <div class="container my-3">
        <section class="row">
          <div class="col-12">
            <h3>Keeps</h3>
          </div>
          <div v-for="keep in keeps" :key="keep.id" class="col-6">
            <KeepSimpleCard :keep="keep" :vaultKeepId="keep.vaultKeepId" />
          </div>
        </section>
      </div>
    </div>
    <div v-else class="my-5 py-5">
      <h2 class="text-center"> There are no Keeps here yet <router-link :to="{ name: 'Home'}">Click to browse keeps.</router-link></h2>
    </div>
  </div>

</template>


<script>
import { computed, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { AppState } from "../AppState.js";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";
import KeepSimpleCard from "../components/KeepSimpleCard.vue";
import { vaultKeepsService } from "../services/VaultKeepsService.js";

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
        router.push({ name: 'Home', })
      }
    }
  }
  async function getKeepsByVaultId() {
    try {
      const vaultId = route.params.vaultId;
      await vaultKeepsService.getKeepsByVaultId(vaultId);
    }
    catch (error){
      Pop.error(error);
    }
  }
  onMounted(() => {
    setActiveVault(); 
    getKeepsByVaultId();
  })
  return{
    vault: computed(() => AppState.activeVault),
    account: computed(() => AppState.account),
    keeps: computed(() => AppState.vaultKeeps),

    async deleteVault(vaultId, profileId) {
      try {
        const yes = await Pop.confirm()
        if (!yes) return
        const positive = await Pop.confirm("Are you actually Sure THOuGh? This could be gone fOREevEr!")
        if(!positive) return
        await vaultsService.deleteVault(vaultId)
        router.push({ name: 'Profile', params: {profileId: profileId} })
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
.shadow-inset{
  box-shadow: rgba(0, 0, 0, 0.17) 0px -23px 25px 0px inset, rgba(0, 0, 0, 0.15) 0px -36px 30px 0px inset, rgba(0, 0, 0, 0.1) 0px -79px 40px 0px inset, rgba(0, 0, 0, 0.06) 0px 2px 1px, rgba(0, 0, 0, 0.09) 0px 4px 2px, rgba(0, 0, 0, 0.09) 0px 8px 4px, rgba(0, 0, 0, 0.09) 0px 16px 8px, rgba(0, 0, 0, 0.09) 0px 32px 16px;
}
.shadow-pop {
  box-shadow: rgba(0, 0, 0, 0.2) 0px 12px 28px 0px, rgba(0, 0, 0, 0.1) 0px 2px 4px 0px, rgba(255, 255, 255, 0.05) 0px 0px 0px 1px inset;
}
</style>