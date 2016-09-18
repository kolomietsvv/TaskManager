'use strict';
App.controller('TaskCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded", "$stateParams",
        function ($scope, $http, $mdDialog, $state, userData, userLoaded, $stateParams) {
            var vm = this,
                taskId = $stateParams.taskId;
            vm.subtasks = [];
            vm.subtaskId;
            init();

            function init() {
                $http.post('Task/GetAllSubtasks/', { taskId: taskId })
                 .then(function (res) {
                     vm.subtasks = res.data.Subtasks;
                 }, function (res) {
                     console.dir(res.data);
                 });
            }

            vm.confirmCompletion = function () {
                $http.post('Task/ConfirmCompletion/', { subtaskId: vm.subtaskId })
                     .then(function (res) {

                     }, function (res) {
                         console.dir(res.data);
                     });
            }

            vm.rejectCompletion = function () {
                $http.post('Task/RejectCompletion/', { subtaskId: vm.subtaskId })
                .then(function (res) {
                }, function (res) {
                    console.dir(res.data);
                });
            }

            vm.tryToDo = function (subtaskId) {
                $http.post('Task/tryToDo/', { subtaskId: vm.subtaskId, userLogin: userData.Login })
                 .then(function (res) {
                }, function (res) {
                    console.dir(res.data);
                });
            }

            vm.tryToDo = function (subtaskId) {
                $http.post('Task/tryToDo/', { subtaskId: vm.subtaskId, userLogin: userData.Login })
                 .then(function (res) {
                 }, function (res) {
                     console.dir(res.data);
                 });
            }

            vm.showAddSubtaskDialog = function (ev) {
                $mdDialog.show({
                    controller: DialogController,
                    templateUrl: 'AddSubtaskPage.html',
                    locals: {
                        taskId: taskId,
                        currentDate: new Date()
                    },
                    parent: angular.element(document.body),
                    targetEvent: ev,
                    clickOutsideToClose: true
                })
                .then(function (answer) {
                    $http.post('Task/AddSubtask/', answer)
                 .then(function (res) {
                     var data = res.data;
                     vm.subtasks.push(data);
                 }, function (res) {
                     console.dir(res.data);
                 });
                }, function () {
                    $scope.status = 'You cancelled the dialog.';
                });
            };

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
    });