'use strict';
App.controller('UserCtrl',
    ["$scope", "$http", "$state", function ($scope, $http, $state) {
        var vm = this;
        vm.login = '';
        vm.projects = [];

        vm.nextPage = function () {
            $state.go("page1");
        };

        vm.logoutGo = function () {
            $http.post('Account/Logout/')
             .then(function (res) {
                 $state.go("home");
             }, function (res) {
                 alert("Smth went wrong");
             });
        };
    }]);