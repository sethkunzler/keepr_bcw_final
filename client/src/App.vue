<template>
  <header class="sticky-top shadow">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
   <footer class="bg-dark text-light">
    <Footer />
  </footer>
  <KeepFormModal />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Footer from './components/Footer.vue'
import KeepFormModal from './components/KeepFormModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Footer   }
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
  height: 80px;
}
.bold {
  font-weight: bold;
}
.italic {
  font-style: italic;
}
</style>
