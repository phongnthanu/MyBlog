<template>
    <div class="login-container">
        <div class="form login-form">
            <h4 class="login-title">Đăng ký</h4>
            <form class="py-3" @submit.prevent="onSubmitForm" >
                <div class="form-group">
                    <input type="email" class="form-control" placeholder="email@example.com" required v-model="data.userName">
                </div>
                <div class="form-group">
                    <input type="password" class="form-control" placeholder="Password" required v-model="data.password" @input="validate('password')">
                    <span v-if="passwordError" class="error">{{ passwordError }}</span>
                </div>
                <div class="form-group">
                    <input type="password" class="form-control" placeholder="Confirm password" required v-model="data.rePassword" @input="validate('rePassword')">
                    <span v-if="rePasswordError" class="error">{{ rePasswordError }}</span>
                </div>
                <button type="submit" class="btn btn-primary btn-block">Sign up</button>
            </form>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        const me = this;
        return {
            data: {},
            imagePath: me.$variables.IMAGES_URL,
            passwordError: null,
            rePasswordError: null
        }
    },
    methods: {
        onSubmitForm() {
            const me = this;

            if (!me.passwordError && !me.rePasswordError) {
                me.signUp();
            }
        },
        
        validate(inputName) {
            const me = this;
            if (inputName == 'password') {
                const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

                if (!passwordPattern.test(me.data.password)) {
                    me.passwordError = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt.";
                } else {
                    me.passwordError = '';
                }
            }
            else if (inputName == 'rePassword') {
                if (me.data.password != me.data.rePassword) {
                    me.rePasswordError = "Mật khẩu nhập lại không khớp.";
                } else {
                    me.rePasswordError = '';
                }
            }
        },

        async signUp() {
            const me = this;
            me.$axios.post(me.$variables.API_URL + 'v1/auth/register', {
                UserName: me.data.userName,
                Password: me.data.password,
                RePassword: me.data.rePassword
            })
            .then(res => {
                if (res && res.data) {
                    alert(res.data);
                }
            })
            .catch(ex => {
                if (ex) {
                    alert(ex);
                }
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
            .error {
                color: red;
                font-size: 13px;
            }
        }
    }
</style>