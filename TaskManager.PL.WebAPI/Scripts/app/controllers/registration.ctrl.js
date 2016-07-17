'use strict';
App.controller('RegistrationCtrl',
    ["$scope", "$http", "$state", function ($scope, $http, $state) {
        var vm = this;
        vm.login = '';
        vm.password = '';
        vm.confirmPassword = '';
        vm.email = '';
        vm.createNewAccount = function () {
            if (vm.password !== vm.confirmPassword) {
                vm.password = '';
                vm.confirmPassword = '';
                //todo invoke alert service
                return;
            }
            $http.post('Account/CreateNewAccount/',
                {
                    login: vm.login,
                    password: vm.password,
                    email: vm.email
                })
             .then(function (res) {
                 $state.go("home");
             }, function (res) {
                 alert("Smth went wrong");
             });

        };
    }]);