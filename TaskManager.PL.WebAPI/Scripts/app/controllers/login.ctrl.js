'use strict';
App.controller('LoginCtrl',
    ["$scope", "$http", "$state", function ($scope, $http, $state) {
        var vm = this;
        vm.login = '';
        vm.password = '';

       vm.loginGo = function () {
           $http.post('Account/Login/', { Login:vm.login, Password: vm.password }/*то что отправляем на сервер по адресу 'AccountController.cs/метод'*/)
            .then(function (res) {
                $state.go("userpage");/*Если всё хорошо(httpStatusCode=200), перейти(go) .state по имени userpage*/
            }, function (res) {
                alert("Такой пользователь не зарегистрирован (убедитесь что вы пдтвердили авторизацию по почте и данные введены корректно)");/*httpStatusCode 400 или 500*/
            });//eslint
       };
    }]);