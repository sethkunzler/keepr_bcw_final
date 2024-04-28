<template>
  <div class="bg-info bg-opacity-75">
    <nav class="navbar navbar-expand-sm navbar-light bg-success bg-opacity-75 px-3 text-center">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
        <div class="border-top border-bottom border-dark selectable border-2  text-dark rounded p-2">
          <h4 class="italic mb-0">
            The Keepr Co. 
          </h4> 
        </div>
      </router-link>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarText">
        <ul class="navbar-nav me-auto">
          <!-- TODO write an About Page -->
          <!-- <li>
            <router-link :to="{ name: 'About' }" class="btn text-dark lighten-30 selectable text-capitalize fs-5 mx-1">
              About
            </router-link>
          </li> -->
          <li>
            <button type="button" 
            class="btn text-dark lighten-30 selectable text-capitalize fs-5 mx-1"
            data-bs-toggle="modal" 
            data-bs-target="#keepFormModal" 
            >
              + Create Keep
            </button>
          </li>
          <li>
            <button type="button" 
            class="btn text-dark lighten-30 selectable text-capitalize fs-5 mx-1"
            data-bs-toggle="modal" 
            data-bs-target="#vaultFormModal" 
            >
              + Create Vault
            </button>
          </li>
        </ul>
        <!-- LOGIN COMPONENT HERE -->
        <div class="mx-2">
          <button class="btn text-dark selectable fs-5" @click="toggleTheme" :title="theme == 'light' ? 'Enable Dark Mode' : 'Disable Dark Mode'">
            <i class="mdi" :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i>
          </button>
        </div>
        <Login />
      </div>
    </nav>
  </div>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
