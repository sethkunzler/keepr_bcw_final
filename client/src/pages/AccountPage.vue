<template>
    <div v-if="account != null">
    <div class="banner-container text-center" :style="{ backgroundImage: `url(${account.coverImg})` }">
      <img class="banner img-fluid" :src="account.coverImg" alt="Cover Image">
    </div>

    <div class="container">
      <section class="row">
        <div class="col-12">
          <h3 class="text-center italic">Welcome <span class="text-capitalize">{{ account.name }}</span> </h3>
        </div>
      </section>
      <section class="row my-2 justify-content-center">
        <div class="col-md-10 d-flex justify-content-center text-center border rounded shadow">
          <div class="container">
            <div class="row my-3">
              <div class="col-md-5">
                <img class="img-fluid profile-img my-2 border border-success" :src="account.picture" :alt="account.name" :title="account.name">
              </div>
              <div class="col-md-7">
                <div class="text-center">
                  <h2 class="text-capitalize">{{ account.name }}</h2>
                  <h5 class="italic">member since: <span class="bold">{{ account.createdAt.toLocaleDateString() }}</span></h5>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>

</style>
