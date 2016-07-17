/// <reference path="D:\TaskManager\TaskManager.PL.WebAPI\bower_components/angular/angular.js" />
'use strict';

App.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/home");

    $stateProvider
        .state('home', {
            url: '/home',
            templateUrl: 'Home.html',
            controller: 'HomeCtrl',
            controllerAs: 'home',
        })
        .state('userpage', {
            url: '/userpage',
            templateUrl: 'UserPage.html',
            controller: 'UserCtrl',
            controllerAs: 'userpage'
        })
       .state('loginpage', {/*это важно*/
           url: '/loginpage',
           templateUrl: 'LoginPage.html',/*Имя вьюшки*/
           controller: 'LoginCtrl',/*Это имя ангуляр контроллера (*.ctrl.js)*/
           controllerAs: 'loginpage'/*на вьюшке спрашиваем это (это же this  в контроллере js)*/
       })
        .state('registrationpage', {
            url: '/registrationpage',
            templateUrl: 'RegistrationPage.html',
            controller: 'RegistrationCtrl',
            controllerAs: 'registrationpage'
        })
    .state('page1', {
        url: '/page1',
        templateUrl: 'Page1.html'
    })
    .state('page2', {
        url: '/page2',
        templateUrl: 'Page2.html'
    });


}]);