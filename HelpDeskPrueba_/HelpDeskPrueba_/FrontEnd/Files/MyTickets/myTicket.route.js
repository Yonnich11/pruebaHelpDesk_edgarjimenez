(function () {
    "use strict";
    angular.module('app').
    config(config)
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {

        $routeProvider.when('/ticket-asignados', {
            templateUrl: '/FrontEnd/Files/MyTickets/MyTicket.html',
            controller: 'myTicketController'
        });
    }
})();

