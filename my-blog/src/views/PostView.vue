<template>
  <div>
    <!-- Page Header -->
    <header class="page-header page-header-mini">
        <h1 class="title">{{ data.title }}</h1>
        <ol class="breadcrumb pb-0">
            <li class="breadcrumb-item"><a href="/">Connectopia</a></li>
            <li class="breadcrumb-item active" aria-current="page">{{ data.title }}</li>
        </ol>
    </header>
    <!-- End Of Page Header -->

    <section class="container">
        <div class="page-container">
            <div class="page-content">
                <div class="card">
                    <div class="card-header pt-0">
                        <h3 class="card-title mb-4">{{ data.title }}</h3>
                        <div class="blog-media mb-4">
                            <img :src="imagePath + data.banner" alt="" class="w-100">
                            <a href="#" class="badge badge-primary">#Lắng nghe</a> 
                        </div>
                        <p><b>{{ data.summary }}</b></p>  
                        <small class="small text-muted">
                            <a href="#" class="text-muted">Bởi Suri</a>
                            <span class="px-2">·</span>
                            <span>{{ new Date(data.modifiedDate).toLocaleDateString() }}</span>
                            <span class="px-2">·</span>
                            <a href="#" class="text-muted">{{ totalComment }} bình luận</a>
                        </small>
                    </div>
                    <div class="card-body border-top" ref="postContent" v-html="data.content">
                    </div>
                    
                    <div class="card-footer">
                         <h6 class="mt-5 mb-3 text-center"><a href="#" class="text-dark">Bình luận {{ totalComment }}</a></h6>
                        <hr>
                        <div v-for="comment in comments" :key="comment.id" class="media mt-4">
                            <img :src="imagePath + comment.photoFileName" class="mr-3 thumb-sm rounded-circle" alt="...">
                            <div class="media-body">
                                <h6 class="mt-0">{{ comment.userName }}</h6>
                                <p>{{ comment.content }}</p>
                                <a href="#" class="text-dark small font-weight-bold"><i class="ti-back-right"></i> Reply</a>
                                <div v-if="comment.children && comment.children.length > 0">
                                    <div v-for="child in comment.children" :key="child.id" class="media mt-4">
                                        <a class="mr-3" href="#">
                                        <img :src="imagePath + child.photoFileName" class="thumb-sm rounded-circle" alt="...">
                                        </a>
                                        <div class="media-body align-items-center">
                                            <h6 class="mt-0">{{ child.userName }}</h6>
                                            <p>{{ child.content }}</p>
                                            <a href="#" class="text-dark small font-weight-bold"><i class="ti-back-right"></i> Reply</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div v-if="isAuthenticated">
                            <h6 class="mt-5 mb-3 text-center">Viết bình luận</h6>
                            <hr>
                            <form @submit.prevent="postComment">
                                <div class="form-row">
                                    <div class="col-12 form-group">
                                        <textarea name="" id="" cols="30" rows="10" class="form-control" placeholder="Nhập bình luận của bạn" required v-model="newComment"></textarea>
                                    </div>
                                    <div class="form-group col-12">
                                        <button type="submit" class="btn btn-primary btn-block">Gửi bình luận</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <router-link v-else :to="{ path: '/login', query: { redirect: $route.fullPath } }" class="btn btn-primary btn-block mt-5">Đăng nhập để bình luận</router-link>
                    </div>                  
                </div> 

                <h6 class="mt-5 text-center">Bài viết liên quan</h6>
                <hr>
                <div class="row">
                    <div v-for="post in relatedPosts" :key="post.id" class="col-md-6 col-lg-4">
                        <div class="card mb-5">
                            <div class="card-header p-0">                                   
                                <div class="blog-media">
                                    <img :src="imagePath + post.banner" alt="" class="w-100 related-post-banner">
                                    <a href="#" class="badge badge-primary">#Giao tiếp</a>        
                                </div>  
                            </div>
                            <div class="card-body px-0">
                                <h6 class="card-title mb-2">
                                    <!-- <router-link :to="{ name: 'post', query: { id: post.id } }" class="text-dark">{{ post.title }}</router-link> -->
                                    <a :href="getPostUrl(post.id)" class="text-dark">{{ post.title }}</a>
                                </h6>
                                <small class="small text-muted">{{ new Date(post.modifiedDate).toLocaleDateString() }}
                                    <span class="px-2">-</span>
                                    <a href="#" class="text-muted">34 bình luận</a>
                                </small>
                            </div>                  
                        </div>
                    </div>
                </div>
            </div>
            <!-- Sidebar -->
            <div class="page-sidebar">
                <h6 class=" ">Thẻ</h6>
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
    
                <div class="ad-card d-flex text-center align-items-center justify-content-center mt-4">
                    <span href="#" class="font-weight-bold">ADS</span>
                </div>
            </div>
        </div>
    </section>

  </div>
</template>

<script>
import { mapGetters } from 'vuex';
export default {
  data() {
    const me = this;
    return {
        data: {},
        imagePath: me.$variables.IMAGES_URL,
        comments: [],
        newComment: null,
        relatedPosts: [],
        totalComment: 0
    }
  },
  created() {
    const me = this;
    let id = me.$route.params.id;
    if (id) {
        me.getPostById(id);
        me.getCommentByPostId(id);
        me.getRelatedPosts(id);
    }
  },
  computed: {
        ...mapGetters(['isAuthenticated', 'currentUser', 'getToken'])
    },
  methods: {
    getPostUrl(id) {
        const me = this;
        // me.$router.push(`/post/${id}`);

        const resolvedRoute = me.$router.resolve({ name: 'post', params: { id: id } });

        // Điều hướng đến route đã giải quyết
        // this.$router.push(resolvedRoute.route);
        //window.location.href = resolvedRoute.href;
        return resolvedRoute.href;
    },

    async getRelatedPosts(id) {
      const me = this;
      try {
        let res = await me.$axios.get(`${me.$variables.API_URL}v1/posts/related-posts/${id}/${3}`);
        if (res && res.data) {
            me.relatedPosts = res.data;
        }
      }
      catch(ex) {
        console.log(ex);
      }
    },

    async getPostById(id) {
      const me = this;
      me.$axios.get(me.$variables.API_URL + 'v1/posts/' + id)
      .then(res => {
        if (res && res.data) {
            me.data = res.data;
            me.afterGetPost();
        }
      });
    },

    afterGetPost() {
      const me = this;
      me.$nextTick(() => {
        const boxTitles = me.$refs.postContent.querySelectorAll('.box-title');
        if (boxTitles && boxTitles.length > 0) {
          for (let i = 0; i < boxTitles.length; i++) {
            boxTitles[i].addEventListener('click', function(event) {
              me.toggleContent(event.target);
            });
          }
        }
        const formQuestions = me.$refs.postContent.querySelectorAll('.form-question');
        if (formQuestions && formQuestions.length > 0) {
          for (let i = 0; i < formQuestions.length; i++) {
            formQuestions[i].addEventListener("submit", function(event) {
              event.preventDefault();
            });
          }
        }
      });
    },

    async getCommentByPostId(postId) {
      const me = this;
      me.$axios.get(me.$variables.API_URL + 'v1/comments/comment-by-post/' + postId)
      .then(res => {
        if (res && res.data && res.data.length > 0) {
            me.totalComment = res.data.length;
            me.comments = me.listToTree(res.data);
        }
      });
    },

    async postComment() {
      const me = this;
      if (!me.getToken) {
        alert('Bạn phải đăng nhập để bình luận!');
        return;
      }
      let config = {
        headers: {
            Authorization: `Bearer ${me.getToken}`
        }
    };
      me.$axios.post(me.$variables.API_URL + 'v1/comments', {
        postId: me.data.id,
        content: me.newComment,
        createdBy: me.currentUser.id
      }, config)
      .then(res => {
        if (res && res.data && res.data[0]) {
            me.comments.unshift(res.data[0]);
            me.totalComment ++;
            me.newComment = null;
            alert('Gửi bình luận thành công');
        }
      })
      .catch(ex => {
        console.log(ex);
        alert(ex);
      });
    },

    listToTree(list) {
      const map = {};
      const roots = [];

      list.forEach(item => {
        map[item.id] = { ...item, children: [] };
      });

      list.forEach(item => {
        const node = map[item.id];
        if (!item.parentId) {
          roots.push(node);
        } else {
          map[item.parentId].children.push(node);
        }
      });

      return roots;
    },

    toggleContent(element) {
      var box = element.closest('.box');
      if (box) {
        var icon = box.querySelector('i');
        var content = box.querySelector(".box-content");

        // Kiểm tra nếu nội dung đã mở rộng hay chưa
        if (box.classList.contains('expanded')) {
          icon.classList.remove('ti-angle-up');
          icon.classList.add('ti-angle-down');
          content.style.display = 'none';
        } else {
          icon.classList.remove('ti-angle-down');
          icon.classList.add('ti-angle-up');
          content.style.display = 'block';
        }

        // Thay đổi trạng thái expanded
        box.classList.toggle('expanded');
      }
    }
  }
}
</script>
<style scoped>
  .related-post-banner {
      height: 170px;
  }
</style>