<template>
<!-- Modal -->
<div class="modal fade" id="keepFormModal" aria-labelledby="keepFormModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-scrollable">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="keepFormModalLabel">Create a New Keep</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <form>
          <!-- Name description img -->
          <div class="form-floating my-2">
            <input type="text" class="form-control" id="name" placeholder="Name" required>
            <label for="name">Name</label>
          </div>
          <div class="form-floating my-2">
            <input type="url" class="form-control" id="img" placeholder="https://..." required>
            <label for="img">Image Link</label>
          </div>
          <div class="form-floating my-2">
            <textarea class="form-control" placeholder="Leave a description here" id="description" style="height: 100px" required></textarea>
            <label for="description">Description</label>  
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" required>Close</button>
            <button type="submit" class="btn btn-primary">Submit</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</div>
</template>


<script>
export default {
setup(){
return{}
}
}
</script>


<style lang="scss" scoped>

</style>