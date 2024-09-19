<template>
  <div id="app">
    <!-- page First Navigation -->
    <nav class="navbar navbar-light bg-light">
        <div class="container">
            <a class="navbar-brand" href="#">
                <img src="@/assets/images/logo.svg" alt="">
            </a>
            <div class="socials">
                <a href="javascript:void(0)"><i class="ti-facebook"></i></a>
                <a href="javascript:void(0)"><i class="ti-twitter"></i></a>
                <a href="javascript:void(0)"><i class="ti-pinterest-alt"></i></a>
                <a href="javascript:void(0)"><i class="ti-instagram"></i></a>
                <a href="javascript:void(0)"><i class="ti-youtube"></i></a>
            </div>
        </div>
    </nav>
    <!-- End Of First Navigation -->

    <!-- Page Second Navigation -->
    <nav class="navbar custom-navbar navbar-expand-md navbar-light bg-primary sticky-top">
        <div class="container">
            <button class="navbar-toggler ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav">                     
                    <li class="nav-item">
                        <router-link to="/" class="nav-link"><i class="ti-home"></i></router-link>
                    </li>
                    <li class="nav-item">
                      <router-link to="/list-post" class="nav-link">Bài viết</router-link>
                    </li>
                    <li class="nav-item">
                      <router-link to="/about" class="nav-link">Giới thiệu</router-link>
                    </li>
                    <li class="nav-item">
                      <router-link to="/documents" class="nav-link">Tài liệu</router-link>
                    </li>
                </ul>
                <form class="search-wrapper" @submit.prevent="search">
                    <input type="text" class="form-control search-input" placeholder="Tìm kiếm" v-model="keyword">
                    <button type="submit" class="btn btn-primary btn-search"><i class="ti-search"></i></button>
                </form>
                <div class="navbar-nav ml-auto">
                    <ul class="navbar-nav" v-if="!isAuthenticated">
                        <li class="nav-item">
                            <router-link :to="{ path: '/login', query: { redirect: $route.fullPath } }" class="ml-4 btn btn-dark mt-1 btn-sm">Đăng nhập</router-link>
                        </li>
                        <li class="nav-item">
                        <router-link to="/signup" class="nav-link">Đăng ký</router-link>
                        </li>
                    </ul>
                    <div v-else class="navbar-user">
                        <img :src="imagePath + currentUser.photoFileName" alt="avatar" class="navbar-avatar">
                        <div class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-dropdownId="navbarAccountDropdown" @click="showDropdown">
                                {{ currentUser.userName }}
                            </a>
                            <div class="dropdown-menu" id="navbarAccountDropdown" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="#">Xem hồ sơ</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#" @click="handleLogout">Đăng xuất</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </nav>
    <!-- End Of Page Second Navigation -->

    <router-view/>

    <!-- Instagram Infor -->
    <div class="instagram-wrapper mt-5">
        <div class="ig-id">
            <a href="javascript:void(0)">Follow @joe_mitchell On Instagram</a>
        </div>
        <a href="javascript:void(0)" class="insta-item">
            <img src="@/assets/images/insta-1.jpg" alt="" class="w-100">
            <div class="overlay">
                <span>
                    <i class="ti-heart"></i> 23
                </span>
                <span>
                    <i class="ti-comment"></i> 12
                </span>
            </div>
        </a>
        <a href="javascript:void(0)" class="insta-item">
            <img src="@/assets/images/insta-2.jpg" alt="" class="w-100">
            <div class="overlay">
                <span>
                    <i class="ti-heart"></i> 23
                </span>
                <span>
                    <i class="ti-comment"></i> 12
                </span>
            </div>
        </a>
        <a href="javascript:void(0)" class="insta-item">
            <img src="@/assets/images/insta-3.jpg" alt="" class="w-100">
            <div class="overlay">
                <span>
                    <i class="ti-heart"></i> 23
                </span>
                <span>
                    <i class="ti-comment"></i> 12
                </span>
            </div>
        </a>
        <a href="javascript:void(0)" class="insta-item">
            <img src="@/assets/images/insta-4.jpg" alt="" class="w-100">
            <div class="overlay">
                <span>
                    <i class="ti-heart"></i> 23
                </span>
                <span>
                    <i class="ti-comment"></i> 12
                </span>
            </div>
        </a>
        <a href="javascript:void(0)" class="insta-item">
            <img src="@/assets/images/insta-5.jpg" alt="" class="w-100">
            <div class="overlay">
                <span>
                    <i class="ti-heart"></i> 23
                </span>
                <span>
                    <i class="ti-comment"></i> 12
                </span>
            </div>
        </a>
        <a href="javascript:void(0)" class="insta-item">
            <img src="@/assets/images/insta-6.jpg" alt="" class="w-100">
            <div class="overlay">
                <span>
                    <i class="ti-heart"></i> 23
                </span>
                <span>
                    <i class="ti-comment"></i> 12
                </span>
            </div>
        </a>
    </div>
    <!-- End Of Instagram Infor -->

    <!-- Page Footer -->
    <footer class="page-footer">
        <div class="container">
            <div class="row align-items-center justify-content-between">
                <div class="col-md-3 text-center text-md-left mb-3 mb-md-0">
                    <img src="@/assets/images/logo.svg" alt="" class="logo">
                </div>
                <div class="col-md-9 text-center text-md-right">
                    <div class="socials">
                        <a href="javascript:void(0)" class="font-weight-bold text-muted mr-4"><i class="ti-facebook pr-1"></i> 123,345</a>
                        <a href="javascript:void(0)" class="font-weight-bold text-muted mr-4"><i class="ti-twitter pr-1"></i> 321,534</a>
                        <a href="javascript:void(0)" class="font-weight-bold text-muted mr-4"><i class="ti-pinterest-alt pr-1"></i> 543,312</a>
                        <a href="javascript:void(0)" class="font-weight-bold text-muted mr-4"><i class="ti-instagram pr-1"></i> 123,023</a>
                        <a href="javascript:void(0)" class="font-weight-bold text-muted mr-4"><i class="ti-youtube pr-1"></i> 231,043</a>
                    </div>
                </div>  
            </div>
            <p class="border-top mb-0 mt-4 pt-3 small">&copy; {{ new Date().getFullYear() }}, JoeBlog Created By <a href="https://www.devcrud.com" class="text-muted font-weight-bold" target="_blank">DevCrud.</a>  All rights reserved </p> 
        </div>      
    </footer>
    <!-- End of Page Footer -->

  </div>
</template>

<script>
    import { mapGetters, mapActions } from 'vuex';
    export default {
        computed: {
            ...mapGetters(['isAuthenticated', 'currentUser'])
        },
        data() {
            const me = this;
            return {
                imagePath: me.$variables.IMAGES_URL,
                keyword: null
            }
        },
        methods: {
            ...mapActions(['logout']),
            /* When the user clicks on the button,
            toggle between hiding and showing the dropdown content */
            showDropdown($event) {
                let dropdownId = $event.srcElement.dataset.dropdownid;
                document.getElementById(dropdownId).classList.toggle("show");
            },

            handleLogout() {
                this.logout();
            },

            search() {
                const me = this;
                if (me.$route.name == 'list-post') {
                    if (me.$route.query.search != me.keyword) {
                            this.$router.replace({
                            path: me.$route.path,
                            query: { search: me.keyword }
                        });
                    }
                }
                else {
                    me.$router.push({ 
                        name: 'list-post', 
                        query: { search: me.keyword } 
                    });
                }
            }
        }
    }
</script>

<style scoped>
    .navbar-user {
        display: flex;
        align-items: center;
        .navbar-avatar {
            width: 40px;
            height: 40px;
            border-radius: 50%;
            background-color: lightgrey;
        }
    }
    .search-wrapper {
        position: relative;
        width: 300px;
        .search-input {
            height: 40px;
            border-radius: 0 40px 40px 0;
        }
        .btn-search {
            width: 35px;
            height: 35px;
            border-radius: 50%;
            line-height: 22px;
            position: absolute;
            right: 3px;
            top: 3px;
        }
    }
</style>
