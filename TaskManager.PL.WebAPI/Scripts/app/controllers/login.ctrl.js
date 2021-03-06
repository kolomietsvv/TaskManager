﻿'use strict';
App.controller('LoginCtrl',
    ["$scope", "$http", "$state", "userData", 'userLoaded',
        function ($scope, $http, $state, userData, userLoaded) {
        var vm = this;
        vm.login = '';
        vm.password = '';

        vm.loginGo = function () {
            userLoaded.reset();
           $http.post('Account/Login/', { Login:vm.login, Password: vm.password })
            .then(function (res) {
                var data = res.data;
                angular.copy(data, userData);//Складываем данные из объекта дата в объект юзерДата(не ломая ссылку на объект юзерДата) п.с. на стадии ран
                localStorage.setItem('userData', JSON.stringify(userData));

                userLoaded.deferred().resolve();
                $state.go("userpage", { login: vm.login });
            }, function (res) {
                //$error("Такой пользователь не зарегистрирован (убедитесь что вы пдтвердили авторизацию по почте и данные введены корректно)");
            });
       };
    }]);