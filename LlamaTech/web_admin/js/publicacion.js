
var path = null;
var id = null;
$(function () {

    $("#txtId").change(function () {
        // MOSTRAR / OCULTAR BOTON BORRAR
        if ($("#txtId").val() == "")
            $("#btnEliminarPost").hide();
        else { 
            $("#btnEliminarPost").show();
            id = $("#txtId").val();
        }
    });

    $("#txtId").val("");
    $("#txtId").change();

    $('#dt').DataTable({
        responsive: true
    });

    $('.ocultar').hide();
    $('td:nth-child(4)').hide();
    $('td:nth-child(5)').hide();
    $('td:nth-child(6)').hide();
    $('td:nth-child(10)').hide();

    $('#btnOcultarMostar').on('click', function (e) {
        e.preventDefault();
        $('.ocultar').toggle();
        $('td:nth-child(4)').toggle();
        $('td:nth-child(5)').toggle();
        $('td:nth-child(10)').toggle();
    });

    $('#dt tbody').on('click', '.select', function () {

        var id = $(this).closest('tr').find('td:eq(1)').text();
        var titulo = $(this).closest('tr').find('td:eq(2)').text();
        var descripcion = $(this).closest('tr').find('td:eq(3)').text();
        var imagen = $(this).closest('tr').find('td:eq(4)').text();
        var contenido = $(this).closest('tr').find('td:eq(5)').html();
        var creado = $(this).closest('tr').find('td:eq(6)').text();
        var modificado = $(this).closest('tr').find('td:eq(7)').text();
        var publicado = $(this).closest('tr').find('td:eq(8)').text();
        var slug = $(this).closest('tr').find('td:eq(9)').text();
        var categoria = $(this).closest('tr').find('td:eq(10)').text();
        var subcategoria = $(this).closest('tr').find('td:eq(11)').text();
        var activo = $(this).closest('tr').find('td:eq(12)').text();
        var usuario = $(this).closest('tr').find('td:eq(13)').text();

        $('#txtId').val(id);
        $('#txtId').change();
        $('#txtTitulo').val(titulo);
        $('#txtDescripcion').val(descripcion);
        $('#txtImgPortada').val(imagen);
        $('#imgPortada').prop('src', imagen);
        $('#txtContenido').trumbowyg('html', contenido);
        $('#txtSlug').val(slug);
        $('#ddlCateg').val(categoria);
        $('#ddlSubCategoria').val(subcategoria);
        $('#ddlEstado').val(activo);

        var cboStatus = document.getElementById('ddlEstado');
        for (i = 0; i < cboStatus.length; i++) {
            if (cboStatus[i].innerText == activo)
                $('#ddlEstado').val(cboStatus[i].value);
        }

        var cbo = document.getElementById('ddlCateg');
        var ddlSC = document.getElementById('ddlSubCategoria')
        for (i = 0; i < cbo.length; i++) {
            if (cbo[i].innerText == categoria) {
                $('#ddlCateg').val(cbo[i].value);
                llenarSubCategorias(cbo[i].value)
                return true;
            }
            for (j = 0; j < ddlSC.length; j++) {
                if (ddlSC[j].innerText == subcategoria) {
                    $('#ddlSubCategoria').val(ddlSC[j].value);
                    llenarSubCategorias(ddlSC[j].value)
                    return true;
                }
            }
        }


    });

    var ddlCategoria = $("#ddlCateg");
    var ddlSubCategoria = $("#ddlSubCategoria");

    // GUARDAR POST
    $(document).on('click', '#btnGuardarPost', function (e) {
        e.preventDefault();

        if (id == "") {

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

    // ELIMINAR POST
    $(document).on('click', '#btnEliminarPost', function (e) {
        e.preventDefault();

        if (id == "") {
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
            deleteDataAjax(id);
        });
    }

    // AJAX AGREGAR POST
    function addDataAjax() {
        var obj = {
            titulo: $("#txtTitulo").val(),
            descripcion: $("#txtDescripcion").val(),
            imagen: $("#txtImgPortada").val(),
            contenido: $("#txtContenido").val(),
            status: $("#ddlEstado").val(),
            subcategoria: $("#ddlSubCategoria option:selected").text(),
            categoria: $('#ddlCateg').val(),
            slug: $("#txtSlug").val()
        };

        $.ajax({
            type: "POST",
            url: "post.aspx/AgregarEntradas",
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

    // AJAX MODIFICAR POST
    function updateDataAjax() {

        var obj = {
            id: $("#txtId").val(),
            titulo: $("#txtTitulo").val(),
            descripcion: $("#txtDescripcion").val(),
            imagen: $("#txtImgPortada").val(),
            contenido: $("#txtContenido").val(),
            status: $("#ddlEstado").val(),
            slug: $("#txtSlug").val(),
            subcategoria: $("#ddlSubCategoria").text(),
            categoria: $('#ddlCateg').val(),
            status: $("#ddlEstado").val()
        };

        $.ajax({
            type: "POST",
            url: "post.aspx/ActualizarEntradas",
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
                    alertError('No se pudo realizar la actulización');
                }
            }
        });
    }

    // AJAX ELIMINAR POST
    function deleteDataAjax(idPublicacion) {

        var obj = { id: idPublicacion };

        $.ajax({
            type: "POST",
            url: "post.aspx/EliminarEntrada",
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: 'application/json;charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
            },
            success: function (res) {
                if (res.d) {
                    alertSuccess('Registro eliminado exitosamente');
                    limpiar();
                    setTimeout(function () {
                        realizarPostBack();
                    }, 1500);
                } else {
                    alertError('No se pudo eliminar la publicación, puede que el ID no exista');
                }
            }
        });
    }

    // AJAX DROPDOWNLIST CATEGORIAS / SUBCATEGORIAS

    llenarListaCategorias();
    llenarListaCategoriasAgregarSub();

    $("#ddlCateg").on('change', function () {


        var IdCategoria = ddlCategoria.val();
        llenarSubCategorias(IdCategoria);

    });

    function llenarListaCategorias() {
        $.ajax({
            url: 'post.aspx/ListarCategorias',
            method: 'POST',
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                dataJson = JSON.parse(data.d);
                ddlCategoria.empty();
                ddlCategoria.append('<option value="' + 0 + '">' + 'Seleccione la categoria' +
                    '</option>');
                ddlSubCategoria.append('<option value="' + 0 + '">' + 'Seleccione la subcategoria' +
                    '</option>');

                ddlSubCategoria.prop('disabled', true);

                $(dataJson).each(function (index, item) {
                    ddlCategoria.append('<option value="' + item.IdCategoria + '">' + item.Nombre +
                        '</option>');
                });

                var idCategoria = ddlCategoria.val();

                llenarSubCategorias(idCategoria);
            }

        });



    }

    function llenarSubCategorias(ID) {
        var obj = { id: ID };

        $.ajax({
            url: 'post.aspx/ListarSubCategorias',
            type: 'POST',
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d) {
                    var dataJson = $.parseJSON(data.d);
                    ddlSubCategoria.empty();
                    ddlSubCategoria.append('<option value="' + 0 + '">' + 'Seleccione la subcategoria' +
                        '</option>');

                    ddlSubCategoria.prop('disabled', false);

                    $(dataJson).each(function (index, item) {
                        ddlSubCategoria.append('<option value="' + item.IdSubCategoria + '">' + item.Nombre +
                            '</option>');
                    });
                } else {
                    ddlSubCategoria.append('<option value="' + 0 + '">' + 'No hay subcategorias' +
                        '</option>');

                    ddlSubCategoria.prop('disabled', true);
                }
            }

        });
    }


    // BOTON LIMPIAR CAMPOS
    $("#btnLimpiar").click(function (e) {
        e.preventDefault();
        limpiar();
    });

    $("#btnCancelarEliminar").click(function (e) {
        e.preventDefault();
        limpiar();
    });

    $("#btnCancelarMod").click(function (e) {
        e.preventDefault();
        limpiar();
    });

    // VALIDAR CAMPOS
    function validar() {
        var valido;

        if ($("#txtTitulo").val() == "") {
            $("#txtTitulo").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtTitulo").css("border", "");
            valido = true;
        }

        if ($("#txtDescripcion").val() == "") {
            $("#txtDescripcion").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtDescripcion").css("border", "");
            valido = true;
        }

        if ($("#txtSlug").val() == "") {
            $("#txtSlug").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtSlug").css("border", "");
            valido = true;
        }

        if ($("#txtImgPortada").val() == "") {
            $("#txtImgPortada").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtImgPortada").css("border", "");
            valido = true;
        }

        return valido;
    }

    // LIMPIAR CAMPOS
    function limpiar() {
        id = "";
        $("#txtId").val("");
        $("#txtId").change();
        $("#txtTitulo").val("");
        $("#txtDescripcion").val("");
        $("#txtContenido").val("");
        $("#txtSlug").val("");
        $("#txtImgPortada").val("");

        $("#btnEliminarPost").hide();

        $("#txtTitulo").css("border", "");
        $("#txtDescripcion").css("border", "");
        $("#txtSlug").css("border", "");
        $("#txtImgPortada").css("border", "");

        $('#modalEditar').modal('hide');
        $('#modalEliminar').modal('hide');

        

    }

    // AGREGAR UNA NUEVA CATEGORIA
    $(document).on('click', '#btnAgregarCategoria', function (e) {
        e.preventDefault();

        if ($("#txtAgregarCategoria").val() == "") {
            alertError('Se necesita un nombre para categoria');
        } else {
            var obj = {
                nombre: $("#txtAgregarCategoria").val()
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

    });
    $(document).on('click', '#btnCancelarCategoria', function (e) {
        e.preventDefault();
        $("#txtAgregarCategoria").val("")
    });

    // Llenar dropdown list categorias para agregar una subcategoria
    var ddlCategoriaAddSC = $("#ddlCategorias");

    function llenarListaCategoriasAgregarSub() {
        $.ajax({
            url: 'post.aspx/ListarCategorias',
            method: 'POST',
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                dataJson = JSON.parse(data.d);
                ddlCategoriaAddSC.empty();
                ddlCategoriaAddSC.append('<option value="' + 0 + '">' + 'Seleccione la categoria' +
                    '</option>');

                $(dataJson).each(function (index, item) {
                    ddlCategoriaAddSC.append('<option value="' + item.IdCategoria + '">' + item.Nombre +
                        '</option>');
                });
            }

        });
    }




    // recargar página
    function realizarPostBack() {
        location.reload();
    }


});