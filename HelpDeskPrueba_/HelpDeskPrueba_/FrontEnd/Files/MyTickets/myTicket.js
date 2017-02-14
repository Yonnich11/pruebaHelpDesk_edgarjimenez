(function () {
    'use strict';
    angular.module('app')
    .controller('myTicketController', ['$scope','$uibModal', 'myTicketService', function ($scope,$uibModal, myTicketService) {

        $scope.OpenModal = OpenModal;
        $scope.OpenModalallImages = OpenModalallImages;
        $scope.dataUser = JSON.parse(localStorage['data']);
        GetAllMyTicket();
        GetAllMyfallowTicket();
        function GetAllMyTicket() {

            myTicketService.GetAllMyTicket($scope.dataUser.ID_USER).then(function (result) {
                $scope.myTicket = result.data;
            })
        }
        
        function GetAllMyfallowTicket() {

            myTicketService.getMyFallowData($scope.dataUser.ID_USER).then(function (result) {
                $scope.fallow = result.data;
            })
        }
       
        function OpenModal(item) {
            var modalopen = $uibModal.open({
                size: 'md',
                animation: true,
                backdrop: true,
                templateUrl: '/FrontEnd/Files/MyTickets/closeTicke.tpl.html',
                controller: ['$uibModalInstance', '$scope', '$rootScope', function ($uibModalInstance, $innerScope, $rootScope) {
                    $innerScope.CloseTicket = CloseTicket;
                    $innerScope.cancel = function () {
                        $uibModalInstance.dismiss('cancel');
                    };

                    $scope.item = item;
                    debugger
                    GetData();
                    function GetData() {
                        myTicketService.GetForClose($scope.item.ID_TICKET).then(function (result) {
                            debugger
                            $innerScope.dataTicket = result.data;
                        })
                    }
                    $innerScope.ticket = {};
                    function CloseTicket() {
                        if ($innerScope.ticket.COMMENTARY == undefined) {
                            swal('Debe llenar el campo comentario!');
                            return;
                        }
                        $innerScope.ticket.ID_TICKET = $scope.item.ID_TICKET;
                        myTicketService.closeTicket($innerScope.ticket).then(function (result) {
                            if (result.data == 'success') {
                                GetAllMyTicket();
                                $innerScope.cancel();
                                swal('Ticket Cerrado exitosamente');
                            }
                        })

                    }

                }]
            })
        }
        function OpenModalallImages(item) {
            var modalopen = $uibModal.open
              ({
                  size: 'lg',
                  animation: true,
                  backdrop: true,
                  templateUrl: '/FrontEnd/Files/MyTickets/images.tpl.html',
                  controller: ['$uibModalInstance', '$scope', '$rootScope', function ($uibModalInstance, $innerScope, $rootScope) {
                      $innerScope.url = item.FILES;
                      $innerScope.cancel = function () {
                          $uibModalInstance.dismiss('cancel');
                      };
                   
                     
                         
                  }]
              });

        }
    }])
})();