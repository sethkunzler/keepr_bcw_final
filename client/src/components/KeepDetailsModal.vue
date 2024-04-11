<template>
  <!-- <p> Hello Keep Details </p> -->
  <!-- Modal -->
  <div class="modal fade" id="keepDetailsModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="keepDetailsModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div v-if="keep.id" class="container">
          <section class="row">
            <div class="col-md-6 d-flex align-self-stretch justify-content-center">
              <div></div>
              <div class="flex-grow-1 d-flex flex-column">
                <div class="mt-3"></div>
                <div class="flex-grow-1 d-flex justify-content-center align-items-center bg-success p-1 rounded bg-opacity-50">
                  <img class="img-fluid shadow rounded keep-img" :src="keep.img" :alt="keep.name">
                </div>
                <div class="mb-3"></div>
              </div>
              <div></div>
            </div>
            <!-- ANCHOR -->
            <div class="col-md-6 d-flex flex-column align-self-stretch justify-content-center">
              <div class="top-part">
                <div class="top-content d-flex justify-content-between align-items-center p-1 m-1">
                  <div v-if="user.id == keep.creatorId">
                    <div class="dropdown">
                      <button role="button" data-bs-toggle="dropdown" aria-expanded="false" class="btn selectable">
                        <span class="mdi mdi-dots-horizontal fs-4"></span>
                      </button>
                      <ul class="dropdown-menu text-start">
                        <!-- TODO stretch goal only -->
                        <!-- <li class="no-blue-select"><button type="button" class="dropdown-item" href="#"><span class="mdi mdi-pencil"></span> Edit Description</button></li> -->
                        <li class="no-blue-select"><button @click="deleteKeep(keep.id)" type="button" class="dropdown-item text-danger mdi mdi-close-circle" title="Click to Delete this Keep"> Delete</button></li>
                      </ul>
                    </div>
                  </div>
                  <div v-else class="p-3"></div>
                  <div class="d-flex align-items-center justify-content-between p-2">
                    <span class="mdi mdi-eye fs-5 mx-2"></span><span class="me-3">{{ keep.views }}</span>
                    <span class="italic border mx-2 px-2 rounded">k</span><span class="me-3">{{ keep.kept }}</span>
                  </div>
                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="bg-success bg-opacity-25 border p-1 my-1 rounded"></div>
              </div>
                
              <div class="d-flex flex-grow-1 flex-column justify-content-between m-1 p-1">
                <div class="middle-content d-flex flex-grow-1 flex-column">
                  <h3 class="modal-title text-center my-2" id="keepDetailsModalLabel">
                    {{ keep.name }}
                  </h3>
                  <div>
                    <div v-if="editing" class="form-floating">
                      <!-- TODO stretch goal edit description -->
                      <form>
                        <div>
                          <label for="description">Description</label>
                          <textarea class="form-control" placeholder="Write the description here" id="description" style="height: 40dvh">{{ editableData.description }}</textarea>
                        </div>
                        <div class="text-end my-2">
                          <button class="btn bg-success bg-opacity-50 bold">Save</button>
                        </div>
                      </form>
                    </div>
                    <div v-else>
                      <p><span class="me-3"></span>{{ keep.description }}</p>
                    </div>
                  </div>
                </div>

                <div class="bottom-content mb-2">
                  <div class="mx-2">
                    <div>
                      <!-- TODO Form - Add Keep to Vault -->
                    </div>
                    <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId} }" >
                      <div role="button" @click="dismissModal()" class="text-end">
                        <span class="me-1 text-success px-2">{{ keep.creator.name }}</span>
                        <img class="creator-profile-picture border border-success border-2" :src="keep.creator.picture" :alt="keep.creator.name">
                      </div>
                    </router-link>
                  </div>
                </div>
              </div>

            </div>
          </section>
        </div>
        <div v-else class="container">
          <div class="row placeholder-glow">
            <div class="col-md-6 d-flex align-self-stretch justify-content-center">
              <div></div>
              <div class="flex-grow-1 d-flex flex-column">
                <div class="mt-3"></div>
                <div class="flex-grow-1 d-flex justify-content-center align-items-center bg-success p-1 rounded bg-opacity-50">
                  <div class="img-filler-lg placeholder"></div>
                </div>
                <div class="mb-3"></div>
              </div>
              <div></div>
            </div>
            <div class="col-md-6">
              <div class="modal-header">
                <div class="d-flex align-items-center">
                </div>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
                <div class="title-filler placeholder"></div>
                <div class="paragraph-filler placeholder"></div>
                <div class="paragraph-filler placeholder"></div>
              </div>
              <div class="modal-footer">
                <div class="info-filler"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js"
import Pop from "../utils/Pop.js";
import { keepsService } from "../services/KeepsService.js";
import { Modal } from "bootstrap";
export default {
  setup(){
    let editing = false;
    return{
      editing, 
      // const editableData: ref(() => {description: "this is my description"}),
      keep: computed(() => AppState.activeKeep),
      user: computed(() => AppState.user),

      async deleteKeep(keepId) {
        try {
          const yes = await Pop.confirm()
          if (!yes) return
          await keepsService.deleteKeep(keepId);
          Modal.getOrCreateInstance('#keepDetailsModal').hide()
        }
        catch (error){
          Pop.error(error);
        }
      },
      async dismissModal() {
        Modal.getOrCreateInstance('#keepDetailsModal').hide()
      } 
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
.no-blue-select :active {
  background-color: rgba(200, 200, 200, .35);
}
</style>