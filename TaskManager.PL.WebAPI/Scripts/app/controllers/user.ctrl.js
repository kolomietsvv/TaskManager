'use strict';
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


            function init() {
                $http.post('User/GetAllProjects/', { loginName: loginName })
                 .then(function (res) {
                     vm.projects = res.data.Projects;
                 }, function (res) {
                     alert("Smth went wrong");
                 });
            }

            vm.showAddProjectDialog = function (ev) {
                $mdDialog.show({
                    controller: DialogController,
                    templateUrl: 'AddProjectPage.html',
                    parent: angular.element(document.body),
                    targetEvent: ev,
                    clickOutsideToClose: true
                })
                .then(function (answer) {
                    $http.post('User/AddProject/', answer)
                 .then(function (res) {
                     var data = res.data;
                     vm.projects.push(data);
                 }, function (res) {
                     alert("Smth went wrong");
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
                     alert("Smth went wrong");
                 });
            };

            function DialogController($scope, $mdDialog) {
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