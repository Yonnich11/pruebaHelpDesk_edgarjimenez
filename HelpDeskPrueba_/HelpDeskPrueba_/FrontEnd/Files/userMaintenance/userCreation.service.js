(function () {
    'use strict';
    angular.module('app')
    .factory('userCreationService', ['$http', function ($http) {
        return {
            SaveUser: SaveUser,
            GetDataFillSelect: GetDataFillSelect,
            GetAllUser: GetAllUser,
            fallowUser: fallowUser
        }
        function GetDataFillSelect()
        {
            return $http.get('api/GetDataForFillSelect');
        }
        function SaveUser(data) {
            return $http.post('api/SaveUser', data, { headers: { "Content-Type": "application/json" } });
        }
        function GetAllUser() {
            return $http.get('api/GetAllUser');
        }

        function fallowUser(user_fallowed, user_fallow)
        {
            return $http.get('api/fallowUser?user_fallowed='+user_fallowed+'&user_fallow='+user_fallow)
        }
        
       

    }]);
})();