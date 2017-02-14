(function () {
    'use strict';
    angular.module('app')
    .controller('indexController', ['$scope', '$location', '$uibModal', 'logginService', 'userCreationService', function ($scope, $location, $uibModal, logginService, userCreationService) {

        $scope.OpenModalLoggin = OpenModalLoggin;
        $scope.OpenModalallUsers = OpenModalallUsers;
        $scope.datainPantalla = {};
        $scope.gotoUserCreation = function () {
          
            $location.path('/creacionUsuarios')
        }
        $scope.gotoCreateTicket = function () {
          
            $location.path('/crear-ticket')
        }
        $scope.gototickeNoAsignados = function () {
           
            $location.path('/ticket-no-asignados')
        }
        $scope.gototickeAsignados = function () {
          
            $location.path('/ticket-asignados')
        }
        $scope.gototicketCerrados = function () {

            $location.path('/closed-ticket')
        }
        $scope.CloseSession = function () {
      
            localStorage.clear();
            isMenuVisible();         
            swal('Session finalizada correctamente!');
           
        }
        $scope.gotoInformes = function () {
            $location.path('/informes')
        }
        function isMenuVisible() {
            if (localStorage['data'] == undefined)
            {
                $location.path('/')
                $scope.isMenuVisible = false;
            }
        }

        function OpenModalLoggin()
        {
            var modalopen = $uibModal.open
              ({
                  size: 'md',
                  animation: true,
                  backdrop: true,
                  templateUrl: '/FrontEnd/Files/Loggin/loggin.tpl.html',
                  controller: ['$uibModalInstance', '$scope', '$rootScope', function ($uibModalInstance, $innerScope, $rootScope)
                  {
                      $innerScope.Login = Login;
                      $innerScope.cancel = function () {
                          $uibModalInstance.dismiss('cancel');
                      };
                      $innerScope.datauser = {};
                      function Login() {
                          if ($innerScope.datauser.USER_NAME == undefined || $innerScope.datauser.PASSWORD == undefined)
                          {
                              swal('Debe de llenar ambos campos!');
                              return;
                          }

                          logginService.Login($innerScope.datauser).then(function (result) {

                              if (result.data != 'not_success') {
                                  $innerScope.datauser = result.data;
                                  $scope.isMenuVisible = true;
                                  localStorage['data'] = JSON.stringify($innerScope.datauser);
                                  $scope.datainPantalla = JSON.parse(localStorage['data']);
                                  swal('Aviso', 'Usuario Logueado Correctemente', 'info')
                                  $innerScope.cancel();
                              }
                              else {
                                  swal('Usuario o Password Incorrecto!')
                              }
                          })
                      }

                  }]
                  });

        }
        function OpenModalallUsers() {
            var modalopen = $uibModal.open
              ({
                  size: 'lg',
                  animation: true,
                  backdrop: true,
                  templateUrl: '/FrontEnd/Files/users/allUsers.tpl.html',
                  controller: ['$uibModalInstance', '$scope', '$rootScope', function ($uibModalInstance, $innerScope, $rootScope) {
                      getAll();
                      $innerScope.fallowUser = fallowUser;
                      $innerScope.cancel = function () {
                          $uibModalInstance.dismiss('cancel');
                      };
                      $innerScope.datauser = JSON.parse(localStorage['data']);
                      function fallowUser(item) {
                          if (item.ID_USER == $innerScope.datauser.ID_USER)
                          {
                              swal('No se puede seguir a usted mismo!')
                              return;
                          }
                          userCreationService.fallowUser($innerScope.datauser.ID_USER,item.ID_USER).then(function (result) {
                              debugger
                              switch (result.data)
                              {
                                  case 'success':

                                      swal('A partir de ahora usted sigue a' + item.NAME);
                                      break;
                                  case 'exist':
                                      swal('Ya usted sigue a este usuario!');
                                      break;
                              }
                          });

                      }
                      function getAll() {

                          userCreationService.GetAllUser().then(function (result) {

                              $innerScope.users=result.data
                            
                                                       })
                      }

                  }]
              });

        }
    }])

})();