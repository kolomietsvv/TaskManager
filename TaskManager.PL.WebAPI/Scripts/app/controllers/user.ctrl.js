﻿'use strict';
App.controller('UserCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded", "userIsLoaded", "$stateParams",
        function ($scope, $http, $mdDialog, $state, userData, userLoaded, userIsLoaded, $stateParams) {
            var vm = this,
                loginName = $stateParams.login;
            vm.projects = [];
            init();
            vm.isMyPage = function () {
                return userData.Login === loginName;
            };

            vm.showAddProjectDialog = function (ev) {
                $mdDialog.show({
                    controller: DialogController,
                    templateUrl: 'AddProjectPage.html',
                    parent: angular.element(document.body),
                    targetEvent: ev,
                    locals: {
                        userLogin: userData.Login
                    },
                    clickOutsideToClose: true
                })
                .then(function (answer) {
                    $http.post('User/AddProject/', answer)
                 .then(function (res) {
                     var data = res.data;
                     vm.projects.push(data);
                 }, function (res) {
                     console.dir(res.data);
                 });
                }, function () {
                    $scope.status = 'You cancelled the dialog.';
                });
            };

            vm.logoutGo = function () {
                $http.post('Account/Logout/')
                 .then(function (res) {
                     userLoaded.reset();
                     angular.copy({}, userData);
                     $state.go("home");
                 }, function (res) {
                     console.dir(res.data);
                 });
            };

            function init() {
                $http.post('User/GetAllProjects/', { loginName: loginName })
                 .then(function (res) {
                     vm.projects = res.data.Projects;
                 }, function (res) {
                     console.dir(res.data);
                 });
            }

            function DialogController($scope, $mdDialog, locals) {
                $scope.locals = locals;
                $scope.hide = function () {
                    $mdDialog.hide();
                };
                $scope.cancel = function () {
                    $mdDialog.cancel();
                };
                $scope.answer = function (answer) {
                    $mdDialog.hide(answer);
                };
            }


        }]);