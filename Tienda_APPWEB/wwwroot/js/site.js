// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("a:contains('Editar')").html('<i class="fas fa-edit"></i>')
$("a:contains('Detalles')").html('<i class="fa-solid fa-info"></i>')
$("a:contains('Eliminar')").html('<i style="color:red" class="fa-solid fa-trash"></i>')
$("a:contains('Aceptar')").html('<i style="color:green" class="fa-solid fa-check"></i>')
$("a:contains('Denegar')").html('<i style="color:red" class="fa-solid fa-ban"></i>')


new DataTable('table', {
    responsive: true,
    layout: {
        topStart: {
            buttons: [{
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            }]
        }
    },
    language: {
        "decimal": "",
        "emptyTable": "No hay datos disponibles en la tabla",
        "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
        "infoEmpty": "Mostrando 0 a 0 de 0 entradas",
        "infoFiltered": "(filtrado de _MAX_ entradas totales)",
        "infoPostFix": "",
        "thousands": ",",
        "lengthMenu": "Mostrar _MENU_ entradas",
        "loadingRecords": "Cargando...",
        "processing": "Procesando...",
        "search": "Buscar:",
        "zeroRecords": "No se encontraron registros coincidentes",
        "paginate": {
            "first": "Primero",
            "last": "Último",
            "next": "Siguiente",
            "previous": "Anterior"
        },
        "aria": {
            "sortAscending": ": activar para ordenar la columna ascendente",
            "sortDescending": ": activar para ordenar la columna descendente"
        }
    }
});







const formGroups = document.querySelectorAll('.form-group');
formGroups.forEach(function (formGroup) {
    const label = formGroup.querySelector('label');
    const input = formGroup.querySelector('input');
    if (label && input) {
        const inputType = input.getAttribute('type');
        if (inputType === 'text' || inputType === 'number') {
            const labelText = label.textContent.trim();
            input.placeholder = labelText;
            label.style.display = 'none';
        }
    }
});




index = 0;
var fieldsets = $('.stepsForm fieldset')
var bar = $('#bar li')
fieldsets.hide();

var maxHeight = 0;


fieldsets.each(function () {
    var height = $(this).outerHeight();
    if (height > maxHeight) {
        maxHeight = height;
    }
});

$('.stepsForm').css('min-height', $('.stepsForm').outerHeight() + maxHeight + 50);

fieldsets.each(function (index) {
    var html = "<div class='buttons'>";
    if (index > 0) {

        html += '<input type="button" name="previous" class="previous action-button-previous secondary" value="Anterior"/>';
    }

    if (index < fieldsets.length - 1) {

        html += '<input type="button" name="next" class="next action-button" value="Siguiente"/>';
    } else {

        html += '<input type="submit" value="Registrar" class="submit btn btn-primary" />'
    }
    html += "</div>"
    $(this).append(html);
});

$(fieldsets[index]).show();
$(bar[index]).addClass('done')
$(document).on('click', '.next', function () {
    if (index < fieldsets.length - 1) {
        $(fieldsets[index]).animate({ left: '-100%' }, 500, function () {
            $(this).hide();
        });
        index++;
        $(fieldsets[index]).css({ left: '100%' }).show().animate({ left: '0%' }, 500);
        $(bar[index]).addClass('done')
    }
});

$(document).on('click', '.previous', function () {
    if (index > 0) {
        $(bar[index]).removeClass('done')
        $(fieldsets[index]).animate({ left: '100%' }, 500, function () {
            $(this).hide();
        });
        index--;
        $(fieldsets[index]).css({ left: '-100%' }).show().animate({ left: '0%' }, 500);

    }
});



