(function () {
    'use strict';
    angular.module('app')
    .controller('ticketNotAsigned', ['$scope', 'ticketNotAsignedService', function ($scope, ticketNotAsignedService) {
        getData();
        function getData() {
            ticketNotAsignedService.getdata().then(function (result) {
                $scope.data = result.data;
            })
        }
        $scope.data_ = {};
        $scope.AsignToMe = AsignToMe;
        $scope.data_ = JSON.parse(localStorage['data']);
        function AsignToMe(e) {
            debugger
            $scope.data_.ID_TICKET = e;
            ticketNotAsignedService.asigToMe($scope.data_).then(function (result) {
                if (result.data = 'success')
                {
                    getData();
                    swal('Este Ticket ha sido asignado a '+$scope.data_.NAME+' .');
                }
            })
        }
    }])
})();