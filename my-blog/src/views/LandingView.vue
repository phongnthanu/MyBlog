<template>
    <div>
    <div class="hero_area">
    <!-- slider section -->
    <section class="slider_section ">
      <div class="carousel_btn-container">
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
          <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
          <span class="sr-only">Next</span>
        </a>
      </div>
      <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
          <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active">01</li>
          <li data-target="#carouselExampleIndicators" data-slide-to="1">02</li>
          <li data-target="#carouselExampleIndicators" data-slide-to="2">03</li>
        </ol>
        <div class="carousel-inner">
          <div class="carousel-item active">
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-5 offset-md-1">
                  <div class="detail-box">
                    <h1>
                      Connectopia <br>
                      Cải thiện kỹ năng <br>
                      Giao tiếp
                    </h1>
                    <p>
                      Khám phá bí quyết giao tiếp thành công để tạo dựng mối quan hệ bền vững và gây ấn tượng mạnh mẽ
                    </p>
                    <div class="btn-box">
                        <router-link to="/home" class="btn-1">Trải nghiệm ngay</router-link>
                        <router-link to="/about" class="btn-2">Về chúng tôi</router-link>
                    </div>
                  </div>
                </div>
                <div class="offset-md-1 col-md-4 img-container">
                  <div class="img-box">
                    <img src="@/assets/images/slider-img.png" alt="">
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="carousel-item ">
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-5 offset-md-1">
                  <div class="detail-box">
                    <h1>
                      Connectopia <br>
                      Kiến thức giao tiếp <br>
                      Miễn phí
                    </h1>
                    <p>
                      Nơi chia sẻ những bài học thú vị về giao tiếp
                    </p>
                    <div class="btn-box">
                        <router-link to="/home" class="btn-1">Trải nghiệm ngay</router-link>
                        <router-link to="/about" class="btn-2">Về chúng tôi</router-link>
                    </div>
                  </div>
                </div>
                <div class="offset-md-1 col-md-4 img-container">
                  <div class="img-box">
                    <img src="@/assets/images/slider-img.png" alt="">
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="carousel-item ">
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-5 offset-md-1">
                  <div class="detail-box">
                    <h1>
                      Connectopia <br>
                      Nơi kết nối <br>
                      Thế hệ trẻ
                    </h1>
                    <p>
                      Xây dựng các mối quan hệ chất lượng hơn nhờ bí quyết giao tiếp thành công
                    </p>
                    <div class="btn-box">
                        <router-link to="/home" class="btn-1">Trải nghiệm ngay</router-link>
                        <router-link to="/about" class="btn-2">Về chúng tôi</router-link>
                    </div>
                  </div>
                </div>
                <div class="offset-md-1 col-md-4 img-container">
                  <div class="img-box">
                    <img src="@/assets/images/slider-img.png" alt="">
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </section>
    <!-- end slider section -->
  </div>


  <!-- experience section -->

  <section class="experience_section layout_padding">
    <div class="container">
      <div class="row">
        <div class="col-md-5">
          <div class="img-box">
            <img src="@/assets/images/experience-img.jpg" alt="">
          </div>
        </div>
        <div class="col-md-7">
          <div class="detail-box">
            <div class="heading_container">
              <h2>
                Học giao tiếp là không nhàm chán
              </h2>
            </div>
            <p>
              Bạn đã sẵn sàng cải thiện kỹ năng giao tiếp để thăng tiến trong công việc và cuộc sống? Khám phá những bí kíp vàng ngay tại blog của chúng tôi!
            </p>
            <div class="btn-box">
                <router-link to="/home" class="btn-1">Khám phá ngay</router-link>
                <router-link to="/about" class="btn-2">Về chúng tôi</router-link>
            </div>
          </div>
        </div>

      </div>
    </div>
  </section>

  <!-- end experience section -->

  <!-- category section -->

  <section class="category_section layout_padding">
    <div class="container">
      <div class="heading_container">
        <h2>
           Phương pháp truyền tải kiến thức đa dạng
        </h2>
      </div>
      <div class="category_container">
        <div class="box">
          <div class="img-box">
            <img src="@/assets/images/c1.png" alt="">
          </div>
          <div class="detail-box">
            <h5>
              Đặt mục tiêu
            </h5>
          </div>
        </div>
        <div class="box">
          <div class="img-box">
            <img src="@/assets/images/c2.png" alt="">
          </div>
          <div class="detail-box">
            <h5>
              Đưa ra các thống kê
            </h5>
          </div>
        </div>
        <div class="box">
          <div class="img-box">
            <img src="@/assets/images/c3.png" alt="">
          </div>
          <div class="detail-box">
            <h5>
              Tương tác với trợ lý ảo
            </h5>
          </div>
        </div>
        <div class="box">
          <div class="img-box">
            <img src="@/assets/images/c4.png" alt="">
          </div>
          <div class="detail-box">
            <h5>
              Video tình huống
            </h5>
          </div>
        </div>
        <div class="box">
          <div class="img-box">
            <img src="@/assets/images/c5.png" alt="">
          </div>
          <div class="detail-box">
            <h5>
              Đưa ra lời khuyên
            </h5>
          </div>
        </div>
        <div class="box">
          <div class="img-box">
            <img src="@/assets/images/c6.png" alt="">
          </div>
          <div class="detail-box">
            <h5>
              Trò chơi
            </h5>
          </div>
        </div>
      </div>
    </div>
  </section>


  <!-- end category section -->

  <!-- about section -->

  <section class="about_section layout_padding">
    <div class="container">
      <div class="row">
        <div class="col-md-10 col-lg-9 mx-auto">
          <div class="img-box">
            <img src="@/assets/images/about-img.jpg" alt="">
          </div>
        </div>
      </div>
      <div class="detail-box">
        <h2>
          Về chúng tôi
        </h2>
        <p>
          Xin chào, tớ là Hà Thư. Du học sinh tại Mỹ. Tớ làm ra website này với mục đích chia sẻ kiến thức giao tiếp của bản thân. Các cậu hãy trải nghiệm và cho tớ feedback nhé!
        </p>
        <router-link to="/about" class="btn-2">Đọc thêm</router-link>
      </div>
    </div>
  </section>

  <!-- end about section -->

  <!-- freelance section -->

  <section class="freelance_section ">
    <div id="accordion">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-5 offset-md-1">
            <div class="detail-box">
              <div class="heading_container">
                <h2>
                  Nhu cầu học gia tiếp trên thế giới
                </h2>
              </div>
              <div class="tab_container">
                <div class="t-link-box" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                  <div class="img-box">
                    <img src="@/assets/images/f1.png" alt="">
                  </div>
                  <div class="detail-box">
                    <h5>
                      $250 triệu
                    </h5>
                    <h3>
                      Mua các khóa học giao tiếp
                    </h3>
                  </div>
                </div>
                <div class="t-link-box collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                  <div class="img-box">
                    <img src="@/assets/images/f2.png" alt="">
                  </div>
                  <div class="detail-box">
                    <h5>
                      2 triệu
                    </h5>
                    <h3>
                      Hợp đồng học viên
                    </h3>
                  </div>
                </div>
                <div class="t-link-box collapsed" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                  <div class="img-box">
                    <img src="@/assets/images/f3.png" alt="">
                  </div>
                  <div class="detail-box">
                    <h5>
                      700,000
                    </h5>
                    <h3>
                      Học viên trên toàn thế giới
                    </h3>
                  </div>
                </div>
                <div class="t-link-box collapsed" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                  <div class="img-box">
                    <img src="@/assets/images/f4.png" alt="">
                  </div>
                  <div class="detail-box">
                    <h5>
                      98%
                    </h5>
                    <h3>
                      Học viên <br>
                      Đánh giá 5 sao
                    </h3>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="collapse show" id="collapseOne" aria-labelledby="headingOne" data-parent="#accordion">
              <div class="img-box">
                <img src="@/assets/images/freelance-img.jpg" alt="">
              </div>
            </div>
            <div class="collapse" id="collapseTwo" aria-labelledby="headingTwo" data-parent="#accordion">
              <div class="img-box">
                <img src="@/assets/images/freelance-img.jpg" alt="">
              </div>
            </div>
            <div class="collapse" id="collapseThree" aria-labelledby="headingThree" data-parent="#accordion">
              <div class="img-box">
                <img src="@/assets/images/freelance-img.jpg" alt="">
              </div>
            </div>
            <div class="collapse" id="collapseFour" aria-labelledby="headingfour" data-parent="#accordion">
              <div class="img-box">
                <img src="@/assets/images/freelance-img.jpg" alt="">
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end freelance section -->

  <!-- client section -->

  <section class="client_section layout_padding">
    <div class="container">
      <div class="row">
        <div class="col-lg-9 col-md-10 mx-auto">
          <div class="heading_container">
            <h2>
              Feedback của độc giả
            </h2>
          </div>
          <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
              <div class="carousel-item active">
                <div class="detail-box">
                  <h4>
                    Phong Ngo
                  </h4>
                  <p>
                    Trang web chia sẻ kiến thức rất thú vị. Tại đây, tớ đã học được rất nhiều kiến thức bổ ích về giao tiếp.
                  </p>
                  <img src="@/assets/images/quote.png" alt="">
                </div>
              </div>
              <div class="carousel-item">
                <div class="detail-box">
                  <h4>
                    Phuong Anh Nguyen
                  </h4>
                  <p>
                    Cách chia sẻ kiến thức vô cùng mới lạ và không bị khô khan. Tuần nào mình cũng hóng thêm các bài viết mới.
                  </p>
                  <img src="@/assets/images/quote.png" alt="">
                </div>
              </div>
              <div class="carousel-item">
                <div class="detail-box">
                  <h4>
                    Tran Tung
                  </h4>
                  <p>
                    Blog thực sự hữu ích. Mình đã áp dụng các kiến thức học được tại đây vào cuộc sống để nâng cao các chất lượng các mối quan hệ và có thêm nhiều cơ hội thăng tiến hơn.
                  </p>
                  <img src="@/assets/images/quote.png" alt="">
                </div>
              </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
              <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
              <span class="sr-only">Next</span>
            </a>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end client section -->
    </div>
</template>

<script>
import '@/assets/css/style.css'
import '@/assets/css/responsive.css'

export default {
}
</script>
<style scoped>
    
</style>