import authService from "@/services/authService";
import Vue from 'vue';
import Vuex from 'vuex';
import commonFunctions from '@/commons/commonFunctions';

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
      token: localStorage.getItem(`${commonFunctions.getPrefixCacheKey()}authToken`) || null,
      user: localStorage.getItem(`${commonFunctions.getPrefixCacheKey()}currentUser`) ? JSON.parse(localStorage.getItem(`${commonFunctions.getPrefixCacheKey()}currentUser`)) : null
    },
    mutations: {
      setToken(state, token) {
        state.token = token;
      },
      setUser(state, user) {
        state.user = user;
      },
      logout(state) {
        state.token = null;
        state.user = null;
      }
    },
    actions: {
      async login({ commit }, user) {
        let token = await authService.login(user);
        if (token) {
            commit('setToken', token);
            commit('setUser', user);
        }
      },
      logout({ commit }) {
        authService.logout();
        commit('logout');
      }
    },
    getters: {
      isAuthenticated: state => !!state.token,
      getToken: state => state.token,
      currentUser: state => state.user
    }
  });
  
export default store;

// const user = JSON.parse(localStorage.getItem('user'));
// const initialState = user
//   ? { status: { loggedIn: true }, user }
//   : { status: { loggedIn: false }, user: null };

// export const auth = {
//   namespaced: true,
//   state: initialState,
//   actions: {
//     login({ commit }, user) {
//       return AuthService.login(user).then(
//         user => {
//           commit('loginSuccess', user);
//           return Promise.resolve(user);
//         },
//         error => {
//           commit('loginFailure');
//           return Promise.reject(error);
//         }
//       );
//     },
//     logout({ commit }) {
//       AuthService.logout();
//       commit('logout');
//     }
//   },
//   mutations: {
//     loginSuccess(state, user) {
//       state.status.loggedIn = true;
//       state.user = user;
//     },
//     loginFailure(state) {
//       state.status.loggedIn = false;
//       state.user = null;
//     },
//     logout(state) {
//       state.status.loggedIn = false;
//       state.user = null;
//     }
//   }
// };