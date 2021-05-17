<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="LlamaTech.Blog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

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

    <title>Blog | Llamatech</title>
</head>
<body>
    <!-- Boton volver arriba -->
    <span class="up"><i class="fa  fa-angle-double-up"></i></span>
    <!-- End boton volver arriba -->
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" href="index.aspx">
                    <img src="images/LlamaTech_Alpha.png" alt="" class="img-fluid"
                        width="200px"></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="index.aspx">Inicio</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Blog.aspx">Blog</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="index.aspx#contact">Contacto</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- End Navbar -->

        <!-- Posts -->

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <section class="posts">
                    <div class="posts__container">
                        <div class="container">
                            <div class="row">
                                <!-- Filtro -->
                                <div class="col-md-12">
                                    <div class="row posts__filter">
                                        <!-- Selector -->
                                        <div class="col-md-3 mt-3">
                                            <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <!-- End Selector -->
                                        <!-- Buscador -->
                                        <div class="col-md-3 mt-3">
                                            <div class="input-group mb-3">
                                                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                                            </div>
                                        </div>
                                        <!-- End Buscador -->
                                    </div>
                                </div>
                            </div>
                            <div class="row row__content--blog">
                                <!-- End Filtro -->
                                <!-- Cards -->
                                <div>
                                    <asp:Image ID="imgError" runat="server" CssClass="img__error" ImageUrl="images/no-data-found.png" Style="width: 200px; height: auto;" Visible="false" />
                                </div>
                                <asp:Repeater ID="rptEntradas" runat="server" OnItemDataBound="rptEntradas_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="col-md-4">
                                            <div class="card-blog">
                                                <div class="card-banner">
                                                    <p class="card-time">
                                                        <%# Eval("Day") %>
                                                        <span>
                                                            <asp:Label ID="lblMes" runat="server" Text='<%# Eval("Month") %>'>
                                                            </asp:Label></span>
                                                    </p>
                                                    <img src="<%# Eval("Imagen") %>" class="banner-img" alt="" />
                                                </div>
                                                <div class="card-body">
                                                    <p class="blog-category"><%# Eval("Titulo") %></p>
                                                    <h2 class="blog-title"><%# Eval("Titulo") %></h2>
                                                    <p class="blog-description">
                                                        <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Descripcion") %>' ForeColor="#333333"></asp:Label>
                                                    </p>
                                                    <a href="<%# GetRouteUrl("Article", new { id = Eval("IdPublicacion"), slug = Eval("Slug")}) %>" target="_blank">Ver mas...</a>
                                                    <div class="card-profile">
                                                        <img class="profile-img" src="<%# Eval("FotoPerfil") %>" alt="" />
                                                        <div class="card-profile-info">
                                                            <h3 class="profile-name"><%# Eval("Usuario") %></h3>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <!-- Pagination -->
                                <div class="col-md-12 posts__pag" id="divPaging" runat="server">
                                    <nav aria-label="Page navigation example">
                                        <ul class="pagination">
                                            <li class="page-item">
                                                <asp:LinkButton ID="lbtnFirst" runat="server" Visible="false" CssClass="page-link" OnClick="lbtnFirst_Click">
                                        Principal
                                                </asp:LinkButton>
                                            </li>
                                            <li class="page-item">
                                                <asp:LinkButton ID="lbtnPrevious" runat="server" Visible="false" CssClass="page-link" OnClick="lbtnPrevious_Click">
                                        Anterior
                                                </asp:LinkButton>
                                            </li>
                                            <li class="page-item">
                                                <asp:DataList ID="dlPaging" runat="server" OnItemCommand="dlPaging_ItemCommand" OnItemDataBound="dlPaging_ItemDataBound" RepeatDirection="Horizontal">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnPaging" runat="server" CssClass="page-link" CommandArgument='<%# Eval("PageIndex") %>' CommandName="Paging" Text='<%# Eval("PageText") %>' />
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </li>
                                            <li class="page-item">
                                                <asp:LinkButton ID="lbtnNext" runat="server" Visible="false" CssClass="page-link" OnClick="lbtnNext_Click">
                                        Siguiente
                                                </asp:LinkButton>
                                            </li>
                                            <li class="page-item">
                                                <asp:LinkButton ID="lbtnLast" runat="server" Visible="false" CssClass="page-link" OnClick="lbtnLast_Click">
                                        Ultima
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </nav>
                                </div>
                                <!-- End Pagination -->
                            </div>
                        </div>
                    </div>
                </section>

            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- EndP Posts -->

        <!-- footer -->
        <footer class="footer bg-dark" id="footer">
            <div class="container">
                <div class="row text-center footer__items">
                    <div class="col-md-4">
                        Copyright 2021
                    </div>
                    <div class="col-md-4">
                        <a href="#">
                            <img src="images/LlamaTech_Alpha.png" class="img-fluid" width="150px" alt=""></a>
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
    <script src="https://code.jquery.com/jquery-3.5.1.js"
        integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous"></script>

    <!-- OWL -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/owl-carousel/1.3.3/owl.carousel.min.js"
        crossorigin="anonymous"></script>

    <!-- Custom JS -->
    <script src="js/app.js"></script>
</body>
</html>
