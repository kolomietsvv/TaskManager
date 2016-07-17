'use strict';
App.controller('confirmRegistrationCtrl',
    ["$scope", "$http", "$state", function ($scope, $http, $state) {
        var vm = this;
        vm.login = '';
        vm.tokem = '';
        vm.confirmRegistration = function () {
            $http.post('Account/ConfirmRegistration/',
                {
                    login: vm.login,
                    token: vm.token
                });
        }
    }]);