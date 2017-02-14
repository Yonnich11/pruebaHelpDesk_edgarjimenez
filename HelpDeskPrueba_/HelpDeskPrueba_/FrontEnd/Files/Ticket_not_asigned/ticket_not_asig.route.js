(function () {
    "use strict";
    angular.module('app').
    config(config)
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {

        $routeProvider.when('/ticket-no-asignados', {
            templateUrl: '/FrontEnd/Files/Ticket_not_asigned/ticket_not_asig.html',
            controller: 'ticketNotAsigned'
        });
    }
})();

