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
                  <h5 class="italic">member since: <span class="bold">{{ profile.createdAt.toLocaleDateString() }}</span></h5>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <section class="row">
        <div class="col-md-12">
          <h2>Vaults</h2>
        </div>
        <div class="col-3">
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
  <div v-else>
    <div class="banner-container text-center" :style="{ backgroundImage: `url('https://images.unsplash.com/photo-1506765515384-028b60a970df?q=80&w=3869&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')` }">
      <img src="https://images.unsplash.com/photo-1506765515384-028b60a970df?q=80&w=3869&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="filler-img">
    </div>
    <div class="container-fluid">
      <section class="row">
        <div class="col-12">
          <h1>Welcome</h1>
        </div>
      </section>
      <section class="row">
        <div class="col-md-12">
          <h2>Vaults</h2>
        </div>
        <div class="col-3">
          <div class="img-filler"></div>
        </div>
        <div class="col-3">
          <div class="img-filler"></div>
        </div>
        <div class="col-3">
          <div class="img-filler"></div>
        </div>
        <div class="col-3">
          <div class="img-filler"></div>
        </div>
      </section>
      <section class="row">
        <div class="col-md-12">
          <h2>Keeps</h2>
        </div>
        <div class="col-md-4">
          <div class="img-filler-lg"></div>
        </div>
        <div class="col-md-4">
          <div class="img-filler-lg"></div>
        </div>
        <div class="col-md-4">
          <div class="img-filler-lg"></div>
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


export default {
setup(){
  const route = useRoute();
  async function getProfileById() {
    try {
      const profileId = route.params.profileId;
      await accountService.setActiveProfile(profileId)
    }
    catch (error){
      Pop.error(error);
    }
  }
  onMounted(() => {
    getProfileById();
    // TODO
    // getVaultsByCreatorId(); 
    // getKeepsByCreatorId();
  })
  return{
    profile: computed(() => AppState.activeProfile)
  }
}
}
</script>


<style lang="scss" scoped>

</style>