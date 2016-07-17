'use strict';
App.run(['$http', 'userData', function ($http, userData) {
    $http.post('Account/IsAuthorized')
    .then(function (res) {
        var data = res.data;
        angular.copy(data, userData);//Складываем данные из объекта дата в объект юзерДата(не ломая ссылку на объект юзерДата) п.с. на стадии ран
        console.dir(userData);
    }, function () {

    });

}]);