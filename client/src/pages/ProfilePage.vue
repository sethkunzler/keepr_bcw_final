<template>
  <div v-if="profile != null">
    <div class="banner-container text-center" :style="{ backgroundImage: `url(${profile.coverImg})` }">
      <img class="banner img-fluid" :src="profile.coverImg" alt="Cover Image">
    </div>

    <div class="container">
      <section class="row">
        <div class="col-12">
          <h4 class="text-center italic">Welcome to <span class="text-capitalize">{{ profile.name }}</span>'s Keeper Profile</h4>
        </div>
      </section>

      <section class="row my-2 justify-content-center">
        <div class="col-md-10 d-flex justify-content-center text-center border rounded shadow">
          <div class="container-fluid">
            <div class="row my-3">
              <div class="col-md-5">
                <img class="img-fluid profile-img my-2 border border-success" :src="profile.picture" :alt="profile.name" :title="profile.name">
              </div>
              <div class="col-md-7">
                <div class="text-center">
                  <h2 class="text-capitalize">{{ profile.name }}</h2>
                  <!-- TODO display the length of these two counts -->
                  <h4 v-if="vaults"> {{ vaults.length }} Vaults |  26 Keeps</h4>
                  <h6 class="italic">Keeper since: <span class="bold">{{ profile.createdAt.toLocaleDateString() }}</span></h6>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section class="row justify-content-center">
        <div class="col-md-12">
          <h2>Vaults</h2>
        </div>
        <div v-for="vault in vaults" class="col-md-3 my-2">
          <router-link :to="{ name: 'Vault', params: { vaultId: vault.id} }">
            <div class="text-center">
              <img class="img-fluid vault-img rounded" :src="vault.img" alt="">
            </div>
          </router-link>
        </div>

        <!-- filler -->
        <div v-if="!vaults" class="col-md-6">
          <div class="img-filler-sm"></div>
        </div>
        <div v-if="!vaults" class="col-md-6">
          <div class="img-filler-sm"></div>
        </div>
      </section>

      <section class="row">
        <div class="col-md-12">
          <h2>Keeps</h2>
        </div>
        <div class="col-md-4">
          <div class="img-filler-sm"></div>
        </div>
      </section>
    </div>
  </div>
  

</template>


<script>
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { useRoute } from "vue-router";
import { accountService } from "../services/AccountService.js";
import { vaultsService } from "../services/VaultsService.js";


export default {
setup(){
  const route = useRoute();
  async function getProfileById() {
    try {
      const profileId = route.params.profileId;
      await accountService.setActiveProfile(profileId);
    }
    catch (error){
      Pop.error(error);
    }
  }
  async function getVaultsByCreatorId() {
    try {
      const profileId = route.params.profileId;
      await vaultsService.getVaultsByProfileId(profileId);
    }
    catch (error){
      Pop.error(error);
    }
  }
  onMounted(() => {
    getProfileById();
    // TODO
    getVaultsByCreatorId(); 
    // getKeepsByCreatorId();
  })
  return{
    profile: computed(() => AppState.activeProfile),
    vaults: computed(() => AppState.vaults)
  }
}
}
</script>


<style lang="scss" scoped>
.vault-img {
  max-height: 40dvh;
  object-fit: cover;
}
</style>