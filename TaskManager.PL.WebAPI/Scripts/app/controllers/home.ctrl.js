'use strict';
App.controller('HomeCtrl',
    ["$scope", "$http", function ($scope, $http) {
        var vm = this;
        vm.login = '';
        vm.password = '';
        vm.loginGo = function () {
            $http.post('Home/Authenticate/', {login:vm.login, password:vm.password})
            .then(function (res) {
                var data = res.data;
                console.dir(data);
            }, function (res) {
                console.dir(arguments);
                var data = res.data;
            });
        };
        vm.check = function () {
            $http.post('Account/IsAuthorized/')
            .then(function (res) {
                var data = res.data;
                console.dir(data);
            }, function (res) {
                var data = res.data;
                console.dir(data);
            });
        };

        function init() {
            $http.get("Project/GetAllByUser")
            .then(function (res) {
                var data = res.data;
                vm.projects = data;
            });

        }
    }]);