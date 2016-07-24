'use strict';
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

                userLoaded.deferred().resolve();
                $state.go("userpage");
            }, function (res) {
                alert("Такой пользователь не зарегистрирован (убедитесь что вы пдтвердили авторизацию по почте и данные введены корректно)");
            });
       };
    }]);