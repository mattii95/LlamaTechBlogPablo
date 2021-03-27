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
    <!-- Alerts -->
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
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>ID</label>
                                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Titulo</label>
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
                                <asp:Button ID="btnModificarAbout" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificarAbout_Click" />
                                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-info" Text="Limpiar" />
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
                                    About Us
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered table-hover" id="dtAbout">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>ID</th>
                                                    <th>Titulo</th>
                                                    <th>Descripcion</th>
                                                    <th>Logo</th>
                                                    <th>ImagenFondo</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rpAbout" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td><a href="#" class="select">Seleccionar</a></td>
                                                            <td><%# Eval("ID") %></td>
                                                            <td><%# Eval("Titulo") %></td>
                                                            <td><%# Eval("Descripcion") %></td>
                                                            <td><%# Eval("Logo") %></td>
                                                            <td><%# Eval("ImagenFondo") %></td>
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
                                <asp:TextBox ID="txtIdContacto" runat="server" CssClass="form-control"></asp:TextBox>
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
                                <asp:Button ID="btnAgregarContacto" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregarContacto_Click" />
                                <asp:Button ID="btnModificarContacto" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificarContacto_Click" />
                                <asp:Button ID="btnEliminarContacto" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminarContacto_Click" />
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
                                <asp:TextBox ID="txtIdrs" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
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
                                <asp:CheckBox ID="chkStatus" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Button ID="btnAgregarRS" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregarRS_Click" />
                                <asp:Button ID="btnModificarRS" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificarRS_Click" />
                                <asp:Button ID="btnEliminarRS" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminarRS_Click" />
                                <asp:Button ID="btnLimpiarRS" runat="server" CssClass="btn btn-info" Text="Limpiar" />
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

    <script>
        $(document).ready(function () {
            $('#dtAbout').DataTable({
                responsive: true
            });
            $('#dtContacto').DataTable({
                responsive: true
            });
            $('#dtRs').DataTable({
                responsive: true
            });

            $('#dtAbout tbody').on('click', '.select', function () {
                var id = $(this).closest('tr').find('td:eq(1)').text();
                var titulo = $(this).closest('tr').find('td:eq(2)').text();
                var descripcion = $(this).closest('tr').find('td:eq(3)').text();
                var logo = $(this).closest('tr').find('td:eq(4)').text();
                var bg = $(this).closest('tr').find('td:eq(5)').text();

                $('#txtId').val(id);
                $('#txtTitulo').val(titulo);
                $('#txtDesc').val(descripcion);
                $('#imgLogo').prop('src', logo);
                $('#imgBg').prop('src', bg);

            });

            $('#dtContacto tbody').on('click', '.select', function () {
                var id = $(this).closest('tr').find('td:eq(1)').text();
                var contacto = $(this).closest('tr').find('td:eq(2)').text();
                var icono = $(this).closest('tr').find('td:eq(3)').text();

                $('#txtIdContacto').val(id);
                $('#txtDescContacto').val(contacto);
                $('#ddlIconoContacto').val(icono);

                var cbo = document.getElementById('<%=ddlIconoContacto.ClientID%>');
                for (i = 0; i < cbo.length; i++) {
                    if (cbo[i].innerText == icono)
                        $('#<%=ddlIconoContacto.ClientID%>').val(cbo[i].value);
                }

            });

            $('#dtRs tbody').on('click', '.select', function () {
                var id = $(this).closest('tr').find('td:eq(1)').text();
                var nombre = $(this).closest('tr').find('td:eq(2)').text();
                var url = $(this).closest('tr').find('td:eq(3)').text();
                var icono = $(this).closest('tr').find('td:eq(4)').text();
                var activo = $(this).closest('tr').find('td:eq(5)').text();

                $('#txtIdrs').val(id);
                $('#txtRS').val(nombre);
                $('#txtURL').val(url);
                $('#ddlIcon').val(icono);
                $('#chkStatus').val(activo);

                var cbo = document.getElementById('<%=ddlIcon.ClientID%>');
                for (i = 0; i < cbo.length; i++) {
                    if (cbo[i].innerText == icono)
                        $('#<%=ddlIcon.ClientID%>').val(cbo[i].value);
                }

                if (activo == 'True') {
                    $('#chkStatus').prop('checked', true);
                } else {
                    $('#chkStatus').prop('checked', false);
                }

            });
        });
    </script>
</body>
</html>
