'use strict';
App.controller('UserCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded", "userIsLoaded",
        function ($scope, $http, $mdDialog, $state, userData, userLoaded, userIsLoaded) {
            var vm = this;
            vm.projectName = '';
            vm.projectSummary = '';
            vm.projects = [];
            init();

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

            vm.addProject = function () {
                $http.post('User/AddProject/', { ProjectName: vm.projectName, Summary: projectSummary })
                 .then(function (res) {
                     var data = res.data;
                     vm.projects.push(data);
                 }, function (res) {
                     alert("Smth went wrong");
                 });
            };

            function init() {
                $http.post('User/GetAllProjects/', { loginName: userData.Login })
                 .then(function (res) {
                     vm.projects = res.data.Projects;
                 }, function (res) {
                     alert("Smth went wrong");
                 });
            }


            function DialogController($scope, $mdDialog) {
                vm.projectName = '';
                vm.projectSummary = '';
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