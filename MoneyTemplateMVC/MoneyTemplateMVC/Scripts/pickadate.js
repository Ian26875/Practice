$(function () {
    var obj = $("[data_date_format]").attr("");
    $("[data-datetimepicker]").pickadate({
        selectYears: true,
        selectMonths: true,
        format:'yyyy-mm-dd',
    });
    
});
