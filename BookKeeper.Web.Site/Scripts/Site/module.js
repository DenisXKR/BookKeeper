var app = angular.module("bookKeeperApp", []);

app.filter('currencyR', function () {
    return function (x) {
        if (x) {
            var dec = parseFloat(x).toFixed(2);
            return dec.replace(/(\d)(?=(\d{3})+\.)/g, '$1 ') + ' Руб';
        }

        return 0;
    };
});

$(function () {
    $("#date").datepicker({
        dateFormat: 'yy-mm-dd',
        showHour: false,
        showMinute: false
    });
});
