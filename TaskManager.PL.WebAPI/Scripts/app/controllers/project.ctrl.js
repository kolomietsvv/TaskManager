'use strict';
App.controller('ProjectCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded", "$stateParams", 
        function ($scope, $http, $mdDialog, $state, userData, userLoaded, $stateParams) {
            var vm = this,
                projectId = $stateParams.projectId;
            vm.tasks = [];
            init();

            vm.showAddTaskDialog = function (ev) {
                $mdDialog.show({
                    controller: DialogController,
                    templateUrl: 'AddTaskPage.html',
                    locals: {
                        projectId: projectId,
                        minDate: new Date()
                    },
                    parent: angular.element(document.body),
                    targetEvent: ev,
                    clickOutsideToClose: true
                })
                .then(function (answer) {
                    $http.post('Project/AddTask/', answer)
                 .then(function (res) {
                     var data = res.data;
                     vm.tasks.push(data);
                 }, function (res) {
                     alert("Smth went wrong");
                 });
                }, function () {
                    $scope.status = 'You cancelled the dialog.';
                });
            };

            function init() {
                $http.post('Project/GetAllTasks/', { projectId: projectId })
                 .then(function (res) {
                     vm.tasks = res.data.Tasks;
                 }, function (res) {
                     alert("Smth went wrong");
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
        }])
    .filter("jsDate", function () {
            var regxp = /[0-9]+/;
            return function (json) {
                var intDate = json.match(regxp);
                return new Date(parseInt(intDate));
            };
        });;