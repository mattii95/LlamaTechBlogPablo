<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmImages.aspx.cs" Inherits="LlamaTech.web_admin.frmImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="Content-Type" content="text/html" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Admin Panel | Images</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/startmin.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- Sweet Alert -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <!-- Alerts -->
    <script src="../js/alerts.js"></script>

</head>
<body>
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
                <li><a href="../index.aspx" runat="server"><i class="fa fa-home fa-fw"></i>Llamatech</a></li>
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
                        <h1 class="page-header">Imagenes</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <!-- Form -->
                <form method="post" enctype="multipart/form-data" runat="server">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>ID</label>
                                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Width="100px" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Imagen</label>
                                <input type="file" id="fuImg" class="btnn" />
                                <progress id="fileProgress" style="display: none"></progress>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Descripción</label>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Image ID="imgImagen" runat="server" CssClass="img-responsive" />
                                <label id="tamanioImg"></label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" />
                                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-info" Text="Limpiar" />
                            </div>
                        </div>
                    </div>
                </form>
                <!-- End Form -->
                <hr>
                <!-- Table -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Imagenes
                            </div>
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered table-hover" id="dt">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th>ID</th>
                                                <th>Ruta</th>
                                                <th>ALT</th>
                                                <th>Usuario</th>
                                                <th>Link</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rpGrid" runat="server">
                                                <ItemTemplate>
                                                    <tr class="odd gradeX">
                                                        <td><a href="#" class="select">Seleccionar</a></td>
                                                        <td><%# Eval("ID") %></td>
                                                        <td><%# Eval("Ruta") %></td>
                                                        <td><%# Eval("ALT") %></td>
                                                        <td><%# Eval("IdUsuario") %></td>
                                                        <td><a href="<%# Eval("Ruta") %>" target="_blank">Ver imagen</a></td>
                                                        <%--<td><a id="copy">Copiar Url</a></td>--%>
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
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->
    </div>
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

    <!--  -->
    <script src="js/imagenes.js"></script>

    <script>
        $(document).ready(function () {

            $('#dataTables-images').DataTable({
                responsive: true
            });

            $('#dt tbody').on('click', '.select', function  () {

                var id = $(this).closest('tr').find('td:eq(1)').text();
                var ruta = $(this).closest('tr').find('td:eq(2)').text();
                var alt = $(this).closest('tr').find('td:eq(3)').text();

                $('#txtId').val(id);
                $('#imgImagen').prop('src', ruta);
                $('#txtDesc').val(alt);

            });

            //$('#copy').click(function () {
            //    var copyText = $(this).closest('tr').find('td:eq(2)').text();

            //    $("body").append(copyText);
            //    copyText.val($(this).text()).select();
            //    document.execCommand("copy");
            //    copyText.remove();
            //    console.log(copyText);
            //});

        });


    </script>
</body>
</html>
