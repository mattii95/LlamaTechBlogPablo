$(document).ready(function () {
    $('#dt').DataTable({
        responsive: true
    });

    $('#dt tbody').on('click', '.select', function () {
        var id = $(this).closest('tr').find('td:eq(1)').text();
        var nombre = $(this).closest('tr').find('td:eq(2)').text();
        var apellido = $(this).closest('tr').find('td:eq(3)').text();
        var telefono = $(this).closest('tr').find('td:eq(4)').text();
        var email = $(this).closest('tr').find('td:eq(5)').text();
        var foto = $(this).closest('tr').find('td:eq(6)').text();
        var rol = $(this).closest('tr').find('td:eq(11)').text();
        var activo = $(this).closest('tr').find('td:eq(12)').text();

        $('#txtId').val(id);
        $('#txtNombre').val(nombre);
        $('#txtApellido').val(apellido);
        $('#txtTelefono').val(telefono);
        $('#txtEmail').val(email);
        $('#imgUser').prop('src', foto);
        $('#ddlRol').val(rol);

        var cbo = document.getElementById('<%=ddlRol.ClientID%>');
        for (i = 0; i < cbo.length; i++) {
            if (cbo[i].innerText == rol)
                $('#<%=ddlRol.ClientID%>').val(cbo[i].value);
        }

        if (activo == 'True') {
            $('#chkStatus').prop('checked', true);
        } else {
            $('#chkStatus').prop('checked', false);
        }
    });
});