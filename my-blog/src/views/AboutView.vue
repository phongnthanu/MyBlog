<template>
  <div>
    <!-- Page Header -->
    <header class="page-header page-header-mini">
        <h1 class="title">Giới thiệu</h1>
        <ol class="breadcrumb pb-0">
            <li class="breadcrumb-item"><a href="/">Connectopia</a></li>
            <li class="breadcrumb-item active" aria-current="page">Giới thiệu</li>
        </ol>
    </header>
    <!-- End Of Page Header -->

    <section class="container-about" v-html="content">
    </section>
  </div>
</template>
<script>
export default {
  data() {
    return {
        content: null
    }
  },
  created() {
    const me = this;
    me.getAboutContent();
  },
  methods: {
    async getAboutContent() {
      const me = this;
      me.$axios.get(me.$variables.API_URL + 'v1/settings/AboutPageContent')
      .then(res => {
        if (res && res.data && res.data.value) {
            me.content = res.data.value;
        }
      });
    }
  }
}
</script>
<style scoped>
  .container-about {
    width: 800px;
    margin: auto;
    .about-me-container {
      display: flex;
      gap: 30px;
      margin-bottom: 30px;
      .about-me-avatar {
        width: 200px;
        border-radius: 50%;
      }
    }
    .project-banner {
      width: 100%;
    }
    .project-introduction {
      margin-top: 30px;
    }
  }
</style>