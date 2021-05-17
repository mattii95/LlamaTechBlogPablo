var path = null;

$(document).ready(function () {

    // GUARDAR 
    $(document).on('click', '#btnGuardar', function (e) {
        e.preventDefault();

        if ($("#txtDesc").val() != "" && path != "") {
            buscarImagenes(path);
        }
        else {
            alertError("Todos los campos son obligatorias");
        }
        

    });

    $(function () {
        $(document).on("change", "#fuImg", function (e) {

            var fileName = this.files[0].name;
            var fileSize = this.files[0].size;
            showPath(fileName);

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
    });

    function showPath(e) {
        path = e;
    }


    // AJAX AGREGAR
    function addDataAjax() {

        var formData = new FormData($('form')[0]);
        var fileUpload = $('#fuImg').get(0);
        var files = fileUpload.files;
        var desc = $('#txtDesc').val();

        //for (var i = 0; i < files.length; i++) {
        //    formData.append(files[i].name, files[i]);
        //}

        formData.append(files[0].name, files[0]);

        console.log(formData.keys);

        $.ajax({
            url: "../UploadImages.ashx?desc=" + desc,
            type: "POST",
            dataType: "json",
            data: formData,
            contentType: false,
            processData: false,
            complete: function () {
                alertSuccess('La imagen fue agregada con exito!');
                limpiar();
                setTimeout(function () {
                    realizarPostBack();
                }, 1500);
            }
        });

    }

    function buscarImagenes(nombre) {
        var obj = { nombre: nombre};

        $.ajax({
            url: 'frmImages.aspx/GetNombreImages',
            type: 'POST',
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var val = data.d;
                val = val.replace("[]", "");
                if (val) {
                    //Si existe la imagen
                    alertError('La imagen ya existe en el servidor');

                } else {
                    //Si no existe la imagen
                    addDataAjax();
                }
            }

        });
    }


    // BOTON LIMPIAR CAMPOS
    $(document).on('click', '#btnLimpiar', function (e) {
        e.preventDefault();

        limpiar();
        realizarPostBack
    });

    // MOSTRAR IMAGEN EN IMGVIEW
    function readURL(input) {

        if (input.files && input.files[0]) {

            var reader = new FileReader();

            reader.onload = function (e) {
                $('#imgImagen').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }

    }

    // VALIDAR CAMPOS
    function validar() {
        var valido;

        if ($("#txtDesc").val() == "") {
            $("#txtDesc").css("border", "2px solid red");
            valido = false;
        } else {
            $("#txtDesc").css("border", "");
            valido = true;
        }

        if ($("#file").val() == "") {
            $("#file").css("border", "2px solid red");
            valido = false;
        } else {
            $("#file").css("border", "");
            valido = true;
        }

        return valido;
    }

    // LIMPIAR CAMPOS
    function limpiar() {
        $("#txtId").val("");
        $("#txtDesc").val("");
        $("#fuImg").val("");
        $("#imgImagen").prop('src', "");
        $("#tamanioImg").text("");

        $("#txtDesc").css("border", "");
        $("#fuImg").css("border", "");


    }

    // RECARGAR PÁGINA
    function realizarPostBack() {
        location.reload();
    }

});