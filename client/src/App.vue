<template>
  <header class="sticky-top shadow">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light mt-4">
    <Footer />
  </footer>
  <KeepFormModal />
  <VaultFormModal />
  <KeepDetailsModal /> 
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Footer from './components/Footer.vue'
import KeepFormModal from './components/KeepFormModal.vue'
import KeepDetailsModal from './components/KeepDetailsModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Footer, KeepFormModal, KeepDetailsModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 100px;
}
.bold {
  font-weight: bold;
}
.italic {
  font-style: italic;
}
.text-shadow {
  text-shadow: 1px 1px 3px black;
}
.img-filler-lg {
  background-color: rgba($color: #858585, $alpha: .50);
  border-radius: 16px;
  height: 300px;
  width: 200px
}
.img-filler-md {
  background-color: rgba($color: #858585, $alpha: .50);
  border-radius: 16px;
  height: 200px;
  width: 150px
}
.img-filler-sm {
  background-color: rgba($color: #858585, $alpha: .50);
  border-radius: 16px;
  height: 100px;
  width: 100px
}
.title-filler {
  background-color: rgba($color: #858585, $alpha: .50);
  border-radius: 16px;
  height: 32px;
  width: 50%;
  position: center;
}
.paragraph-filler {
  background-color: rgba($color: #858585, $alpha: .50);
  border-radius: 16px;
  width: 80%;
  height: 16px;
}
.info-filler {
  background-color: rgba($color: #858585, $alpha: .50);
  border-radius: 16px;
  height: 16px;
  width: 20%;
}
.banner-container {
  background-size: 100% 100%;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-color: rgba(0, 0, 0, 0.40);
  background-blend-mode: color-burn;
  padding: 16px;
}
.banner {
  max-height: 80dvh;
  object-fit:fill;
}
.profile-img {
  aspect-ratio: 1/1;
  border-radius: 50%;
}
.fake-masonry {
  --gap: clamp(1rem, 5vmin, 2rem);
  columns: 350px; 
  gap: var(--gap);
  width: 96%;
  max-width: 1510px;
  margin: 1rem;
}
.fake-masonry > * {
  break-inside: avoid;
  margin-bottom: var(--gap);
}
</style>
