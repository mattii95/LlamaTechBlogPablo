$(document).ready(function () {
    $("#txtTitulo").prop("disabled", true);
    $("#txtDesc").prop("disabled", true);
    $("#fileLogo").prop("disabled", true);
    $("#fileBg").prop("disabled", true);
    $("#btnModificarAbout").hide();
    $("#btnCancelarAbout").hide();
    $("#btnModificar").show();

    $("#btnModificar").click(function (e) {
        e.preventDefault();
        showModalEditar();
    });

    $("#btnCancelarAbout").click(function (e) {
        e.preventDefault();
        LimpiarCamposAbout();
    });

    // MODAL ACEPTAR EDITAR
    function showModalEditar() {
        $('#modalEditar').modal('show');
        modificar();
    }

    function modificar() {
        $("#btnAceptarMod").click(function (e) {
            e.preventDefault();
            $("#txtTitulo").prop("disabled", false);
            $("#txtDesc").prop("disabled", false);
            $("#fileLogo").prop("disabled", false);
            $("#fileBg").prop("disabled", false);
            $("#btnModificarAbout").show();
            $("#btnCancelarAbout").show();
            $("#btnModificar").hide();
            $('#modalEditar').modal('hide');
        });
    }

    $("#btnCancelarMod").click(function (e) {
        e.preventDefault();
        LimpiarCamposAbout();
    });

});

var idContacto = null;
var idRs = null;

$(function () {

    // CONTACTO

    // MOSTRAR - OCULTAR BOTONES ELIMINAR Y LIMPIAR
    $("#txtIdContacto").change(function () {
        // MOSTRAR / OCULTAR BOTON BORRAR
        if ($("#txtIdContacto").val() == "") {
            $("#btnEliminarContacto").hide();
            $("#btnCancelarContacto").hide();
            $("#btnLimpiarContacto").show();
        }
        else {
            $("#btnEliminarContacto").show();
            $("#btnCancelarContacto").show();
            $("#btnLimpiarContacto").hide();
            idContacto = $("#txtIdContacto").val();
        }
    });

    $("#txtIdContacto").val("");
    $("#txtIdContacto").change();

    $('#dtContacto').DataTable({
        responsive: true
    });

    $('#dtContacto tbody').on('click', '.select', function (e) {
        e.preventDefault();

        var id = $(this).closest('tr').find('td:eq(1)').text();
        var contacto = $(this).closest('tr').find('td:eq(2)').text();
        var icono = $(this).closest('tr').find('td:eq(3)').text();

        $('#txtIdContacto').val(id);
        $('#txtIdContacto').change();
        $('#txtDescContacto').val(contacto);
        $('#ddlIconoContacto').val(icono);

        var cbo = document.getElementById('ddlIconoContacto');
        for (i = 0; i < cbo.length; i++) {
            if (cbo[i].innerText == icono)
                $('#ddlIconoContacto').val(cbo[i].value);
        }

    });

    // GUARDAR CONTACTO
    $(document).on('click', '#btnGuardarContacto', function (e) {
        e.preventDefault();

        if (idContacto == "" || idContacto == null) {
            if (validar() == false) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else
                addContacto();
        } else
            ModalEditarCR();

    });

    // ELIMINAR CONTACTO
    $(document).on('click', '#btnEliminarContacto', function (e) {
        e.preventDefault();
        showModalEliminar();
    });

    function showModalEliminar() {
        $('#modalEliminar').modal('show');
        eliminar();

    }

    // BOTON ELIMINAR CONTACTO
    function eliminar() {
        $("#btnAceptarEliminar").click(function (e) {
            e.preventDefault();
            deleteContacto(idContacto);
        });
    }

    $("#btnCancelarEliminar").click(function (e) {
        e.preventDefault();
        LimpiarCamposContacto();
    });


    // CANCELAR - LIMPIAR
    $("#btnLimpiarContacto").click(function (e) {
        e.preventDefault();
        LimpiarCamposContacto();
    });

    $("#btnCancelarContacto").click(function (e) {
        e.preventDefault();
        LimpiarCamposContacto();
    });


    // MODAL ALERTA EDITAR CONTACTO 
    function ModalEditarCR() {
        $("#modalEditarCR").modal("show");
        modificarContacto();
    }

    // BOTON ALERTA MODIFICAR
    function modificarContacto() {
        $("#btnAceptarModCR").click(function (e) {
            e.preventDefault();
            updateContacto();
        });
    }

    $("#btnCancelarModCR").click(function (e) {
        e.preventDefault();
        LimpiarCamposContacto();
    });


    // REDES SOCIALES

    // MOSTRAR - OCULTAR BOTONES ELIMINAR Y LIMPIAR
    $("#txtIdrs").change(function () {
        // MOSTRAR / OCULTAR BOTON BORRAR
        if ($("#txtIdrs").val() == "") {
            $("#btnEliminarRS").hide();
            $("#btnCancelarRS").hide();
            $("#btnLimpiarRS").show();
        }
        else {
            $("#btnEliminarRS").show();
            $("#btnCancelarRS").show();
            $("#btnLimpiarRS").hide();
            idRs = $("#txtIdrs").val();
        }
    });

    $("#txtIdrs").val("");
    $("#txtIdrs").change();

    $('#dtRs').DataTable({
        responsive: true
    });

    $('#dtRs tbody').on('click', '.select', function (e) {

        e.preventDefault();

        var id = $(this).closest('tr').find('td:eq(1)').text();
        var nombre = $(this).closest('tr').find('td:eq(2)').text();
        var url = $(this).closest('tr').find('td:eq(3)').text();
        var icono = $(this).closest('tr').find('td:eq(4)').text();
        var activo = $(this).closest('tr').find('td:eq(5)').text();

        $('#txtIdrs').val(id);
        $("#txtIdrs").change();
        $('#txtRS').val(nombre);
        $('#txtURL').val(url);
        $('#ddlIcon').val(icono);
        $('#chkStatus').val(activo);

        var cbo = document.getElementById('ddlIcon');
        for (i = 0; i < cbo.length; i++) {
            if (cbo[i].innerText == icono)
                $('#ddlIcon').val(cbo[i].value);
        }

        if (activo == 'True') {
            $('#chkStatus').prop('checked', true);
        } else {
            $('#chkStatus').prop('checked', false);
        }

    });

    // GUARDAR REDES SOCIALES
    $(document).on('click', '#btnGuardarRS', function (e) {
        e.preventDefault();

        if (idRs == "" || idRs == null) {
            if (validarRS() == false) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else
                addRedSocial();
        } else
            ModalEditarRS();

    });

    // ELIMINAR REDES SOCIALES
    $(document).on('click', '#btnEliminarRS', function (e) {
        e.preventDefault();
        showModalEliminarRS();
    });

    function showModalEliminarRS() {
        $('#modalEliminarRS').modal('show');
        eliminarrs();

    }

    // BOTON REDES SOCIALES CONTACTO
    function eliminarrs() {
        $("#btnAceptarEliminarRS").click(function (e) {
            e.preventDefault();
            deleteRedSocial(idRs);
        });
    }

    $("#btnCancelarEliminarRS").click(function (e) {
        e.preventDefault();
        LimpiarCamposRedSocial();
    });


    // CANCELAR - LIMPIAR
    $("#btnLimpiarRS").click(function (e) {
        e.preventDefault();
        LimpiarCamposRedSocial();
    });

    $("#btnCancelarRS").click(function (e) {
        e.preventDefault();
        LimpiarCamposRedSocial();
    });


    // MODAL ALERTA EDITAR REDES SOCIALES
    function ModalEditarRS() {
        $("#modalEditarRS").modal("show");
        modificarRS();
    }

    // BOTON ALERTA MODIFICAR
    function modificarRS() {
        $("#btnAceptarModRS").click(function (e) {
            e.preventDefault();
            updateRedSocial();
        });
    }

    $("#btnCancelarModRS").click(function (e) {
        e.preventDefault();
        LimpiarCamposRedSocial();
    });

});




// AJAX ADD CONTACTO
function addContacto() {
    var obj = {
        nombre: $("#txtDescContacto").val(),
        icono: $("#ddlIconoContacto option:selected").val()
    }

    $.ajax({
        type: "POST",
        url: "frmHomePage.aspx/AgregarContacto",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (res) {
            if (res.d) {
                alertSuccess('Registro exitoso');
                LimpiarCamposContacto();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            } else {
                alertError('No se pudo realizar el registro');
            }
        }
    });

}

// AJAX UPDATE CONTACTO
function updateContacto() {
    var obj = {
        id: $("#txtIdContacto").val(),
        nombre: $("#txtDescContacto").val(),
        icono: $("#ddlIconoContacto option:selected").val()
    }

    $.ajax({
        type: "POST",
        url: "frmHomePage.aspx/ActualizarContacto",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (res) {
            if (res.d) {
                alertSuccess('Actualizacion exitosa');
                LimpiarCamposContacto();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            } else {
                alertError('No se pudo actualizar el registro');
            }
        }
    });

}

// AJAX DELETE CONTACTO
function deleteContacto(id) {
    var obj = {
        id: id
    }

    $.ajax({
        type: "POST",
        url: "frmHomePage.aspx/DeleteContacto",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (res) {
            if (res.d) {
                alertSuccess('Registro eliminado con exito.');
                LimpiarCamposContacto();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            } else {
                alertError('No se pudo eliminar el registro');
            }
        }
    });

}

// AJAX ADD REDES SOCIALES
function addRedSocial() {
    var obj = {
        nombre: $("#txtRS").val(),
        url: $("#txtRS").val(),
        icono: $("#ddlIcon option:selected").val(),
        status: $("#chkStatus").prop("checked"),
    }

    $.ajax({
        type: "POST",
        url: "frmHomePage.aspx/AgregarRedSocial",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (res) {
            if (res.d) {
                alertSuccess('Registro exitoso');
                LimpiarCamposRedSocial();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            } else {
                alertError('No se pudo realizar el registro');
            }
        }
    });

}

// AJAX UPDATE REDES SOCIALES
function updateRedSocial() {
    var obj = {
        id: $("#txtIdrs").val(),
        nombre: $("#txtRS").val(),
        url: $("#txtURL").val(),
        icono: $("#ddlIcon option:selected").val(),
        status: $("#chkStatus").prop("checked"),
    }

    $.ajax({
        type: "POST",
        url: "frmHomePage.aspx/ModificarRedSocial",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (res) {
            if (res.d) {
                alertSuccess('Actualizacion exitosa');
                LimpiarCamposContacto();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            } else {
                alertError('No se pudo actualizar el registro');
            }
        }
    });

}

// AJAX DELETE REDES SOCIALES
function deleteRedSocial(id) {
    var obj = {
        id: id
    }

    $.ajax({
        type: "POST",
        url: "frmHomePage.aspx/EliminarRedSocial",
        data: JSON.stringify(obj),
        dataType: "json",
        contentType: 'application/json;charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (res) {
            if (res.d) {
                alertSuccess('Registro eliminado con exito.');
                LimpiarCamposRedSocial();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            } else {
                alertError('No se pudo eliminar el registro');
            }
        }
    });

}


// LIMPIAR CAMPOS 'ABOUT US'
function LimpiarCamposAbout() {
    $("#txtTitulo").prop("disabled", true);
    $("#txtDesc").prop("disabled", true);
    $("#fileLogo").prop("disabled", true);
    $("#fileBg").prop("disabled", true);
    $("#btnModificarAbout").hide();
    $("#btnCancelarAbout").hide();
    $("#btnModificar").show();
}

// LIMPIAR CAMPOS 'CONTACTO'
function LimpiarCamposContacto() {
    idContacto = "";
    $("#txtIdContacto").val("");
    $("#txtIdContacto").change();
    $("#txtDescContacto").val("");
    $("#txtDescContacto").css("border", "");
    $("#ddlIconoContacto").val(1);
    $("#ddlIconoContacto").css("border", "");
}

// LIMPIAR CAMPOS 'RED SOCIAL'
function LimpiarCamposRedSocial() {
    idRs = "";
    $("#txtIdrs").val("");
    $("#txtIdrs").change();
    $("#txtRS").val("");
    $("#txtRS").css("border", "");
    $("#txtURL").val("");
    $("#txtURL").css("border", "");
    $("#ddlIcon").val(1);
    $("#chkStatus").prop("checked", true);
    $("#modalEditarRS").hide();
}

// VALIDAR CAMPOS 'CONTACTO'
function validar() {
    var valido;

    if ($("#txtDescContacto").val() == "") {
        $("#txtDescContacto").css("border", "2px solid red");
        valido = false;
    } else {
        $("#txtDescContacto").css("border", "");
        valido = true;
    }

    if ($("#ddlIconoContacto").val() == "") {
        $("#ddlIconoContacto").css("border", "2px solid red");
        valido = false;
    } else {
        $("#ddlIconoContacto").css("border", "");
        valido = true;
    }

    return valido;
}


// VALIDAR CAMPOS 'RED SOCIAL'
function validarRS() {
    var valido;

    if ($("#txtRS").val() == "") {
        $("#txtRS").css("border", "2px solid red");
        valido = false;
    } else {
        $("#txtRS").css("border", "");
        valido = true;
    }

    if ($("#txtURL").val() == "") {
        $("#txtURL").css("border", "2px solid red");
        valido = false;
    } else {
        $("#txtURL").css("border", "");
        valido = true;
    }

    return valido;
}

// recargar página
function realizarPostBack() {
    location.reload();
}