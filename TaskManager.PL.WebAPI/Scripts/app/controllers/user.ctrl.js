'use strict';
App.controller('UserCtrl',
    ["$scope", "$http", "$state", "userData", "userLoaded", "userIsLoaded",
        function ($scope, $http, $state, userData, userLoaded, userIsLoaded) {
        var vm = this;
        vm.projectName='';
        vm.projects = [];
        init();

        vm.nextPage = function () {
            $state.go("page1");
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
            $http.post('User/AddProject/', {ProjectName: vm.projectName })
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
                 vm.projects=res.data.Projects;
             }, function (res) {
                 alert("Smth went wrong");
             });
        }
    }]);