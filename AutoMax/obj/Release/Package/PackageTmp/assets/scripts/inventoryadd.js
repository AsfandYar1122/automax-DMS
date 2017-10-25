$(function () {
    var warranty_editor = CKEDITOR.replace('warranty');
    var desc_editor = CKEDITOR.replace('desc');
    $('#rootwizard').bootstrapWizard({
        onTabClick: function (tab, navigation, index, clickedIndex) {
            var $current = clickedIndex + 1;
            if ($current == 4) {
                $('#btnNext').hide();
            }
            if ($current == 3 || $current == 2 || $current == 1) {
                $('#btnNext').show();
                if ($current == 2 || $current == 3) {
                    debugger;
                    $('#btnSubmit').attr('disabled', false);
                }
                $('#btnNext').show();
            }
        },
        onNext: function (tab, navigation, index) {
            var $current = index + 1;
            if (index == 1) {
                var vin = $('#vin').val();
                var stockNumber = $('#s_num').val();
                var plateNumber = $('#p_num').val();
                var makerId = $('#MakerID option:selected').val();
                var autoModelID = $('#AutoModelID option:selected').val();
                var yearId = $('#YearID option:selected').val();
                
                var odometer = $('#odometer').val();
               
                var autoBodyStyleID = $('#AutoBodyStyleID option:selected').val();
                var vehicleTypeID = $('#VehicleTypeID option:selected').val();
                var autoAirBagID = $('#AutoAirBagID option:selected').val();
                var allOK = false;
                if (vin !== null && vin != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                if ($("#vehicleStatus").val()=="3" && (plateNumber === "")) {
                    allOK = true;
                }
                else if ($("#vehicleStatus").val() == "4" && (plateNumber !== "")) {
                    allOK = true;
                }
                else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                if (stockNumber != null && stockNumber != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                if (makerId !== null && makerId != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                if (autoModelID !== null && autoModelID != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                if (yearId !== null && yearId != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                
                if (odometer !== null && odometer != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                
                if (autoBodyStyleID !== null && autoBodyStyleID != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                
                if (autoAirBagID !== null && autoAirBagID != '') {
                    allOK = true;
                } else {
                    allOK = false;
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                }
                if (!allOK) {
                    $('#vin').focus();
                    $('#validateInformation').text('Please enter required information');
                    $('#validateInformation').css('color', 'red');
                    $('#validateInformation').show().fadeOut(3000);
                    return false;
                } else {
                    $('#btnSubmit').attr('disabled', false);
                }
            }

        },
        'tabClass': 'nav nav-pills', 'nextSelector': '.btn-next', 'previousSelector': '.btn-previous', 'firstSelector': '.button-first', 'lastSelector': '.button-last'
    });
});
(function ($) {
    $.fn.IsNullOrEmptyOrUndefinedList = function () {
        var value = this;
        return value !== null || value == '' || value == undefined ? true : false;
    };
})(jQuery);
var IsNullOrEmptyOrUndefined = function (value) {
    return value !== null || value == '' || value == undefined ? true : false;
};