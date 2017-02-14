(function () {
    'use strict';
    angular.module('app')
    .factory('myTicketService', ['$http', function ($http) {
        return {
            GetAllMyTicket: GetAllMyTicket,
            GetForClose: GetForClose,
            closeTicket: closeTicket,
            getMyFallowData: getMyFallowData

        }
        function GetAllMyTicket(idUser) {
            return $http.get('ticket/GetMyTicket?idUser='+idUser)
        }
        function GetForClose(idTicket) {
            return $http.get('ticket/getForClosed?idTicket=' + idTicket)
        }

        function closeTicket(data) {
            return $http.post('ticket/closeTicket', data, { headers: { "Content-Type": "application/json" } })
        }
        function getMyFallowData(user_fallowed) {
            return $http.get('ticket/getMyFallowData?user_fallowed=' + user_fallowed)
        }
    }]);
})();