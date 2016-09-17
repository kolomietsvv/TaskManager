'use strict';
App.controller('SearchCtrl',
    ["$scope", "$http", "$mdDialog", "$state", "userData", "userLoaded",
        function ($scope, $http, $mdDialog, $state, userData, userLoaded) {
            var vm = this;
            vm.users = [];
            vm.projects = [];
            vm.loginName='';
            vm.email='';
            vm.firstName='';
            vm.lastName = '';
            vm.age = '';
            vm.companyName = '';
            vm.qualification = '';
            vm.extraInf = '';
            vm.getAllUsersLike = getAllUsersLike;
            vm.getAllUsersLike();
            
           function getAllUsersLike()  {
                $http.post('Search/GetAllUsersLike/', {
                    LoginName: vm.loginName,
                    Email: vm.email,
                    FirstName: vm.firstName,
                    LastName: vm.lastName,
                    Age: vm.age,
                    CompanyName: vm.companyName,
                    Qualification: vm.qualification,
                    ExtraInf: vm.extraInf
                })
                 .then(function (res) {
                     vm.users = res.data.Users;
                 }, function (res) {
                     alert("Smth went wrong");
                 });
            }

            function getAllProjectsLike(request) {
                $http.post('Search/GetAllProjectsLike/', request)
                .then(function (res) {
                    vm.projects = res.data.Projects;
                }, function (res) {
                    alert('Smth went wrong');
                });
            }
        }]);