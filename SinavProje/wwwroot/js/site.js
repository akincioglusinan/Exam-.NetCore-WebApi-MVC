// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $("input:checkbox").on('click',
        function () {
            var $box = $(this);
            if ($box.is(":checked")) {
                var group = "input:checkbox[name='" + $box.attr("name") + "']";
                $(group).prop("checked", false);
                $box.prop("checked", true);
            } else {
                $box.prop("checked", false);
            }
        });

    $("#getExamBtn").click(function () {
        $("#getExamForm").submit(function (event) {
            event.preventDefault();
            var soru1 = $('.1:checked', this).val();
            var soru2 = $('.2:checked', this).val();
            var soru3 = $('.3:checked', this).val();
            var soru4 = $('.4:checked', this).val();

            if (soru1 === A1) {
                $('#' + soru1 + '-' + '1', this).css({ 'background-color': 'green' });
            } else {
                $('#' + soru1 + '-' + '1', this).css({ 'background-color': 'red' });
            };
            soru2 === A2
                ? $('#' + soru2 + '-' + '2', this).css({ 'background-color': 'green' })
                : $('#' + soru2 + '-' + '2', this).css({ 'background-color': 'red' });
            soru3 === A3
                ? $('#' + soru3 + '-' + '3', this).css({ 'background-color': 'green' })
                : $('#' + soru3 + '-' + '3', this).css({ 'background-color': 'red' });
            soru4 === A4
                ? $('#' + soru4 + '-' + '4', this).css({ 'background-color': 'green' })
                : $('#' + soru4 + '-' + '4', this).css({ 'background-color': 'red' });

        });
    });

});

