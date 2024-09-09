<template>
    <div class="container" ref="container">
        <div class="page-container">
            <div class="page-content">
                <h4 class="list-post-title">
                    <span v-if="$route.query && $route.query.search">Kết quả tìm kiếm theo từ khóa "{{ $route.query.search }}"</span>
                    <span v-else>Tất cả bài viết</span>
                </h4>
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
      imagePath: me.$variables.IMAGES_URL,
      popularPosts: popularPosts,
      topPopularPost: popularPosts[0],
      aboutMeContent: null
    };
  },
  watch: {
    '$route.query'() {
      const me = this;
      me.getPost();
    }
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

    async getPost() {
      const me = this;
      let url = me.$variables.API_URL + 'v1/posts';
      if (me.$route.query && me.$route.query.search) {
        url += `?keyword=${me.$route.query.search}`;
      }
      me.$axios.get(url)
      .then(res => {
        if (res && res.data) {
            me.posts = res.data;
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
    .list-post-title {
        margin-top: 20px;
        text-align: center;
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