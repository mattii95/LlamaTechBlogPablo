<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LlamaTech.web_admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
</head>
<body style="background: url(../images/bg-llamatech.jpg) no-repeat center center fixed; background-size: cover;">
    <form id="form1" runat="server" >
        <div class="container" >
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <img src="../images/LlamaTech_Alpha.png" class="img-responsive" />
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Iniciar Sesión</h3>
                        </div>
                        <div class="panel-body">
                            <div role="form">
                                <fieldset>
                                    <div class="form-group">
                                        <label>Email:</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Contraseña:</label>
                                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"  TextMode="Password"></asp:TextBox>
                                    </div>
                                    <!-- Change this to a button or input when using this as a form -->
                                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-success" Width="100%" OnClick="btnLogin_Click" />
                                    <asp:Label ID="lblError" runat="server" Text="Error" CssClass="text-danger"></asp:Label>
                                </fieldset>
                            </div>
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
</body>
</html>
