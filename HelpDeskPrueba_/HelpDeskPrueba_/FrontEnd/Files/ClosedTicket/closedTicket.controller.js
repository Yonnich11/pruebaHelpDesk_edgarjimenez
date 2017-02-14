(function () {
    'use strict';
    angular.module('app').
    factory('closedService', ['$http', function ($http) {
        return {
          
            GetClosedTicket: GetClosedTicket

        }
        function GetClosedTicket() {
            return $http.get('ticket/GetClosedTicket');
        }
        

    }])
      .controller('closed_TicketController', ['$scope', 'closedService', function ($scope, closedService) {

          GetAall();
          function GetAall() {
              debugger
              closedService.GetClosedTicket().then(function (result) {
                  $scope.data = result.data;
              })
          }
        

      }]);
})()