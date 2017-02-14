/// <reference path="create_Ticket.html" />
(function () {
    "use strict";
    angular.module('app').
    config(config)
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
     
        $routeProvider.when('/crear-ticket', {
            templateUrl: '/FrontEnd/Files/create_Ticket/create_Ticket.html',
            controller: 'create_TicketController'
        });
    }
})();

