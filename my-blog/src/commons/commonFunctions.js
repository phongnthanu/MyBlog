class commonFunctions {
    getPrefixCacheKey() {
        return '_myBlog_';
    }

    getCurrentUser() {
        return JSON.parse(localStorage.getItem(`${this.getPrefixCacheKey()}currentUser`));
    }

    getAuthToken() {
        let authToken = null;
        let currentUser = this.getCurrentUser();
        if (currentUser) {
            authToken = currentUser.authToken;
        }
        return authToken;
    }
}

export default new commonFunctions();