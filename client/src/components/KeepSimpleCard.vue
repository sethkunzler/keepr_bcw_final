<template>
  <div role="button" 
  @click="setActiveKeep(keep.id, vaultKeepId)" 
  data-bs-toggle="modal" 
  data-bs-target="#keepDetailsModal" 
  class="p-3 m-2 bg-success bg-opacity-25 selectable rounded d-flex justify-content-center align-items-center">
    <img class="img-fluid rounded shadow" :src="keep.img" :alt="keep.name">
  </div>
</template>


<script>
import { Keep } from "../models/Keep.js"
import { keepsService } from "../services/KeepsService.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import Pop from "../utils/Pop.js";
export default {
  props: {
    keep: { 
      type: Keep,
      required: true,
    },
    vaultKeepId:{
      type: Number
    }
  },
  setup(){
    return{
      async setActiveKeep(keepId, vaultKeepId) {
        try {
          await keepsService.setActiveKeep(keepId);
          if (vaultKeepId != undefined) {
            vaultKeepsService.setActiveVaultKeepId(vaultKeepId)
          }
          else {
            vaultKeepsService.setActiveVaultKeepId(0)
          }
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