<template>
  <!-- <p> Hello Keep Details </p> -->
  <!-- Modal -->
  <div class="modal fade" id="keepDetailsModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="keepDetailsModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div v-if="keep.id" class="container">
          <section class="row">
            <div class="col-md-6">
              <div class="mt-3"></div>
              <div class="d-flex justify-content-center align-items-center bg-success p-1  rounded bg-opacity-50">
                <img class="img-fluid shadow rounded keep-img" :src="keep.img" :alt="keep.name">
              </div>
              <div class="mb-3"></div>
            </div>
            <!-- ANCHOR -->
            <div class="col-md-6">
              <div class="modal-header">
                <div class="d-flex align-items-center">
                </div>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                <div>
                  <h3 class="modal-title" id="keepDetailsModalLabel">
                    {{ keep.name }}
                  </h3>
                  <div>
                    <div v-if="user.id == keep.creatorId" class="form-floating">
                      <textarea class="form-control" placeholder="Leave a comment here" id="floatingTextarea2" style="height: 40dvh"></textarea>
                      <label for="floatingTextarea2"> Editable Description</label>
                    </div>
                    <div v-else>
                      <p>{{ keep.description }}</p>
                    </div>
                  </div>
                </div>
              </div>
              <div class="modal-footer">
                <div class="mx-2">
                  <div>

                  </div>
                  <span class="me-3">{{ keep.creator.name }}</span>
                  <img class="creator-profile-picture border border-success border-2" :src="keep.creator.picture" :alt="keep.creator.name">
                </div>
              </div>
            </div>
          </section>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js"
export default {
  setup(){
    
    return{
      keep: computed(() => AppState.activeKeep),
      user: computed(() => AppState.user)
    }
  }
}
</script>


<style lang="scss" scoped>
.creator-profile-picture {
  height: 8dvh;
  width: 8dvh;
  border-radius: 50%;
}
.keep-img {
  max-height: 80dvh;
}
</style>