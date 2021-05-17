var id = null;

$(document).ready(function () {

    $("#txtIdSC").val("");
    $("#txtIdSC").change();

});

$(function () {

    // MOSTRAR / OCULTAR BOTON BORRAR
    if ($("#txtIdSC").val() == "")
        $("#btnEliminarSC").hide();
    else {
        $("#btnEliminarSC").show();
        id = $("#txtId").val();
    }

    $("#txtIdSC").val("");
    $("#txtIdSC").change();

    $('#dtSC').DataTable({
        responsive: true
    });

    $('#dtSC tbody').on('click', '.select', function (e) {
        e.preventDefault();
        var id = $(this).closest('tr').find('td:eq(1)').text();
        var nombre = $(this).closest('tr').find('td:eq(2)').text();
        var categoria = $(this).closest('tr').find('td:eq(3)').text();

        $('#txtIdSC').val(id);
        $("#txtIdSC").change();
        $('#txtSubCategoria').val(nombre);
        $('#ddlCategoria').val(categoria);

        var cbo = document.getElementById('<%=ddlCategoria.ClientID%>');
        for (i = 0; i < cbo.length; i++) {
            if (cbo[i].innerText == categoria)
                $('#<%=ddlCategoria.ClientID%>').val(cbo[i].value);
        }

    });

    // GUARDAR 
    $(document).on('click', '#btnGuardarSC', function (e) {
        e.preventDefault();

        if (id == "" || id == 0 || $("#txtIdSC").val() == "" || $("#txtIdSC").val() == 0) {

            if (validar() == false) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {
                addDataAjax();
            }

        } else {
            showModalEditar();
        }
    });

    // ELIMINAR 
    $(document).on('click', '#btnEliminarSC', function (e) {
        e.preventDefault();

        if (id == "" || id == 0 || $("#txtIdSC").val() == "" || $("#txtIdSC").val() == 0) {
            alertError('Debes seleccionar el ID de una publicación');
        } else {
            showModalEliminar();
        }

    });

    // MODAL EDITAR
    function showModalEditar() {
        $('#modalModSC').modal('show');
        modificar();

    }
    // MODAL ELIMINAR
    function showModalEliminar() {
        $('#modalEliminarSC').modal('show');
        eliminar();

    }

    // BOTON MODIFICAR
    function modificar() {
        $("#btnModSuccessSC").click(function (e) {
            e.preventDefault();
            updateDataAjax();
        });
    }

    // BOTON ELIMINAR
    function eliminar() {
        $("#btnAceptarEliminarSC").click(function (e) {
            e.preventDefault();
            deletedDataAjax(id);
        });
    }

    function addDataAjax() {
        var obj = {
            nombre: $("#txtSubCategoria").val(),
            categoria: $("#ddlCategoria").val()
        };

        $.ajax({
            type: "POST",
            url: "frmCategorias.aspx/AgregarSubCategoria",
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('Registro exitoso');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo realizar el registro');
                }
            }
        });
    }

    function updateDataAjax() {
        var obj = {
            id: $("#txtIdSC").val(),
            nombre: $("#txtSubCategoria").val(),
            categoria: $("#ddlCategoria").val()
        };

        $.ajax({
            type: "POST",
            url: "frmCategorias.aspx/ModificarSubCategoria",
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('Registro actualizado exitosamente');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo realizar el registro');
                }
            }
        });
    }

    function deletedDataAjax(IdSubCategoria) {
        var obj = {
            id: IdSubCategoria
        };

        $.ajax({
            type: "POST",
            url: "frmCategorias.aspx/EliminarSubCategoria",
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('El registro se elimino exitosamente');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo eliminar la subcategoria');
                }
            }
        });
    }

    $(document).on('click', '#btnLimpiarSC', function (e) {
        e.preventDefault();

        limpiar();
        realizarPostBack
    });

    $(document).on('click', '#btnModCancelarSC', function (e) {
        e.preventDefault();

        limpiar();
        realizarPostBack
    });

    $(document).on('click', '#btnCancelarEliminar', function (e) {
        e.preventDefault();

        limpiar();
        realizarPostBack
    });

    // Validar campos
    function validar() {
        var valido;

        if ($("#txtSubCategoria").val() == "") {
            $("#txtSubCategoria").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtSubCategoria").css("border", "");
            valido = true;
        }

        if ($("#ddlCategoria").val() == 0) {
            $("#ddlCategoria").css("border", "2px solid red");
            valido = false;
        } else {
            $("#ddlCategoria").css("border", "");
            valido = true;
        }

        return valido;
    }

    // Limpiar campos
    function limpiar() {
        id = "";
        $("#txtIdSC").val("");
        $("#txtIdSC").change();
        $("#txtSubCategoria").val("");
        $("#ddlCategoria").val(0);

        $("#txtSubCategoria").css("border", "");
        $("#ddlCategoria").css("border", "");

        $("#btnEliminarSC").hide();

        $('#modalModSC').modal('hide');
        $('#modalEliminarSC').modal('hide');


    }

    // recargar página
    function realizarPostBack() {
        location.reload();
    }

});