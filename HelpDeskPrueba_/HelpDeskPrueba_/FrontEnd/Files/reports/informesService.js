(function () {
    'use strict';
    angular.module('app')
    .factory('informeService', ['$http', function ($http) {
        return {
            getTicketCerrados: getTicketCerrados
            

        }
        function getTicketCerrados(idUser) {
            return $http.get('informes/getTicketCerrados')
        }
       
    }]);
})();