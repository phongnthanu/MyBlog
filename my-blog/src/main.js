import Vue from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios';
import commonFunctions from '@/commons/commonFunctions';
import session from '@/commons/session';
import store from './store';
import '@/assets/css/main.css'
import '@/assets/css/themify-icons.css'

Vue.config.productionTip = false

const variables = {
  API_URL: 'http://backend:8080/api/',
  IMAGES_URL: 'http://backend:8080/images/'
};

Vue.prototype.$variables = variables;
Vue.prototype.$axios = axios;
Vue.prototype.$commonFn = commonFunctions;
Vue.prototype.$session = session;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

// Close the dropdown menu if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropdown-toggle')) {
    let dropdowns = document.getElementsByClassName("dropdown-menu");
    for (let i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}