<template>
  <div class="container">
    <section class="row">
      <div class="col-md-12">
        <h1 class="italic">Browse All Keeps</h1>
      </div>
    </section>
  </div>
  <div class="mx-auto fake-masonry">
    <div v-for="keep in keeps" class="">
      <KeepSimpleCard :keep="keep" />
      <!-- STUB -->
      <!-- <div  class="p-3 m-2 bg-success bg-opacity-25 rounded d-flex justify-content-center align-items-center">
        <img class="img-fluid rounded shadow" :src="keep.img" :alt="keep.name">
      </div> -->
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { keepsService } from "../services/KeepsService.js";
import KeepSimpleCard from "../components/KeepSimpleCard.vue";

export default {
  setup() {
    onMounted(getKeeps)
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      }
      catch (error){
        Pop.error(error);
      }
    }
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
