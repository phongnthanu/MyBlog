<template>
  <div>
    <!-- page-header -->
    <header class="page-header">
        <div class="page-header-content">
            <h2 class="slogan">
                CONNECTOPIA - Cải thiện kỹ năng giao tiếp
            </h2>
            <button class="btn btn-experience" @click="scrollDown">
                <i class="ti-angle-double-down"></i>
                Trải nghiệm ngay
            </button>
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
                <div class="card">
                    <div class="card-header text-center">
                        <h5 class="card-title">{{ topPost.title }}</h5> 
                        <small class="small text-muted">{{ new Date(topPost.modifiedDate).toLocaleDateString() }}
                            <span class="px-2">-</span>
                            <a href="#" class="text-muted">32 Comments</a>
                        </small>
                    </div>
                    <div class="card-body">
                        <div class="blog-media">
                            <img :src="imagePath + topPost.banner" alt="" class="w-100">
                            <a href="#" class="badge badge-primary">#Salupt</a>     
                        </div>  
                        <p class="my-3">{{ topPost.summary }}</p>
                    </div>
                    
                    <div class="card-footer d-flex justify-content-between align-items-center flex-basis-0">
                        <button class="btn btn-primary circle-35 mr-4"><i class="ti-back-right"></i></button>
                        <router-link :to="`/post/${topPost.id}`" class="btn btn-outline-dark btn-sm">Đọc thêm</router-link>
                        <a href="#" class="text-dark small text-muted">By : Suri</a>
                    </div>                  
                </div>
                <hr>
                <div class="post-container">
                    <div class="card text-center mb-5" v-for="post in posts" :key="post.id">
                        <div class="card-header p-0">                                   
                            <div class="blog-media">
                                <img :src="imagePath + post.banner" alt="" class="w-100">
                                <a href="#" class="badge badge-primary">#Placeat</a>        
                            </div>  
                        </div>
                        <div class="card-body px-0">
                            <h5 class="card-title mb-2">{{ post.title }}</h5>    
                            <small class="small text-muted">{{ new Date(post.modifiedDate).toLocaleDateString() }}
                                <span class="px-2">-</span>
                                <a href="#" class="text-muted">34 Comments</a>
                            </small>
                            <p class="my-2">{{ post.summary }}</p>
                        </div>
                        
                        <div class="card-footer p-0 text-center">
                            <router-link :to="`/post/${post.id}`" class="btn btn-outline-dark btn-sm">Đọc thêm</router-link>
                        </div>                  
                    </div>
                </div>
                <button class="btn btn-primary btn-block my-4">Load More Posts</button>
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
                

                <h6 class="sidebar-title mt-5 mb-4">Nhận thư báo</h6>
                <form action="">
                    <div class="subscribe-wrapper">
                        <input type="email" class="form-control" placeholder="Địa chỉ email">
                        <button type="submit" class="btn btn-primary"><i class="ti-location-arrow"></i></button>
                    </div>
                </form>

                <h6 class="sidebar-title mt-5 mb-4">Tags</h6>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#iusto</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#quibusdam</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#officia</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#animi</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#mollitia</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#quod</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#ipsa at</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#dolor</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#incidunt</a>
                <a href="javascript:void(0)" class="badge badge-primary m-1">#possimus</a>

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
                    <a href="single-post.html" class="figure-img">
                        <img src="@/assets/images/img-4.jpg" alt="" class="w-100">
                        <figcaption class="figcaption">Laboriosam</figcaption>
                    </a>
                </figure>

                <h6 class="sidebar-title mt-5 mb-4">Bài viết thịnh hành</h6>
                <div class="card mb-4">
                    <router-link :to="`/post/${topPopularPost.id}`" class="overlay-link"></router-link>
                    <div class="card-header p-0">                                   
                        <div class="blog-media">
                            <img :src="imagePath + topPopularPost.banner" alt="" class="w-100">
                            <a href="#" class="badge badge-primary">#Lorem</a>      
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
    let posts = [{
        title: 'Giới thiệu về chứng chỉ PMP',
        summary: 'Chứng chỉ PMP (Project Management Professional) là một trong những chứng chỉ quản lý dự án danh tiếng và được công nhận trên toàn cầu, được cấp bởi PMI (Project Management Institute). Chứng chỉ này xác nhận kiến thức và năng lực của các nhà quản lý dự án.',
        modifiedDate: new Date('2024-07-01')
    }];
    let popularPosts = [{
        title: 'Giới thiệu về chứng chỉ PMP',
        summary: 'Chứng chỉ PMP (Project Management Professional) là một trong những chứng chỉ quản lý dự án danh tiếng và được công nhận trên toàn cầu, được cấp bởi PMI (Project Management Institute). Chứng chỉ này xác nhận kiến thức và năng lực của các nhà quản lý dự án.',
        modifiedDate: new Date('2024-07-01')
    }];
    return {
      posts: posts,
      topPost: posts[0],
      imagePath: me.$variables.IMAGES_URL,
      popularPosts: popularPosts,
      topPopularPost: popularPosts[0],
      aboutMeContent: null
    };
  },
  created() {
    const me = this;
    me.getPost();
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
    async getPost() {
      const me = this;
      me.$axios.get(me.$variables.API_URL + 'v1/posts')
      .then(res => {
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
            me.posts = posts;
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