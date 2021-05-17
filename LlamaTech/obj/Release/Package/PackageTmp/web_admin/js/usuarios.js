var id = null;

$(document).ready(function () {

    $("#txtId").val("");
    $("#txtId").change();

    // VALIDAR CAMPO IMAGEN
    $(document).on("change", "#fileImg", function (e) {

        var fileName = this.files[0].name;
        var fileSize = this.files[0].size;

        var ext = fileName.split('.');

        ext = ext[ext.length - 1];

        switch (ext) {
            case 'jpg':
                readURL(this);
                $('#tamanioImg').text('Tamaño: ' + fileSize + 'KB');
                break;

            case 'jpeg':
                readURL(this);
                $('#tamanioImg').text('Tamaño: ' + fileSize + 'KB');
                break;

            case 'png':
                readURL(this);
                $('#tamanioImg').text('Tamaño: ' + fileSize + 'KB');
                break;

            case 'gif':
                readURL(this);
                $('#tamanioImg').text('Tamaño: ' + fileSize + 'KB');
                break;

            default:
                alertError('Archivo no admitido. Solo imagenes con extenciones: .JPG | .JPEG | .PNG | .GIF');
                this.value = '';
                $('#tamanioImg').text('');
                break;
        }
    });

    // MOSTRAR IMAGEN EN IMGVIEW
    function readURL(input) {

        if (input.files && input.files[0]) {

            var reader = new FileReader();

            reader.onload = function (e) {
                $('#imgUser').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }

    }

});

$(function () {

    $("#txtId").change(function () {
        // MOSTRAR / OCULTAR BOTON BORRAR
        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {
            $("#btnEliminar").hide();
            $("#btnUpdatePass").hide();
        }
        else {
            $("#btnEliminar").show();
            $("#btnUpdatePass").show();
            id = $("#txtId").val();
        }
    });

    $("#txtId").val("");
    $("#txtId").change();

    $('#dt').DataTable({
        responsive: true
    });

    $('#dt tbody').on('click', '.select', function (e) {

        e.preventDefault();

        var idUser = $(this).closest('tr').find('td:eq(1)').text();
        var nombre = $(this).closest('tr').find('td:eq(2)').text();
        var apellido = $(this).closest('tr').find('td:eq(3)').text();
        var telefono = $(this).closest('tr').find('td:eq(4)').text();
        var email = $(this).closest('tr').find('td:eq(5)').text();
        var foto = $(this).closest('tr').find('td:eq(6)').text();
        var rol = $(this).closest('tr').find('td:eq(8)').text();
        var activo = $(this).closest('tr').find('td:eq(9)').text();

        id = idUser;
        $('#txtId').val(idUser);
        $('#txtId').change();
        $('#txtNombre').val(nombre);
        $('#txtApellido').val(apellido);
        $('#txtTelefono').val(telefono);
        $('#txtEmail').val(email);
        $('#imgUser').prop('src', foto);
        $('#ddlRol').val(rol);

        var cbo = document.getElementById('ddlRol');
        for (i = 0; i < cbo.length; i++) {
            if (cbo[i].innerText == rol)
                $('#ddlRol').val(cbo[i].value);
        }

        if (activo == 'True') {
            $('#chkStatus').prop('checked', true);
        } else {
            $('#chkStatus').prop('checked', false);
        }
    });



    // BOTON GUARDAR
    $(document).on("click", "#btnAceptar", function (e) {

        e.preventDefault();

        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {

            if (validar() == false && $("#fileImg").val() == "") {
                $("#fileImg").css("border", "2px solid red");
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {

                $("#fileImg").css("border", "");

                modalGuardar();

            }

        } else {
            showModalEditar();
        }

    });

    // BOTON MODIFICAR CONTRASEÑA
    $(document).on("click", "#btnUpdatePass", function (e) {

        e.preventDefault();

        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {

            alertError('Debes seleccionar el ID de un Usuario');

        } else {
            showModalEditarPass();
        }

    });

    // BOTON ELIMINAR
    $(document).on("click", "#btnEliminar", function (e) {

        e.preventDefault();

        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {

            alertError('Debes seleccionar el ID de un Usuario');

        } else {
            showModalEliminar();
        }

    });

    // MODAL GUARDAR
    function modalGuardar() {
        $('#modalContraseñaGuardar').modal('show');
        guardar();
    }

    // MODAL EDITAR
    function showModalEditar() {
        $('#modalEditar').modal('show');
        editar();
    }

    // MODAL EDITAR CONTRASEÑA
    function showModalEditarPass() {
        $('#modalContraseniaModificar').modal('show');
        editarPass();
    }

    // MODAL ELIMINAR
    function showModalEliminar() {
        $('#modalEliminar').modal('show');
        eliminar();
    }

    function guardar() {
        $("#btnAceptarGuardar").click(function (e) {
            e.preventDefault();

            var password = $("#inputPass").val();
            var passwordRp = $("#inputPassRp").val();

            if (validarPass() == false) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {

                if (password === passwordRp)
                    getEmail($("#txtEmail").val());
                else
                    alertError('Las contraseñas no coinciden.');

            }

        });
    }

    function editar() {
        $("#modalEditar").click(function (e) {
            e.preventDefault();

            if ($("#fileImg").val() != "") {
                if (validar() == false) {
                    alertError('Todos los campos son obligatorios.');
                    return false;
                } else {
                    updateUserAjax();
                }
            } else {
                if (validar() == false) {
                    alertError('Todos los campos son obligatorios.');
                    return false;
                } else {
                    updateUserAjaxSinImagen();
                }
            }


        });
    }

    function editarPass() {
        $("#btnAceptarEditarPass").click(function (e) {
            e.preventDefault();

            var password = $("#inputUpdatePass").val();
            var passwordRp = $("#inputUpdatePassRp").val();

            if (validarUpdatePass() == false) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {

                if (password === passwordRp)
                    updatePassAjax(id, password);
                else
                    alertError('Las contraseñas no coinciden.');
            }
        });
    }

    function eliminar() {
        $("#btnAceptarEliminar").click(function (e) {
            e.preventDefault();

            if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {
                deleteUserAjax(id);
            }
        });
    }

    $("#btnCancelar").click(function (e) {
        e.preventDefault();
        limpiar();
    });

    $("#btnCancelarGuardar").click(function (e) {
        e.preventDefault();
        limpiarContraseña();
    });

    $("#btnAceptarCancelarPass").click(function (e) {
        e.preventDefault();
        limpiarUpdateContraseña();
    });

    $("#btnCancelarMod").click(function (e) {
        e.preventDefault();
        limpiar();
    });

    $("#btnCancelarEliminar").click(function (e) {
        e.preventDefault();
        limpiar();
    });


    // AJAX
    // AGREGAR USUARIO
    function addUserAjax() {

        var formData = new FormData($('form')[0]);
        var fileUpload = $('#fileImg').get(0);
        var files = fileUpload.files;
        var name = $('#txtNombre').val();
        var surname = $('#txtApellido').val();
        var phone = $('#txtTelefono').val();
        var email = $('#txtEmail').val();
        var password = $('#inputPass').val();
        var rol = $('#ddlRol').val();
        var status;

        if ($('#chkStatus').prop('checked')) {
            status = true;
        } else {
            status = false;
        }

        formData.append(files[0].name, files[0]);

        $.ajax({
            url: "../UploadAvatarUser.ashx?name=" + name + "&surname=" + surname + "&phone=" + phone + "&email=" + email + "&password=" + password + "&rol=" + rol + "&status=" + status,
            type: "POST",
            dataType: "json",
            data: formData,
            contentType: false,
            processData: false,
            complete: function (res) {
                if (res) {
                    alertSuccess('Registro actualizado con exito');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo realizar la actulización');
                }
            }
        });

    }

    // MODIFICAR USUARIO 
    function updateUserAjax() {
        var formData = new FormData($('form')[0]);
        var fileUpload = $('#fileImg').get(0);
        var files = fileUpload.files;
        var id = $('#txtId').val();
        var name = $('#txtNombre').val();
        var surname = $('#txtApellido').val();
        var phone = $('#txtTelefono').val();
        var email = $('#txtEmail').val();
        var rol = $('#ddlRol').val();
        var status;

        if ($('#chkStatus').prop('checked')) {
            status = true;
        } else {
            status = false;
        }

        formData.append(files[0].name, files[0]);

        $.ajax({
            url: "../UpdateAvatarUser.ashx?id=" + id + "&name=" + name + "&surname=" + surname + "&phone=" + phone + "&email=" + email + "&rol=" + rol + "&status=" + status,
            type: "POST",
            dataType: "json",
            data: formData,
            contentType: false,
            processData: false,
            complete: function () {
                alertSuccess('El usuario fue modificado con exito!');
                limpiar();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            }
        });
    }

    // MODIFICAR USUARIO SIN IMAGEN
    function updateUserAjaxSinImagen() {

        var status;

        if ($('#chkStatus').prop('checked')) {
            status = true;
        } else {
            status = false;
        }

        var obj = {
            id: $('#txtId').val(),
            nombre: $('#txtNombre').val(),
            apellido: $('#txtApellido').val(),
            telefono: $('#txtTelefono').val(),
            email: $('#txtEmail').val(),
            rol: $('#ddlRol').val(),
            status: status
        };

        $.ajax({
            type: "POST",
            url: "frmUsuarios.aspx/ModificarUsuarioSinImagen",
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('Registro actualizado con exito');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo realizar la actulización');
                }
            }
        });
    }

    // MODIFICAR CONTRASEÑA
    function updatePassAjax(id, password) {

        var obj = {
            id: id,
            pass: password
        };

        $.ajax({
            type: "POST",
            url: "frmUsuarios.aspx/UpdatePassword",
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('Contraseña actualizada con exito');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo realizar la actulización');
                }
            }
        });

    }

    // ELIMINAR USUARIO
    function deleteUserAjax(id) {

        var obj = { id: id };

        $.ajax({
            url: 'frmUsuarios.aspx/Eliminar',
            type: 'POST',
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('Usuario eliminado con exito');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo eliminar el usuario');
                }
            }

        });

    }

    // BUSCAR EMAIL
    function getEmail(email) {
        var obj = { email: email };

        $.ajax({
            url: 'frmUsuarios.aspx/GetEmail',
            type: 'POST',
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var val = data.d;
                val = val.replace("[]", "");
                if (val) {
                    //Si existe la imagen
                    alertError('El email ya existe en el servidor');

                } else {
                    //Si no existe la imagen
                    addUserAjax();
                }
            }

        });
    }

    // VALIDAR CAMPOS
    function validar() {
        var valido;

        if ($("#ddlRol").val().trim() == "0") {
            $("#ddlRol").css("border", "2px solid red");
            valido = false;
        } else {
            $("#ddlRol").css("border", "");
            valido = true;
        }

        if ($("#txtNombre").val() == "") {
            $("#txtNombre").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtNombre").css("border", "");
            valido = true;
        }

        if ($("#txtApellido").val() == "") {
            $("#txtApellido").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtApellido").css("border", "");
            valido = true;
        }

        if ($("#txtTelefono").val() == "") {
            $("#txtTelefono").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtTelefono").css("border", "");
            valido = true;
        }

        if ($("#txtEmail").val() == "") {
            $("#txtEmail").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtEmail").css("border", "");
            valido = true;
        }



        return valido;
    }

    function validarPass() {
        var valido;

        if ($("#inputPass").val() == "") {
            $("#inputPass").css("border", "2px solid red");
            valido = false;
        } else {
            $("#inputPass").css("border", "");
            valido = true;
        }

        if ($("#inputPassRp").val() == "") {
            $("#inputPassRp").css("border", "2px solid red");
            valido = false;
        } else {
            $("#inputPassRp").css("border", "");
            valido = true;
        }

        return valido;
    }

    function validarUpdatePass() {

        var valido;

        if ($("#inputUpdatePass").val() == "") {
            $("#inputUpdatePass").css("border", "2px solid red");
            valido = false;
        } else {
            $("#inputUpdatePass").css("border", "");
            valido = true;
        }

        if ($("#inputUpdatePassRp").val() == "") {
            $("#inputUpdatePassRp").css("border", "2px solid red");
            valido = false;
        } else {
            $("#inputUpdatePassRp").css("border", "");
            valido = true;
        }

        return valido;

    }

    // LIMPIAR CAMPOS
    function limpiar() {
        id = "";
        $("#txtId").val("");
        $("#txtId").change();
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtEmail").val("");
        $("#txtTelefono").val("");
        $("#ddlCategoria").val(0);
        $("#fileImg").val("");
        $("#imgUser").prop("src", "");

        $("#btnEliminar").hide();
        $("#btnUpdatePass").hide();

        $("#txtNombre").css("border", "");
        $("#txtApellido").css("border", "");
        $("#txtEmail").css("border", "");
        $("#txtTelefono").css("border", "");
        $("#ddlCategoria").css("border", "");

        $('#modalContraseñaGuardar').modal('hide');
        $('#modalEliminar').modal('hide');
        $('#modalEditar').modal('hide');

    }

    function limpiarContraseña() {

        $("#inputPass").val("");
        $("#inputPassRp").val("");

        $("#inputPass").css("border", "");
        $("#inputPassRp").css("border", "");

        $('#modalContraseñaGuardar').modal('hide');
    }

    function limpiarUpdateContraseña() {

        $("#inputUpdatePass").val("");
        $("#inputUpdatePassRp").val("");

        $("#inputUpdatePass").css("border", "");
        $("#inputUpdatePassRp").css("border", "");

        $('#modalContraseniaModificar').modal('hide');
    }


    // recargar página
    function realizarPostBack() {
        location.reload();

    }

});