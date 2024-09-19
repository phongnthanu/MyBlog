<template>
    <div class="login-container">
        <div class="form login-form">
            <h4 class="login-title">Đăng nhập</h4>
            <form class="py-3" @submit.prevent="handleLogin">
                <div class="form-group">
                    <input type="email" class="form-control" id="exampleDropdownFormEmail1" placeholder="email@example.com" required v-model="data.userName">
                </div>
                <div class="form-group">
                    <input type="password" class="form-control" id="exampleDropdownFormPassword1" placeholder="Mật khẩu" required v-model="data.password">
                </div>
                <div class="form-check mb-3">
                    <input type="checkbox" class="form-check-input" id="dropdownCheck">
                    <label class="form-check-label" for="dropdownCheck">
                        Ghi nhớ cho lần đăng nhập sau
                    </label>
                </div>
                <button type="submit" class="btn btn-primary btn-block">Đăng nhập</button>
            </form>
            <div class="dropdown-divider"></div>
            <router-link to="/signup" class="sub-link"><small>Chưa có tài khoản? Đăng ký ngay</small></router-link>
            <router-link to="#" class="sub-link"><small>Quên mật khẩu?</small></router-link>
        </div>
    </div>
</template>

<script>
import { mapActions } from 'vuex';
export default {
    data() {
        const me = this;
        return {
            data: {},
            imagePath: me.$variables.IMAGES_URL
        }
    },
    methods: {
        ...mapActions(['login']),
        async handleLogin() {
            const me = this;
            me.login(me.data)
                .then(() => {
                    const redirect = this.$route.query.redirect || '/';
                    this.$router.push(redirect);
                })
                .catch(error => {
                    console.error(error);
                    alert('Tài khoản hoặc mật khẩu không đúng')
                });
        }
    }
}
</script>
<style scoped>
    .login-container {
        .login-form {
            max-width: 400px;
            margin: auto;
            border: 1px solid #dee2e6;
            margin-top: 3rem;
            padding: 1.5rem;
            .login-title {
                text-align: center;
            }
            .sub-link {
                display: block;
                font-weight: 400;
                color: #212529;
                padding: 0.25rem;
            }
            .sub-link:hover {
                color: #16181b;
                text-decoration: none;
                background-color: #f8f9fa;
            }
        }
    }
</style>