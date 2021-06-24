var id = null;

$(document).ready(function () {

    $("#txtId").val("");
    $("#txtId").change();

});

$(function () {

    
    $("#txtId").change(function () {
        // MOSTRAR / OCULTAR BOTON BORRAR
        if ($("#txtId").val() == "")
            $("#btnEliminar").hide();
        else {
            $("#btnEliminar").show();
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
        var id = $(this).closest('tr').find('td:eq(1)').text();
        var nombre = $(this).closest('tr').find('td:eq(2)').text();
        var activo = $(this).closest('tr').find('td:eq(3)').text();

        $('#txtId').val(id);
        $("#txtId").change();
        $('#txtCategoria').val(nombre);


        if (activo == 'True') {
            $('#chkStatus').prop('checked', true);
        } else {
            $('#chkStatus').prop('checked', false);
        }


    });

    // GUARDAR CATEGORIA
    $(document).on('click', '#btnGuardar', function (e) {
        e.preventDefault();

        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {

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

    // ELIMINAR Categoria
    $(document).on('click', '#btnEliminar', function (e) {
        e.preventDefault();

        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {
            alertError('Debes seleccionar el ID de una publicación');
        } else {
            showModalEliminar();
        }

    });

    // MODAL EDITAR
    function showModalEditar() {
        $('#modalEditar').modal('show');
        modificar();

    }
    // MODAL ELIMINAR
    function showModalEliminar() {
        $('#modalEliminar').modal('show');
        eliminar();

    }

    // BOTON MODIFICAR
    function modificar() {
        $("#btnAceptarMod").click(function (e) {
            e.preventDefault();
            updateDataAjax();
        });
    }

    // BOTON ELIMINAR
    function eliminar() {
        $("#btnAceptarEliminar").click(function (e) {
            e.preventDefault();
            deletedDataAjax(id);
        });
    }

    function addDataAjax() {
        var status;

        if ($('#chkStatus').prop('checked')) {
            status = true;
        } else {
            status = false;
        }

        var obj = {
            nombre: $("#txtCategoria").val(),
            activo: status
        };

        $.ajax({
            type: "POST",
            url: "frmCategorias.aspx/AgregarCategoria",
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

        var status;

        if ($('#chkStatus').prop('checked')) {
            status = true;
        } else {
            status = false;
        }

        var obj = {
            id: $("#txtId").val(),
            nombre: $("#txtCategoria").val(),
            activo: status
        };

        $.ajax({
            type: "POST",
            url: "frmCategorias.aspx/ModificarCategoria",
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

    function deletedDataAjax(IdCategoria) {
        var obj = {
            id: IdCategoria
        };

        $.ajax({
            type: "POST",
            url: "frmCategorias.aspx/EliminarCategoria",
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('La categoria se elimino exitosamente');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo eliminar la categoria, esta siendo usada en Publicaciones');
                }
            }
        });
    }

    $(document).on('click', '#btnLimpiar', function (e) {
        e.preventDefault();

        limpiar();
        realizarPostBack
    });

    $(document).on('click', '#btnCancelarMod', function (e) {
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

        if ($("#txtCategoria").val() == "") {
            $("#txtCategoria").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtCategoria").css("border", "");
            valido = true;
        }

        return valido;
    }

    // Limpiar campos
    function limpiar() {
        id = "";
        $("#txtId").val("");
        $("#txtId").change();
        $("#txtId").val("");
        $("#txtCategoria").val("");

        $("#txtCategoria").css("border", "");

        $("#btnEliminar").hide();

        $('#modalEditar').modal('hide');
        $('#modalEliminar').modal('hide');


    }

    // recargar página
    function realizarPostBack() {
        location.reload();
    }

});