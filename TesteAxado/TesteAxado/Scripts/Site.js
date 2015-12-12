$(document).ready(function () {
    MyMasks();
});

function ShowMessage(message, type) {
    switch (type) {
        case 'error':
            $('#messages .alert').addClass('alert-danger');
            $('#messagetype').text('Error! ');
            break;
        case 'success':
            $('#messages .alert').addClass('alert-success');
            $('#messagetype').text('Success! ');
            break;
        case 'warning':
            $('#messages .alert').addClass('alert-warning');
            $('#messagetype').text('Warning! ');
            break;
        case 'info':
            $('#messages .alert').addClass('alert-info');
            $('#messagetype').text('Information! ');
            
            break;
        default:
    }
    
    $('#message').text(decodeURIComponent(message));
    $('#messages .alert').show();
    setTimeout(function () {
        $('#messages .alert').hide();
    }, 5000);
}
/* -- Mask --*/

function MyMasks() {
    $('.data').mask('00/00/0000', { maxlength: 10, placeholder: "__/__/____" });
    $('.data-mes-ano').mask('00/0000', { maxlength: 10, placeholder: "__/____" });
    $('.dataMY').mask('00/0000', { maxLength: 7, placeholder: "__/____" });
    $('.hora-minutos').mask('00:00', { maxlength: 5, placeholder: "__:__" });
    $('.hora-segundos').mask('00:00:00', { maxlength: 8, placeholder: "__:__:__" });
    $('.data_hora').mask('00/00/0000 00:00:00');
    $('.cep').mask('00000-000', { maxlength: 9, placeholder: "_____-___" });
    $('.tel').mask('(00) 0000-0000', { maxlength: 14, placeholder: "(__) ____-____" });
    $('.cpf').mask('000.000.000-00', { maxlength: 14, placeholder: "___.___.___-__" });
    $('.cnpj').mask('00.000.000/0000-00', { maxlength: 18, placeholder: "___.___.___/____-__" });
    $('.pis').mask('000.00000.00-0', { maxlength: 14, placeholder: "___._____.__-_" });
    $('.rg').mask('00.000.000-A', { maxlength: 12, placeholder: "__.___.___-_" });
    $('.num').mask('0#');
    $('.decimal').mask('000,00');
}

/* -- Mask --*/

/* -- Loading -- */
function LoadingOn() {
    $('.preloadingBackground').show();
};

function LoadingOff() {
    $('.preloadingBackground').hide();
};
/* -- Loading -- */

/* -- Rating -- */

function GetRate() {
    $.ajax({
        type: "GET",
        cache: false,
        url: "/Carrier/GetRate/" + $('#idCarrier').val(),
        beforeSend: function () {
            LoadingOn();
        },
        success: function (data) {
            if (data.success == true) {
                $('#rating').raty('score', data.valueUser);
                $('#ratAvg').text('Avg: ' + data.valueAvg);
            }
            else {
                ShowMessage(data.message, 'warning');
                $('#rating').raty('reload');
                $('#ratAvg').text('Avg: 0');
            }
        },
        complete: function () {
            LoadingOff();
        },
        error: function () {
            $('#rating').raty('reload');
            $('#ratAvg').text('Avg: 0');
            LoadingOff();
        }
    });
}

function SetRating(value) {
    $.ajax({
        type: "GET",
        cache: false,
        url: "/Carrier/Rating/" + $('#idCarrier').val() + "?value=" + value,
        beforeSend: function () {
            LoadingOn();
        },
        success: function (data) {
            if (data.success == true) {
                ShowMessage(data.message, 'success');
                GetRate();
            }
            else {
                ShowMessage(data.message, 'warning');
                $('#rating').raty('reload');
            }
        },
        complete: function () {
            LoadingOff();
        },
        error: function () {
            $('#rating').raty('reload');
            LoadingOff();
        }
    });
}

/* -- Rating -- */
