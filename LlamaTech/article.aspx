<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article.aspx.cs" Inherits="LlamaTech.article1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <meta name="description" content="Technology blog, breaking news and tutorials." />
    <meta name="keywords" content="Technology blog, technology, programmers, developers, software" />

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">

    <!-- Google Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link
        href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap"
        rel="stylesheet">

    <!-- FontAwesome Icons -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"
        integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">

    <!-- OWL Carousel -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/owl-carousel/1.3.3/owl.carousel.min.css" crossorigin="anonymous" />

    <!-- Custom css -->
    <link rel="stylesheet" href="css/main.css">
    
    <!-- Tab Icon -->
    <link rel="icon" href="images/llama_logo.png">

    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Boton volver arriba -->
        <span class="up"><i class="fa  fa-angle-double-up"></i></span>
        <!-- End boton volver arriba -->

        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" href="https://llamatech.com.ar/index.aspx">
                    <img src="https://llamatech.com.ar/images/llama_isologo_alpha.png" alt="" class="img-fluid"
                        width="200px"></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto">
                        <li class="nav-item glow-text">
                            <a class="nav-link" href="https://llamatech.com.ar/index.aspx">Home</a>
                        </li>
                        <li class="nav-item glow-text">
                            <a class="nav-link" href="https://llamatech.com.ar/Blog.aspx">Blogs</a>
                        </li>
                        <li class="nav-item glow-text">
                            <a class="nav-link" href="https://llamatech.com.ar/index.aspx#contact">Contact Me</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- End Navbar -->

        <!-- Posts -->
        <section class="posts">
            <div class="posts__container">
                <div class="container">
                    <!-- Header -->
                    <div class="post__header">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-9">
                                        <h1 runat="server" id="hTitle"></h1>
                                    </div>
                                    <div runat="server" id="divDate" class="col-md-3 date">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>

                    <div class="post__header">
                        <div class="row">
                            <div class="col-md-12">
                                <h5 class="post_category" runat="server" id="hCategory"></h5>
                            </div>
                            <div class="col-md-12">
                            </div>
                            <div class="col-md-12">
                                <p runat="server" id="pDesc">
                                </p>
                            </div>
                        </div>
                    </div>
                    <!-- End Header -->
                    <!-- Post Content -->
                    <div class="post__content">
                        <p runat="server" id="pContent"></p>
                    </div>
                    <!-- End Post Content -->
                    <!-- Post footer -->
                    <div class="row">
                        <div class="col-md-12">
                            <hr>
                        </div>
                    </div>
                    <div class="post__footer">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="widget widget_socials">
                                    <div class="socials">
                                        <asp:HyperLink ID="hlFace" runat="server" Target="_blank" Style="cursor: pointer;"><i class="fa fa-facebook"></i></asp:HyperLink>
                                        <asp:HyperLink ID="hlTwitter" runat="server" Target="_blank" Style="cursor: pointer;"><i class="fa fa-twitter"></i></asp:HyperLink>
                                        <asp:HyperLink ID="hlLinkedin" runat="server" Target="_blank" Style="cursor: pointer;"><i class="fa fa-linkedin"></i></asp:HyperLink>
                                        <asp:HyperLink ID="hlWhatsapp" runat="server" Target="_blank" Style="cursor: pointer;"><i class="fa fa-whatsapp"></i></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 admin">
                                <h5 runat="server" id="user"></h5>
                                <div class="admin__img">
                                    <img src="" runat="server" id="imgUser" class="img-fluid" alt="">
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- End post footer -->

                    <%--<div class="post__category">
                        <div class="row">
                            <hr>
                            <div class="col-md-12 mt-2">
                                <h3>Mas sobre <span>Tecnologia</span></h3>
                            </div>
                            <div class="col-md-4 mt-3">
                                <div class="card__category">
                                    <img src="images/" alt="" class="img-fluid">
                                    <p>JavaScript</p>
                                </div>
                            </div>
                            <div class="col-md-4 mt-3">
                                <div class="card__category">
                                    <img src="images/" alt="" class="img-fluid">
                                    <p>C#</p>
                                </div>
                            </div>
                            <div class="col-md-4 mt-3">
                                <div class="card__category">
                                    <img src="images/" alt="" class="img-fluid">
                                    <p>Sql</p>
                                </div>
                            </div>
                            <div class="col-md-12 mt-3">
                                <h3>Entradas <span>Populares</span></h3>
                            </div>
                            <div class="col-md-4 mt-3">
                                <div class="card__category">
                                    <img src="images/" alt="" class="img-fluid">
                                    <p>JavaScript</p>
                                </div>
                            </div>
                            <div class="col-md-4 mt-3">
                                <div class="card__category">
                                    <img src="images/" alt="" class="img-fluid">
                                    <p>C#</p>
                                </div>
                            </div>
                            <div class="col-md-4 mt-3">
                                <div class="card__category">
                                    <img src="images/" alt="" class="img-fluid">
                                    <p>Sql</p>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
        </section>
        <!-- End Posts -->

        <!-- End Categorias -->

        <!-- footer -->
        <footer class="footer bg-dark" id="footer">
            <div class="container">
                <div class="row text-center footer__items">
                    <div class="col-md-4">
                        Copyright 2021
                    </div>
                    <div class="col-md-4">
                        <a href="#">
                            <img src="https://llamatech.com.ar/images/llama_isologo_alpha.png" class="img-fluid" width="150px" alt=""></a>
                    </div>
                    <div class="col-md-4">
                        <a href="https://courrouxdigital.com/" target="_blank">
                            <img src="https://llamatech.com.ar/images/logoCD-white.png" alt="" class="img-fluid" width="60px"></a>
                    </div>
                </div>
            </div>
        </footer>
        <!-- End footer -->
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-ygbV9kiqUc6oa4msXn9868pTtWMgiQaeYH7/t7LECLbyPA2x65Kgf80OJFdroafW"
        crossorigin="anonymous"></script>

    <!-- JQuery -->
    <script src="https://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous"></script>

    <!-- OWL -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/owl-carousel/1.3.3/owl.carousel.min.js" crossorigin="anonymous"></script>

    <!-- Custom JS -->
    <script src="js/app.js"></script>
</body>
</html>
