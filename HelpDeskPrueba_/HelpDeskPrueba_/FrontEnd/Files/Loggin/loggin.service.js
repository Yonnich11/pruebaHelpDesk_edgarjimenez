(function () {
    'use strict';
    angular.module('app')
    .factory('logginService', ['$http', function ($http) {
        return {

            Login: Login

        }
        function Login(data) {
            return $http.post('api/login', data, { headers: { "Content-Type": "application/json" } });
        }
        
    }]);
})();