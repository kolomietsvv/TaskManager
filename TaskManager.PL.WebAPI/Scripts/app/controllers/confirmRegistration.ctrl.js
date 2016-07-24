'use strict';
App.controller('confirmRegistrationCtrl',
    ["$scope", "$http", "$state", function ($scope, $http, $state) {
        var vm = this;
        vm.login = '';
        vm.token = '';
        vm.confirmRegistration = function () {
            $http.post('Account/ConfirmRegistration/',
                {
                    login: vm.login,
                    token: vm.token
                });
        }
    }]);