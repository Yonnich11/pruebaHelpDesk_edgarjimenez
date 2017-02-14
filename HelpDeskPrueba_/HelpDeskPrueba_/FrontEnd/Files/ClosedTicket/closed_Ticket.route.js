
(function () {
    "use strict";
    angular.module('app').
    config(config)
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
     
        $routeProvider.when('/closed-ticket', {
            templateUrl: '/FrontEnd/Files/ClosedTicket/closedTicket.html',
            controller: 'closed_TicketController'
        });
    }
})();

