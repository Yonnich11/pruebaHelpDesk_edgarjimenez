(function () {
    'use strict';
    angular.module('app')
    .controller('create_TicketController', ['$scope', 'createTicketService', 'userCreationService', function ($scope, createTicketService, userCreationService) {
        $scope.ticket={};
        $scope.datainPantalla = JSON.parse(localStorage['data']);
        debugger

        $scope.Save = Save;
        GetdataforSelects();
            
        function GetdataforSelects() {
            userCreationService.GetDataFillSelect().then(function (result) {
                $scope.dataforSelect = result.data;
            });
        }
        function Save() {
            if ($scope.ticket.DESCRIPCION == undefined)
            {
                swal('Debe escribir una descripcion!');
               return;
            }
            $scope.ticket.dataUser = $scope.datainPantalla;
            createTicketService.saveTicket($scope.ticket).then(function (result) {
                if (result.data == 'succes')
                {
                    swal('Su ticket ha sido enviado a soporte, en breves instantes sera atendido!');
                    $scope.ticket = {};
                }
            });
        }
      
    }])
})();