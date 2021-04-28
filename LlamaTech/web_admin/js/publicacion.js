
var path = null;
var id = null;

$(document).ready(function () {

    $("#txtId").val("");
    $("#txtId").change();

});

$(function () {


    $("#txtId").change(function () {
        // MOSTRAR / OCULTAR BOTON BORRAR
        if ($("#txtId").val() == "") {
            $("#btnEliminarPost").hide();
        }
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
    $('td:nth-child(12)').hide();

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
        var idSubcategoria = $(this).closest('tr').find('td:eq(11)').text();
        var subcategoria = $(this).closest('tr').find('td:eq(12)').text();
        var activo = $(this).closest('tr').find('td:eq(13)').text();
        var usuario = $(this).closest('tr').find('td:eq(14)').text();

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


        var cbo = document.getElementById('ddlCateg');
        for (i = 0; i < cbo.length; i++) {
            if (cbo[i].innerText == categoria) {
                $('#ddlCateg').val(cbo[i].value);
                llenarSubCategorias(cbo[i].value);

                var ddlSC = document.getElementById('ddlSubCategoria');
                if (ddlSC.length > 1) {
                    for (j = 0; j < ddlSC.length; j++) {
                        if (ddlSC[j].value == idSubcategoria) {
                            $('#ddlSubCategoria').val(ddlSC[j].val);
                        }
                    }
                }
            }
        }




    });

    var ddlCategoria = $("#ddlCateg");
    var ddlSubCategoria = $("#ddlSubCategoria");



    // GUARDAR POST
    $(document).on('click', '#btnGuardarPost', function (e) {
        e.preventDefault();

        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {

            if (validar() == false) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {
                var _txtTitulo = $("#txtTitulo").val();
                var _txtDescripcion = $("#txtDescripcion").val();
                var _txtImagen = $("#txtImgPortada").val();
                var _txtContenido = $("#txtContenido").val();
                var _categoria = $("#ddlCateg").val();
                var _subCategoria = $("#ddlSubCategoria").val();
                var _txtSlug = $("#txtSlug").val();
                var _status = 2;
                addDataAjax(_txtTitulo, _txtDescripcion, _txtImagen, _txtContenido, _status, _txtSlug, _subCategoria, _categoria);
            }

        } else {
            showModalEditar();
        }
    });

    // Publicar POST
    $(document).on('click', '#btnPublicar', function (e) {
        e.preventDefault();

        if (id == "" || id == 0 || $("#txtId").val() == "" || $("#txtId").val() == 0) {

            if (validar() == false) {
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {
                var _txtTitulo = $("#txtTitulo").val();
                var _txtDescripcion = $("#txtDescripcion").val();
                var _txtImagen = $("#txtImgPortada").val();
                var _txtContenido = $("#txtContenido").val();
                var _categoria = $("#ddlCateg").val();
                var _subCategoria = $("#ddlSubCategoria").val();
                var _txtSlug = $("#txtSlug").val();
                var _status = 1;
                addDataAjax(_txtTitulo, _txtDescripcion, _txtImagen, _txtContenido, _status, _txtSlug, _subCategoria, _categoria);
            }

        } else {
            showModalEditarPublicar();
        }
    });

    // ELIMINAR POST
    $(document).on('click', '#btnEliminarPost', function (e) {
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

    function showModalEditarPublicar() {
        $('#modalPublicar').modal('show');
        publicar();

    }

    // MODAL ELIMINAR

    function showModalEliminar() {
        $('#modalEliminar').modal('show');
        eliminar();

    }

    // BOTON PUBLICAR
    function publicar() {
        $("#btnAceptarPubli").click(function (e) {
            e.preventDefault();

            if (validar() == false) {
                $('#modalEliminar').modal('hide');
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {

                var _txtIdPub = $("#txtId").val();
                var _txtTitulo = $("#txtTitulo").val();
                var _txtDescripcion = $("#txtDescripcion").val();
                var _txtImagen = $("#txtImgPortada").val();
                var _txtContenido = $("#txtContenido").val();
                var _categoria = $("#ddlCateg").val();
                var _subCategoria = $("#ddlSubCategoria").val();
                var _txtSlug = $("#txtSlug").val();
                var _status = 1;

                updateDataAjax(_txtIdPub, _txtTitulo, _txtDescripcion, _txtImagen, _txtContenido, _status, _txtSlug, _subCategoria, _categoria);
            }

        });
    }

    function modificar() {
        $("#btnAceptarMod").click(function (e) {
            e.preventDefault();

            if (validar() == false) {
                $('#modalEliminar').modal('hide');
                alertError('Todos los campos son obligatorios.');
                return false;
            } else {

                var _txtIdPub = $("#txtId").val();
                var _txtTitulo = $("#txtTitulo").val();
                var _txtDescripcion = $("#txtDescripcion").val();
                var _txtImagen = $("#txtImgPortada").val();
                var _txtContenido = $("#txtContenido").val();
                var _categoria = $("#ddlCateg").val();
                var _subCategoria = $("#ddlSubCategoria").val();
                var _txtSlug = $("#txtSlug").val();
                var _status = "2";

                updateDataAjax(_txtIdPub, _txtTitulo, _txtDescripcion, _txtImagen, _txtContenido, _status, _txtSlug, _subCategoria, _categoria);
            }

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
    function addDataAjax(titulo, descripcion, imagen, contenido, status, slug, subcategoria, categoria) {
        var obj = {
            titulo: titulo,
            descripcion: descripcion,
            imagen: imagen,
            contenido: contenido,
            status: status,
            slug: slug,
            subcategoria: subcategoria,
            categoria: categoria
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
                        limpiar();
                    }, 1500);
                } else {
                    alertError('No se pudo realizar el registro');
                }
            }
        });

    }

    // AJAX MODIFICAR POST
    function updateDataAjax(id, titulo, descripcion, imagen, contenido, status, slug, subcategoria, categoria) {

        var obj = {
            id: id,
            titulo: titulo,
            descripcion: descripcion,
            imagen: imagen,
            contenido: contenido,
            status: status,
            slug: slug,
            subcategoria: subcategoria,
            categoria: categoria
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

    $("#btnCancelarPubli").click(function (e) {
        e.preventDefault();
        limpiar();
    });

    // VALIDAR CAMPOS
    function validar() {
        var valido;

        if ($("#ddlCateg").val().trim() == "0") {
            $("#ddlCateg").css("border", "2px solid red");
            valido = false;
        } else {
            $("#ddlCateg").css("border", "");
            valido = true;
        }

        if ($("#ddlSubCategoria option:selected").val().trim() == "0") {
            $("#ddlSubCategoria").css("border", "2px solid red");
            valido = false;
        } else {
            $("#ddlSubCategoria").css("border", "");
            valido = true;
        }

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
        $("#txtContenido").trumbowyg("html", "");
        $("#txtSlug").val("");
        $("#txtImgPortada").val("");

        $("#btnEliminarPost").hide();

        $("#txtTitulo").css("border", "");
        $("#txtDescripcion").css("border", "");
        $("#ddlCateg").css("border", "");
        $("#ddlSubCategoria").css("border", "");
        $("#txtSlug").css("border", "");
        $("#txtImgPortada").css("border", "");

        $('#modalEditar').modal('hide');
        $('#modalEliminar').modal('hide');
        $('#modalPublicar').modal('hide');



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