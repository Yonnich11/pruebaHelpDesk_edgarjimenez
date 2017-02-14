(function () {
    "use strict";
    angular.module('app').
    config(config)
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {

        $routeProvider.when('/informes', {
            templateUrl: '/FrontEnd/Files/reports/reports.html',
            controller: 'informesController'
        });
    }
})();

