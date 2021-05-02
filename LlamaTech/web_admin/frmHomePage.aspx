<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHomePage.aspx.cs" Inherits="LlamaTech.web_admin.frmHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="Content-Type" content="text/html" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Admin Panel | Home Page</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/startmin.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- Editor de texto -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Trumbowyg/2.23.0/ui/trumbowyg.min.css" />

    <!-- Sweet Alert -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <script src="../js/alerts.js"></script>

</head>
<body>
    <form id="form1" runat="server">
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
                            <i class="fa fa-user fa-fw"></i>
                            <asp:Label ID="lblUser" runat="server" Text=""></asp:Label> <b class="caret"></b>
                        </a>
                        <ul class="dropdown-menu dropdown-user">
                            <li>
                                <asp:Button ID="btnCerrarSesion" CssClass="btn btn-link" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
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

            <!-- Page Content -->
            <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">About Us</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <!-- Form -->
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Titulo</label>
                                <asp:Label ID="txtId" runat="server" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Descripcion</label>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Logo</label>
                                <asp:FileUpload ID="fileLogo" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Imagen Background</label>
                                <asp:FileUpload ID="fileBg" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Image ID="imgLogo" CssClass="img-responsive" Width="150px" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Image ID="imgBg" CssClass="img-responsive" Width="150px" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <input type="button" id="btnModificar" class="btn btn-warning" value="Modificar" />
                                <asp:Button ID="btnModificarAbout" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnModificarAbout_Click" />
                                <asp:Button ID="btnCancelarAbout" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
                            </div>
                        </div>
                    </div>
                    <!-- End Form -->
                </div>
                <!-- /.container-fluid -->

                <!-- CONTACTO -->
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Contacto</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <!-- Form -->
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>ID</label>
                                <asp:TextBox ID="txtIdContacto" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Contacto</label>
                                <asp:TextBox ID="txtDescContacto" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Icono</label>
                                <asp:DropDownList ID="ddlIconoContacto" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Button ID="btnGuardarContacto" runat="server" CssClass="btn btn-success" Text="Guardar" />
                                <asp:Button ID="btnEliminarContacto" runat="server" CssClass="btn btn-danger" Text="Eliminar" />
                                <asp:Button ID="btnCancelarContacto" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
                                <asp:Button ID="btnLimpiarContacto" runat="server" CssClass="btn btn-info" Text="Limpiar" />
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
                                    Contacto
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered table-hover" id="dtContacto">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>ID</th>
                                                    <th>Contacto</th>
                                                    <th>Icono</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rpContacto" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td><a href="#" class="select">Seleccionar</a></td>
                                                            <td><%# Eval("IdContacto") %></td>
                                                            <td><%# Eval("Nombre") %></td>
                                                            <td><%# Eval("Icono") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- /.table-responsive -->
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- End Table -->
                </div>

                <!-- REDES SOCIALES -->
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Redes Sociales</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <!-- Form -->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>ID</label>
                                <asp:TextBox ID="txtIdrs" runat="server" CssClass="form-control" Width="150px" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Red Social</label>
                                <asp:TextBox ID="txtRS" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>URL</label>
                                <asp:TextBox ID="txtURL" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Icono</label>
                                <asp:DropDownList ID="ddlIcon" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Status</label>
                                <input type="checkbox" name="status" value="¿Quieres que aparezca la red social en la página?" class="checkbox" id="chkStatus"/>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Button ID="btnGuardarRS" runat="server" CssClass="btn btn-success" Text="Guardar" />
                                <asp:Button ID="btnEliminarRS" runat="server" CssClass="btn btn-danger" Text="Eliminar" />
                                <asp:Button ID="btnLimpiarRS" runat="server" CssClass="btn btn-info" Text="Limpiar" />
                                <asp:Button ID="btnCancelarRS" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
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
                                    Redes Sociales 
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered table-hover" id="dtRs">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>ID</th>
                                                    <th>Red Social</th>
                                                    <th>URL</th>
                                                    <th>Icono</th>
                                                    <th>Status</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rpRS" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td><a href="#" class="select">Seleccionar</a></td>
                                                            <td><%# Eval("IdRedSocial") %></td>
                                                            <td><%# Eval("Nombre") %></td>
                                                            <td><%# Eval("Url") %></td>
                                                            <td><%# Eval("Icono") %></td>
                                                            <td><%# Eval("Activo") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- /.table-responsive -->
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- End Table -->
                </div>
            </div>
            <!-- /#page-wrapper -->


            <!-- Modal Alerta editar about us -->
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
                            <p>¿Estas seguro que quieres editar?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAceptarMod" runat="server" Text="Aceptar" CssClass="btn btn-success" />
                            <asp:Button ID="btnCancelarMod" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- End modal Alerta editar about us -->

            <!-- Modal Alerta editar Contacto / Red social -->
            <div class="modal" tabindex="-1" role="dialog" id="modalEditarCR" runat="server" style="overflow-y: auto;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Modificar</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>¿Estas seguro que quieres editar?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAceptarModCR" runat="server" Text="Aceptar" CssClass="btn btn-success" />
                            <asp:Button ID="btnCancelarModCR" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal" tabindex="-1" role="dialog" id="modalEditarRS" runat="server" style="overflow-y: auto;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Modificar</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>¿Estas seguro que quieres editar?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAceptarModRS" runat="server" Text="Aceptar" CssClass="btn btn-success" />
                            <asp:Button ID="btnCancelarModRS" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- End modal Alerta editar Contacto / Red social -->

            <!-- Modal Alerta eliminar Contacto / Red Social -->
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

            <div class="modal" tabindex="-1" role="dialog" id="modalEliminarRS" runat="server" style="overflow-y: auto;">
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
                            <asp:Button ID="btnAceptarEliminarRS" runat="server" Text="Aceptar" CssClass="btn btn-success" />
                            <asp:Button ID="btnCancelarEliminarRS" runat="server" Text="Cancelar" CssClass="btn btn-warning" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Modal Alerta Eliminar -->

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


    <script src="js/homePage.js"></script>
</body>
</html>
