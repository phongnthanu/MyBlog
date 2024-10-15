<template>
  <div>
    <!-- page-header -->
    <header class="page-header">
        <div class="page-header-content">
            <h2 class="slogan">
                CONNECTOPIA - CẢI THIỆN KỸ NĂNG GIAO TIẾP
            </h2>
            <form class="search-wrapper col-md-7 col-sm-12" @submit.prevent="search">
                <input type="text" class="form-control" placeholder="Tìm kiếm bài viết" v-model="keyword">
                <button type="submit" class="btn btn-primary"><i class="ti-search"></i></button>
            </form>
        </div>
    </header>
    <!-- end of page header -->

    <div class="container" ref="container">
        <section>
            <div class="feature-posts">
                <a href="single-post.html" class="feature-post-item">                       
                    <span>Chủ đề</span>
                </a>
                <a href="single-post.html" class="feature-post-item">
                    <img src="@/assets/images/img-1.jpg" class="w-100" alt="">
                    <div class="feature-post-caption">Giao tiếp</div>
                </a>
                <a href="single-post.html" class="feature-post-item">
                    <img src="@/assets/images/img-2.jpg" class="w-100" alt="">
                    <div class="feature-post-caption">Học tiếng Anh</div>
                </a>
                <a href="single-post.html" class="feature-post-item">
                    <img src="@/assets/images/img-3.jpg" class="w-100" alt="">
                    <div class="feature-post-caption">Âm nhạc</div>
                </a>
                <a href="single-post.html" class="feature-post-item">
                    <img src="@/assets/images/img-4.jpg" class="w-100" alt="">
                    <div class="feature-post-caption">Du học</div>
                </a>
            </div>
        </section>
        <hr>
        <div class="page-container">
            <div class="page-content">
                <h4 class="text-center" v-if="$route.query.search"> {{ allPost.length }} kết quả tìm kiếm cho "{{ $route.query.search }}"</h4>
                <div v-if="allPost && allPost.length > 0">
                    <div class="card">
                        <div class="card-header text-center">
                            <h5 class="card-title">{{ topPost.title }}</h5> 
                            <small class="small text-muted">{{ new Date(topPost.modifiedDate).toLocaleDateString() }}
                                <span class="px-2">-</span>
                                <a href="#" class="text-muted">32 bình luận</a>
                            </small>
                        </div>
                        <div class="card-body">
                            <div class="blog-media">
                                <img :src="imagePath + topPost.banner" alt="" class="w-100">
                                <a href="#" class="badge badge-primary">#Lắng nghe</a>     
                            </div>  
                            <p class="my-3">{{ topPost.summary }}</p>
                        </div>
                        
                        <div class="card-footer d-flex justify-content-between align-items-center flex-basis-0">
                            <button class="btn btn-primary circle-35 mr-4"><i class="ti-back-right"></i></button>
                            <router-link :to="`/post/${topPost.id}`" class="btn btn-outline-dark btn-sm">Đọc thêm</router-link>
                            <a href="#" class="text-dark small text-muted">Bởi : Suri</a>
                        </div>                  
                    </div>
                    <hr>
                    <div class="post-container">
                        <div class="card text-center mb-5" v-for="post in posts" :key="post.id">
                            <div class="card-header p-0">                                   
                                <div class="blog-media">
                                    <img :src="imagePath + post.banner" alt="" class="w-100">
                                    <a href="#" class="badge badge-primary">#Giao tiếp</a>        
                                </div>  
                            </div>
                            <div class="card-body px-0">
                                <h5 class="card-title mb-2">{{ post.title }}</h5>    
                                <small class="small text-muted">{{ new Date(post.modifiedDate).toLocaleDateString() }}
                                    <span class="px-2">-</span>
                                    <a href="#" class="text-muted">34 bình luận</a>
                                </small>
                                <p class="my-2">{{ post.summary }}</p>
                            </div>
                            
                            <div class="card-footer p-0 text-center">
                                <router-link :to="`/post/${post.id}`" class="btn btn-outline-dark btn-sm">Đọc thêm</router-link>
                            </div>                  
                        </div>
                    </div>
                    <button class="btn btn-primary btn-block my-4">Tải thêm bài viết</button>
                </div>
                <div v-else>
                    <h5 class="text-center" v-if="!$route.query.search">Chưa có bài viết</h5>
                </div>
            </div>

            <!-- Sidebar -->
            <div class="page-sidebar text-center">
                <h6 class="sidebar-title section-title mb-4 mt-3">Giới thiệu</h6>
                <img src="@/assets/images/avatar.jpg" alt="" class="circle-100 mb-3">
                <div class="socials mb-3 mt-2">
                    <a href="javascript:void(0)"><i class="ti-facebook"></i></a>
                    <a href="javascript:void(0)"><i class="ti-twitter"></i></a>
                    <a href="javascript:void(0)"><i class="ti-pinterest-alt"></i></a>
                    <a href="javascript:void(0)"><i class="ti-instagram"></i></a>
                    <a href="javascript:void(0)"><i class="ti-youtube"></i></a>
                </div>
                <p>{{ aboutMeContent }}</p>
                

                <h6 class="sidebar-title mt-5 mb-4">Nhận thông báo</h6>
                <form action="">
                    <div class="subscribe-wrapper">
                        <input type="email" class="form-control" placeholder="Địa chỉ email">
                        <button type="submit" class="btn btn-primary"><i class="ti-location-arrow"></i></button>
                    </div>
                </form>

                <h6 class="sidebar-title mt-5 mb-4">Thẻ</h6>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#GiaoTiếpHiệuQuả</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#LắngNghe</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#ThuyếtPhục</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#TựTin</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#ĐắcNhânTâm</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#GiaoTiếpTrongCôngViệc</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#ỨngXử</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#Communication</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#ChiaSẻ</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#GiaoTiếpQuaTinNhắn</a>

                <h6 class="sidebar-title mt-5 mb-4">Instagram</h6>
                <div class="row px-3">
                    <div class="col-4 p-1 figure">
                        <a href="#" class="figure-img">
                            <img src="@/assets/images/insta-1.jpg" alt="">
                        </a>
                    </div>
                    <div class="col-4 p-1 figure">
                        <a href="#" class="figure-img">
                            <img src="@/assets/images/insta-2.jpg" alt="" class="w-100 m-0">
                        </a>
                    </div>  
                    <div class="col-4 p-1 figure">
                        <a href="#" class="figure-img">
                            <img src="@/assets/images/insta-3.jpg" alt="" class="w-100">
                        </a>
                    </div>
                    <div class="col-4 p-1 figure">
                        <a href="#" class="figure-img">
                            <img src="@/assets/images/insta-4.jpg" alt="" class="w-100 m-0">
                        </a>
                    </div>  
                    <div class="col-4 p-1 figure">
                        <a href="#" class="figure-img">
                            <img src="@/assets/images/insta-5.jpg" alt="" class="w-100">
                        </a>
                    </div>
                    <div class="col-4 p-1 figure">
                        <a href="#" class="figure-img">
                            <img src="@/assets/images/insta-6.jpg" alt="" class="w-100 m-0">
                        </a>
                    </div>                          
                </div>  

                <figure class="figure mt-5">
                    <a href="" class="figure-img">
                        <img src="@/assets/images/img-4.jpg" alt="" class="w-100">
                        <figcaption class="figcaption">Kết nối</figcaption>
                    </a>
                </figure>

                <h6 class="sidebar-title mt-5 mb-4">Bài viết thịnh hành</h6>
                <div class="card mb-4">
                    <router-link :to="`/post/${topPopularPost.id}`" class="overlay-link"></router-link>
                    <div class="card-header p-0">                                   
                        <div class="blog-media">
                            <img :src="imagePath + topPopularPost.banner" alt="" class="w-100">
                            <a href="#" class="badge badge-primary">#Tự tin</a>      
                        </div>  
                    </div>
                    <div class="card-body px-0">
                        <h5 class="card-title mb-2 max-2-line">{{ topPopularPost.title }}</h5>   
                        <small class="small text-muted"><i class="ti-calendar pr-1"></i> {{ new Date(topPopularPost.modifiedDate).toLocaleDateString() }}
                        </small>
                        <p class="my-2 max-2-line">{{ topPopularPost.summary }}</p>
                    </div>      
                </div>
                <div v-for="post in popularPosts" :key="post.id" class="media text-left mb-4">
                    <router-link :to="`/post/${post.id}`" class="overlay-link"></router-link>
                    <img class="mr-3" :src="imagePath + post.banner" width="100px" alt="Generic placeholder image">
                    <div class="media-body overflow-hidden">
                        <h6 class="mt-0 max-1-line">{{ post.title }}</h6>
                        <p class="mb-2 max-1-line">{{ post.summary }}</p>
                        <p class="text-muted small"><i class="ti-calendar pr-1"></i> {{ new Date(post.modifiedDate).toLocaleDateString() }}</p>
                    </div>
                </div>
                <div class="ad-card d-flex text-center align-items-center justify-content-center">
                    <span href="#" class="font-weight-bold">ADS</span>
                </div>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  data() {
    const me = this;
    return {
      allPost: [],
      posts: [],
      topPost: null,
      imagePath: me.$variables.IMAGES_URL,
      popularPosts: [],
      topPopularPost: null,
      aboutMeContent: null,
      keyword: null
    };
  },
  created() {
    const me = this;
    if (me.$route.query && me.$route.query.search) {
        me.keyword = me.$route.query.search;
    }
    me.getPost(me.keyword);
    me.getAboutMeContent();
    me.getPopularPosts();
  },
  methods: {
    async getAboutMeContent() {
      const me = this;
      me.$axios.get(me.$variables.API_URL + 'v1/settings/HomePageAboutMeContent')
      .then(res => {
        if (res && res.data && res.data.value) {
            me.aboutMeContent = res.data.value;
        }
      });
    },

    scrollDown() {
        const targetElement = this.$refs.container;
        window.scrollTo({
            top: targetElement.offsetTop,
            behavior: 'smooth'
        });
    },
    async getPost(keyword) {
      const me = this;
      let url = me.$variables.API_URL + 'v1/posts';
      if (keyword) {
        url += `?keyword=${keyword}`;
      }
      me.$axios.get(url)
      .then(res => {
        me.allPost = [];
        me.posts = [];
        me.topPost = null;
        if (res && res.data && res.data.length > 0) {
            me.allPost = res.data;
            let topPostIndex = 0;
            for (let i = 0; i < res.data.length; i++) {
                if (res.data[i].isTop) {
                    topPostIndex = i;
                    break;
                }
            }
            let posts = [...res.data];
            if (posts.length > 1) {
                posts.splice(topPostIndex, 1);
                me.posts = posts;
            }
            me.topPost = res.data[topPostIndex];
        }
      });
    },

    async getPopularPosts() {
      const me = this;
      try {
        let res = await me.$axios.get(`${me.$variables.API_URL}v1/posts/popular-posts/${4}`);
        if (res && res.data && res.data.length > 0) {
            let topPostIndex = 0;
            for (let i = 0; i < res.data.length; i++) {
                if (res.data[i].isTop) {
                    topPostIndex = i;
                    break;
                }
            }
            let posts = [...res.data];
            posts.splice(topPostIndex, 1);
            me.popularPosts = posts;
            me.topPopularPost = res.data[topPostIndex];
        }
      }
      catch(ex) {
        console.log(ex);
      }
    },

    search() {
        const me = this;
        if (me.keyword != me.$route.query.search) {
            me.$router.replace({
                path: me.$route.path,
                query: { search: me.keyword }
            });
        }
        me.getPost(me.keyword);
    }
  } 
}
</script>
<style scoped>
    .page-header {
        display: flex;
        justify-content: center;
        align-items: center;
        .page-header-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            .slogan {
                color: white;
                font-weight: bold;
            }
            .btn-experience {
                border: 1px solid white;
                color: white;
            }
            .btn-experience:hover {
                color: white;
                background-color: #FF6F61;
                border-color: #FF6F61;
            }

            .search-wrapper {
                position: relative;
                margin-top: 10px;
            }

            .search-wrapper input {
                border-radius: 0 40px 40px 0;
                margin: auto;
            }

            .search-wrapper button {
                width: 50px;
                height: 50px;
                border-radius: 50%;
                line-height: 56px;
                font-weight: bold;
                font-size: 22px;
                position: absolute;
                border: 0;
                right: 0;
                top: -6px;
                border: 2px solid white !important;
                padding: 0;
                padding-bottom: 6px;
                padding-left: 2px;
            }
        }
    }
    .max-1-line {
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }
    .max-2-line {
        display: -webkit-box;        /* Sử dụng flexbox ẩn */
        -webkit-box-orient: vertical; /* Hướng theo chiều dọc */
        -webkit-line-clamp: 2;       /* Hiển thị tối đa 2 dòng */
        overflow: hidden;            /* Ẩn phần văn bản vượt quá */
        text-overflow: ellipsis;     /* Thêm dấu '...' cho phần bị cắt */
    }
</style>