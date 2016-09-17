'use strict';
App.controller('TaskCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded", "$stateParams",
        function ($scope, $http, $mdDialog, $state, userData, userLoaded, $stateParams) {
            var vm = this,
                taskId = $stateParams.taskId;
            vm.subtasks = [];
            vm.ifIContributor() = function () {

            }
            init();

            

            function init() {
                $http.post('Task/GetAllSubtasks/', { taskId: taskId })
                 .then(function (res) {
                     vm.subtasks = res.data.SubTasks;
                 }, function (res) {
                     alert("Smth went wrong");
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
                    $http.post('Task/AddSubTask/', answer)
                 .then(function (res) {
                     var data = res.data;
                     vm.subtasks.push(data);
                 }, function (res) {
                     alert("Smth went wrong");
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