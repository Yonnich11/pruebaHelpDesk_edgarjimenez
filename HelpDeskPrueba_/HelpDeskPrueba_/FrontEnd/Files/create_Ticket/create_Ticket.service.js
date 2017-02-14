(function () {
    'use strict';
    angular.module('app')
    .factory('createTicketService', ['$http', function ($http) {
        return {

            saveTicket: saveTicket

        }

        function saveTicket(data) 
        {
            debugger
            return $http.post('ticket/SaveTicket', data, { headers: { "Content-Type": "application/json" } });
        }



    }]);
})();