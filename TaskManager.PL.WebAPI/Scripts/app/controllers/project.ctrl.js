'use strict';
App.controller('ProjectCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded", "$stateParams",
        function ($scope, $http, $mdDialog, $state, userData, userLoaded, $stateParams) {
            var vm = this, 
                projectId=$stateParams.projectId;
        	vm.projectId='';
        	vm.projectName = '';
        	vm.projectSummary = '';
        	vm.tasks = [];
        	init();

        	vm.showAddProjectDialog = function (ev) {
        		$mdDialog.show({
        			controller: DialogController,
        			templateUrl: 'AddTaskPage.html',
        			parent: angular.element(document.body),
        			targetEvent: ev,
        			clickOutsideToClose: true
        		})
                .then(function (answer) {
                	$http.post('Project/AddTask/', answer)
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

        	function init() {
        	    $http.post('Project/GetAllTasks/', { projectId: projectId })
                 .then(function (res) {
                 	vm.tasks = res.data.Tasks;
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