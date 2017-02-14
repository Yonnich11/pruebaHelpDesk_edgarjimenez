(function () {
    "use strict";
    angular.module('app').
    config(config)
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        debugger
        $routeProvider.when('/', {
            templateUrl: 'index.html',
            controller: 'create_TicketController'
        });
    }
})();

