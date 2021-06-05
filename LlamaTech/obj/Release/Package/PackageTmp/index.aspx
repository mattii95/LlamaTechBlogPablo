<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LlamaTech.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
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

    <title>Llamatech</title>
</head>
<body runat="server" id="body">
    <!-- Boton volver arriba -->
    <span class="up"><i class="fa  fa-angle-double-up"></i></span>
    <!-- End boton volver arriba -->

    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <div class="container">
                <a class="navbar-brand" href="#">
                    <img src="images/llama_isologo_alpha.png" alt="" class="img-fluid"
                        width="200px"></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto">
                        <li class="nav-item glow-text">
                            <a class="nav-link" href="index.aspx">Home</a>
                        </li>
                        <li class="nav-item glow-text">
                            <a class="nav-link" href="Blog.aspx">Blogs</a>
                        </li>
                        <li class="nav-item glow-text">
                            <a class="nav-link" href="#contact">Contact me</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- End Navbar -->

        <!-- About Us -->
        <section runat="server" class="about" id="about">
            <div class="container">
                <div class="row">
                    <div class="col-12 pt-5 about__content">
                        <img runat="server" id="imgLogo" src="" style="width: 300px;" class="img-fluid" alt="">
                        <h2 runat="server" id="hTitle"></h2>
                        <p class="p-5" runat="server" id="pDesc">
                        </p>
                        <a href="#contact" class="button-contact">Contact me</a>
                    </div>
                </div>
            </div>
        </section>
        <!-- End About Us -->

        <!-- Blog -->
        <section runat="server" class="blog bg-dark" id="blog">
            <div class="container">
                <div class="row ">
                    <div class="col-12">
                        <h2 style="color: #ffffff;" class="pt-3">Recent Entries</h2>
                    </div>
                    <div class="blog-slider">

                        <asp:Repeater ID="rpPost" runat="server" OnItemDataBound="rpPost_ItemDataBound">
                            <ItemTemplate>
                                <div class="card-blog">
                                    <div class="card-banner">
                                        <p class="card-time">
                                            <%# Eval("Day") %>
                                            <span>
                                                <asp:Label ID="lblMes" runat="server" Text='<%# Eval("Month") %>'>
                                                </asp:Label></span>
                                        </p>
                                        <a href="<%# GetRouteUrl("Article", new { id = Eval("IdPublicacion"), slug = Eval("Slug")}) %>" target="_blank">
                                            <img src="<%# Eval("Imagen") %>" class="banner-img" alt="" /></a>
                                    </div>
                                    <div class="card-body">
                                        <p class="blog-category"><%# Eval("Categoria") %></p>
                                        <h2 class="blog-title"><%# Eval("Titulo") %></h2>
                                        <p class="blog-description">
                                            <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Descripcion") %>' ForeColor="#333333"></asp:Label>
                                        </p>
                                        <a href="<%# GetRouteUrl("Article", new { id = Eval("IdPublicacion"), slug = Eval("Slug")}) %>" target="_blank">See more</a>
                                        <div class="card-profile">
                                            <img class="profile-img" src="<%# Eval("FotoPerfil") %>" alt="" />
                                            <div class="card-profile-info">
                                                <h3 class="profile-name"><%# Eval("Usuario") %></h3>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-md-12 mb-5 mt-5 text-center">
                        <a href="Blog.aspx" class="button-contact">See more</a>
                    </div>


                </div>
            </div>
        </section>
        <!-- End Blog -->

        <!-- Contact -->
        <section class="contact" id="contact">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h2></h2>
                    </div>
                </div>
                <div class="row contact__row">
                    <div class="col-md-6 mt-2">
                        <h4 style="color: whitesmoke">Contact me</h4>
                        <div class="mb-3 row">
                            <label style="color: whitesmoke" for="txtEmail" class="col-sm-2 col-form-label">Email:</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control bg-dark text-info"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row">
                            <label style="color: whitesmoke" for="txtAsunto" class="col-sm-2 col-form-label">Subject:</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control bg-dark text-info"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb-3 row">
                            <label style="color: whitesmoke" for="txtMensaje" class="col-sm-2 col-form-label">Message:</label>
                            <div class="col-sm-10">
                                <textarea runat="server" class="form-control textarea bg-dark text-info" id="txtMensaje"></textarea>
                            </div>
                        </div>
                        <div class="col-12">
                            <asp:Button ID="btnEnviar" CssClass="button-contact mb-3" runat="server" Text="Send" OnClick="btnEnviar_Click" />
                        </div>
                    </div>
                    <div class="col-md-6 mt-2">
                        <h4 style="color: whitesmoke">Location</h4>
                        <div class="mapa">
                            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d13599.587333210657!2d-64.1785605772305!3d-31.418716044586027!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1ses-419!2sar!4v1610310699942!5m2!1ses-419!2sar" frameborder="0" style="border: 0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <%-- Redes Sociales --%>
                    <div class="col-md-6">
                        <div class="widget widget_socials pt-3">
                            <div class="socials">
                                <asp:Repeater ID="rpRs" runat="server">
                                    <ItemTemplate>
                                        <div class="tooltip">
                                            <a target="_blank" href='<%# Eval("Url") %>'><i class='<%# Eval("Icono") %>'></i></a>
                                            <span class="tooltiptext"><%# Eval("Titulo") %></span>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <%-- End Redes Sociales --%>
                    <%-- Contacto --%>
                    <div class="col-md-6">
                        <asp:Repeater ID="rpContacto" runat="server">
                            <ItemTemplate>
                                <p><i class='<%# Eval("Icono") %>'></i><%# Eval("Nombre") %></p>
                                <p style="color: whitesmoke" ><i class='<%# Eval("Icono") %>'>   </i><%# Eval("Nombre") %></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%-- End Contacto --%>
                </div>
            </div>
        </section>
        <!-- End Contact -->

        <!-- footer -->
        <footer class="footer bg-dark" id="footer">
            <div class="container">
                <div class="row text-center footer__items">
                    <div class="col-md-4">
                        Copyright 2021
                    </div>
                    <div class="col-md-4">
                        <a href="#">
                            <img src="images/llama_isologo_alpha.png" class="img-fluid" width="150px" alt=""></a>
                    </div>
                    <div class="col-md-4">
                        <a href="https://courrouxdigital.com/" target="_blank">
                            <img src="images/logoCD-white.png" alt="" class="img-fluid" width="60px"></a>
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
