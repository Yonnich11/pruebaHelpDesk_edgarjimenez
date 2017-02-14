


(function () {
    "use strict";
    angular.module('app').
    config(config)
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        
        $routeProvider.when('/creacionUsuarios', {
            templateUrl: '/FrontEnd/Files/userMaintenance/userCreation.html',
            
            controller: 'user_CreationController'
        });
    }
})();