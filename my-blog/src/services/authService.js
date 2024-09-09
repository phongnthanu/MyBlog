import Vue from 'vue';

class AuthService {
    async login(user) {
        return Vue.prototype.$axios.post(Vue.prototype.$variables.API_URL + 'v1/auth/login', {
            UserName: user.userName,
            Password: user.password
        })
        .then(res => {
            if (res && res.data) {
                localStorage.setItem(`${Vue.prototype.$commonFn.getPrefixCacheKey()}authToken`, res.data.authToken);
                localStorage.setItem(`${Vue.prototype.$commonFn.getPrefixCacheKey()}currentUser`, JSON.stringify(res.data));
            }
            return res.data;
        });
    }

    logout() {
        localStorage.removeItem(`${Vue.prototype.$commonFn.getPrefixCacheKey()}authToken`);
        localStorage.removeItem(`${Vue.prototype.$commonFn.getPrefixCacheKey()}currentUser`);
    }
}

export default new AuthService();