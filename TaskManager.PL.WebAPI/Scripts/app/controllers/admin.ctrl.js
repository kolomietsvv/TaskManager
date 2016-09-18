'use strict';
App.controller('AdminCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded", "$stateParams",
        function ($scope, $http, $mdDialog, $state, userData, userLoaded, $stateParams) {
            var vm = this;
            vm.loginName;
            vm.user;
            vm.allRoles;
            vm.role;

            vm.getUser = function () {
                $http.post('User/GetUser/', { loginName: vm.loginName })
                .then(function (res) {
                    vm.user = res.data.User;
                }, function (res) {
                    console.dir(res.data);
                });
                $http.post('Admin/GetAllRoles/')
                .then(function (res) {
                    vm.allRoles = res.data.AllRoles;
                }, function (res) {
                    console.dir(res.data);
                });
            };
            vm.addRole = function () {
                $http.post('Admin/AddRole/', { loginName: vm.loginName, roleName: vm.role })
                .then(function (res) {
                    vm.user.Roles.push(vm.role);
                }, function (res) {
                    console.dir(res.data);
                });
            };
            vm.deleteRole = function () {
                $http.post('Admin/DeleteRole/', { loginName: vm.loginName, roleName: vm.role })
                .then(function (res) {
                    _.remove(vm.user.Roles, function (role) {
                        return role === vm.role;
                    });
                }, function (res) {
                    console.dir(res.data);
                });
            };
        }]);