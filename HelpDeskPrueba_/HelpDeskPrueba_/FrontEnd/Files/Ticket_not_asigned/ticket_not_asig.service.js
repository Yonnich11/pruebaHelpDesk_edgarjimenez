(function () {
    'use strict';
    angular.module('app')
    .factory('ticketNotAsignedService', ['$http', function ($http) {
        return {

            getdata: getdata,
asigToMe:asigToMe
        }

        function getdata() {
            debugger
            return $http.get('ticket/GetTicketSinAsig');
        }

        function asigToMe(data) {
            return $http.post('ticket/asignarTicket', data, { headers: { "Content-Type": "application/json" } })
        }
    }]);
})();