//Alerta error
function alertError(mensaje) {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: mensaje,
    });
}


// Alertas pagina categoria
function alertSuccess(mensaje) {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: mensaje,
        showConfirmButton: false,
        timer: 1500
    });
}