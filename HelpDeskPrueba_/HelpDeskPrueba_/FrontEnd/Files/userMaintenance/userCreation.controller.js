(function () {

    'use strict';
    angular.module('app')
    .controller('user_CreationController', ['$scope', 'userCreationService', function ($scope, userCreationService) {

        $scope.user = {};
        $scope.SaveUser = SaveUser;
        function Clean() {
            $scope.user = {};
        }
       GetdataforSelects();
        function GetdataforSelects() {
            userCreationService.GetDataFillSelect().then(function (result) {
                $scope.dataforSelect = result.data;
            });
        }

        function SaveUser() {
            $scope.isError = false;
            $scope.ErrorList = [];
            if ($scope.user.NAME == undefined)
            {
                $scope.ErrorList.push('-Debe Colocar Nombre. ')
                $scope.isError = true;
                
            }
            if ($scope.user.PASSWORD == undefined || $scope.user.USER_NAME==undefined) {
                $scope.ErrorList.push('-Debe Colocar Password o Contrasena. ')
                $scope.isError = true;
                debugger
            }
            if($scope.user.PASSWORD!=undefined){





                if ($scope.user.PASSWORD.length < 5) {
                $scope.ErrorList.push('-Debe colocar un password de por lo menos 5 caracteres!.  ')
                $scope.isError = true;
            }
        }
            if ($scope.user.ID_ROL == undefined || $scope.user.ID_DEPARMENT==undefined) {
                $scope.ErrorList.push('-Debe Seleccionar cargo o departamento del usuario!.  ')
                $scope.isError = true;
            }
            debugger
            if ($scope.isError == true)
            {
                swal($scope.ErrorList.toString());
                return;
                
            }
            userCreationService.SaveUser($scope.user).then(function (result) {
                switch (result.data) {
                    case 'success':
                        swal('Usuario Registrado Correctamente!');
                        Clean();
                        break;
                    case 'exist_user':
                        swal('Registrado','Ya este nombre de usuario esta registrado !','danger');
                        break;
                }
            })
        }

    }])
})();