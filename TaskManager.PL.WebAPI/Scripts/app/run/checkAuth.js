'use strict';
App.run(['$http', 'userData', 'userLoaded', function ($http, userData, userLoaded) {
    //to do: get userData from local storage
    var savedUserData = localStorage.getItem('userData');   
    if (savedUserData)
        angular.copy(JSON.parse(savedUserData), userData);

    $http.post('Account/IsAuthorized')
    .then(function (res) {
        var data = res.data;
        angular.copy(data, userData);//Складываем данные из объекта дата в объект юзерДата(не ломая ссылку на объект юзерДата) п.с. на стадии ран
        console.dir(userData);
        userLoaded.deferred().resolve();

    }, function () {

    });

}]);