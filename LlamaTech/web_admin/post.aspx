<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" enableEventValidation="false" CodeBehind="post.aspx.cs" Inherits="LlamaTech.web_admin.post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="Content-Type" content="text/html" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Admin Panel | Posts</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/startmin.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <link href="css/main.css" rel="stylesheet" />

    <!-- Editor de texto -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.23.0/ui/trumbowyg.min.css" />

    <!-- Sweet Alert -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <!-- Alerts -->
    <script src="../js/alerts.js"></script>


</head>
<body>
    <form id="form1" method="post" enctype="multipart/form-data" runat="server">
        <div id="wrapper">

            <!-- Navigation -->
            <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                <div class="navbar-header">
                    <a class="navbar-brand" href="frmPanelControl.aspx">Admin Panel</a>
                </div>

                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

                <ul class="nav navbar-nav navbar-left navbar-top-links">
                    <li><a href="../index.aspx" target="_blank"><i class="fa fa-home fa-fw"></i>Llamatech</a></li>
                </ul>

                <ul class="nav navbar-right navbar-top-links">
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                            <i class="fa fa-user fa-fw"></i>srcorru <b class="caret"></b>
                        </a>
                        <ul class="dropdown-menu dropdown-user">
                            <li><a href="#"><i class="fa fa-user fa-fw"></i>User Profile</a>
                            </li>
                            <li><a href="#"><i class="fa fa-gear fa-fw"></i>Settings</a>
                            </li>
                            <li class="divider"></li>
                            <li><a href="login.html"><i class="fa fa-sign-out fa-fw"></i>Logout</a>
                            </li>
                        </ul>
                    </li>
                </ul>
                <!-- /.navbar-top-links -->

                <div class="navbar-default sidebar" role="navigation">
                    <div class="sidebar-nav navbar-collapse">
                        <ul class="nav" id="side-menu">
                            <li>
                                <a href="frmPanelControl.aspx"><i class="fa fa-dashboard fa-fw"></i>Dashboard</a>
                            </li>
                            <li>
                                <a href="post.aspx"><i class="fa fa-edit fa-fw"></i>Entradas</a>
                            </li>
                            <li>
                                <a href="frmImages.aspx"><i class="fa fa-photo fa-fw"></i>Imagenes</a>
                            </li>
                            <li>
                                <a href="frmCategorias.aspx"><i class="fa fa-tags fa-fw"></i>Categorias</a>
                            </li>
                            <li>
                                <a href="frmUsuarios.aspx"><i class="fa fa-users fa-fw"></i>Usuarios</a>
                            </li>
                            <li>
                                <a href="frmHomePage.aspx"><i class="fa fa-home fa-fw"></i>Home Page</a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.sidebar-collapse -->
                </div>
            </nav>
            <!-- End Navigation -->
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <!-- Page Content -->
            <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Entradas</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <!-- Form -->
                    <div class="row">


                        <div class="col-md-8">
                            <div class="form-group">
                                <label>Titulo</label>
                                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Descripcion</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Contenido</label>
                                <textarea runat="server" id="txtContenido" class="form-control"></textarea>
                            </div>
                            <div class="form-group">
                                <label>Slug</label>
                                <asp:TextBox ID="txtSlug" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnGuardarPost" runat="server" CssClass="btn btn-success" Text="Guardar" />
                                <asp:Button ID="btnEliminarPost" runat="server" CssClass="btn btn-danger" Text="Eliminar" />
                                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
                            </div>
                        </div>


                        <div class="col-md-3">
                            <div class="form-group">
                                <label>ID</label>
                                <input id="txtId" class="form-control" style="width: 100px;"/>
                            </div>
                            <div class="form-group">
                                <label>Imagen Portada</label>
                                <asp:TextBox ID="txtImgPortada" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Image ID="imgPortada" runat="server" CssClass="img-responsive" />
                            </div>
                            <div class="form-group">
                                <label>Seleccionar categoria</label>
                                <asp:DropDownList ID="ddlCateg" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Seleccionar subcategoria</label>
                                <asp:DropDownList ID="ddlSubCategoria" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label>Seleccionar Estado</label>
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">&lt;Seleccione un Estado&gt;</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <hr>
                            <%--<div class="form-group">
                                <label>Subir imagenes</label>
                                <input type="file" id="fuImg" class="btnn" />
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"></asp:TextBox>
                                <label id="tamanioImg"></label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnGuardarImagen" runat="server" CssClass="btn btn-success" Text="Guardar" />
                                <asp:Button ID="btnCancelarImg" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
                            </div>--%>
                            <div class="form-group">
                                <asp:Button ID="btnVerImg" runat="server" CssClass="btn btn-info" Text="Ver imagenes" />
                            </div>
                            <hr>
                            <div class="form-group">
                                <label>Agregar categorias</label>
                                <asp:TextBox ID="txtAgregarCategoria" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnAgregarCategoria" runat="server" CssClass="btn btn-success" Text="Agregar" />
                                <asp:Button ID="btnCancelarCategoria" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
                            </div>
                            <hr>
                            <div class="form-group">
                                <label>Agregar subcategorias</label>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtSubCategorias" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnAgregarSubCategoria" runat="server" CssClass="btn btn-success" Text="Agregar" />
                                <asp:Button ID="btnCancelarSubCategoria" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
                            </div>
                        </div>
                    </div>
                    <!-- End Form -->
                    <hr>
                    <!-- Table -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Entradas
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <button id="btnOcultarMostar" class="btn btn-primary">Ocultar/Mostrar</button>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered table-hover" id="dt">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>ID</th>
                                                    <th>Titulo</th>
                                                    <th class="ocultar">Descripción</th>
                                                    <th class="ocultar">Imagen</th>
                                                    <th style="display: none;">Contenido</th>
                                                    <th>Creado</th>
                                                    <th>Modificado</th>
                                                    <th>Publicado</th>
                                                    <th class="ocultar">Slug</th>
                                                    <th>Categoria</th>
                                                    <th>SubCategoria</th>
                                                    <th>Status</th>
                                                    <th>Usuario</th>
                                                </tr>
                                            </thead>
                                            <tbody id="dt_body">

                                                <asp:Repeater ID="rpPublicacion" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td><a href="#" class="select">Seleccionar</a></td>
                                                            <td><%# Eval("IdPublicacion") %></td>
                                                            <td><%# Eval("Titulo") %></td>
                                                            <td><%# Eval("Descripcion") %></td>
                                                            <td><%# Eval("Imagen") %></td>
                                                            <td style="display: none;"><%# Eval("Contenido") %></td>
                                                            <td><%# Eval("Creado") %></td>
                                                            <td><%# Eval("Modificado") %></td>
                                                            <td><%# Eval("Publicado") %></td>
                                                            <td><%# Eval("Slug") %></td>
                                                            <td><%# Eval("Categoria") %></td>
                                                            <td><%# Eval("SubCategoria") %></td>
                                                            <td><%# Eval("Estado") %></td>
                                                            <td><%# Eval("IdUsuario") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- End Table -->
                </div>
                <!-- /.container-fluid -->
            </div>
            <!-- /#page-wrapper -->

        </div>

        <!-- modal alertas -->

        <div class="modal" tabindex="-1" role="dialog" id="modalEditar" runat="server" style="overflow-y: auto;">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Modificar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>¿Estas seguro que quieres editar la publicación?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAceptarMod" runat="server" Text="Aceptar" CssClass="btn btn-success" />
                        <asp:Button ID="btnCancelarMod" runat="server" Text="Cancelar" CssClass="btn btn-warning" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal" tabindex="-1" role="dialog" id="modalEliminar" runat="server" style="overflow-y: auto;">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Eliminar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>¿Estas seguro que quieres eliminar la publicación?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAceptarEliminar" runat="server" Text="Aceptar" CssClass="btn btn-success" />
                        <asp:Button ID="btnCancelarEliminar" runat="server" Text="Cancelar" CssClass="btn btn-warning" />
                    </div>
                </div>
            </div>
        </div>



        <!-- MODAL IMAGENES -->

        <div class="modal" tabindex="-1" role="dialog" id="modalImg" >
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Imagenes en el servidor</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body" >
                        <div class="row form-inline">
                            <div class="col-md-12" style="text-align: right;">
                                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
                            </div>
                        </div>
                        <br />
                        <div class="row modal-image" id="divImages">
                            <asp:Repeater ID="rpImgServer" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-4" id='<%# Eval("ALT") %>'>
                                        <a href="#">
                                            <img id='<%# Eval("ID") %>' onclick="copyTextImg('<%# Eval("ID") %>')" style="object-fit: cover; height: 100px; width: 100%;" src='<%# Eval("Ruta") %>' class="img-responsive" alt='<%# Eval("ALT") %>' /></a>
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>


    <!-- jQuery -->
    <script src="js/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu.min.js"></script>

    <!-- DataTables JavaScript -->
    <script src="js/dataTables/jquery.dataTables.min.js"></script>
    <script src="js/dataTables/dataTables.bootstrap.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/startmin.js"></script>

    <!-- Editor de Texto -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.23.0/trumbowyg.min.js"></script>


    <!-- Entradas js ajax -->
    <script src="js/publicacion.js"></script>
    <script src="js/imagenes.js"></script>

    <script>
        $(document).ready(function () {
            $('#txtContenido').trumbowyg();

            function showModal() {
                $("#modalImg").modal('show');
            }

            $(function () {
                $("#btnVerImg").click(function (e) {
                    e.preventDefault();
                    showModal();
                });
            });

            $(document).keypress(function (e) {
                if ($("#modalImg").hasClass('in') && (e.keycode == 13 || e.which == 13)) {
                    alert("Enter is pressed");
                }
            });

            

        });




    </script>

    <script>
        function copyTextImg(elementId) {
            let element = document.getElementById(elementId); //select the element
            let elementText = element.getAttribute('src'); //get the text content from the element
            copyText(elementText); //use the copyText function below
            alertSuccess('Url obtenida con exito!');
        }

        //If you only want to put some Text in the Clipboard just use this function
        // and pass the string to copied as the argument.
        function copyText(text) {
            navigator.clipboard.writeText(text);
        }
    </script>


</body>
</html>
