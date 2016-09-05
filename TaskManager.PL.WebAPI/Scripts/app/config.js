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
            data: {
                access: {
                    roles: []
                }
            }
        })
        .state('userpage', {
            url: '/userpage',
            templateUrl: 'UserPage.html',
            controller: 'UserCtrl',
            controllerAs: 'userpage',
            resolve: {//использовать во всех стейтах, внутри которых нам нужны данные из userData
                userIsLoaded: ['userLoaded', function (userLoaded) {
                    return userLoaded.deferred().promise;
                }]
            },
            data: {
                access: {
                    roles: ['User', 'Manager', 'Admin']
                }
            }
        })
       .state('loginpage', {/*это важно*/
           url: '/loginpage',
           templateUrl: 'LoginPage.html',/*Имя вьюшки*/
           controller: 'LoginCtrl',/*Это имя ангуляр контроллера (*.ctrl.js)*/
           controllerAs: 'loginpage'/*на вьюшке спрашиваем это (это же this  в контроллере js)*/,
           data: {// сюда дозволено ходить всем
               access: {
                   roles: []
               }
           }
       })
        .state('registrationpage', {
            url: '/registrationpage',
            templateUrl: 'RegistrationPage.html',
            controller: 'RegistrationCtrl',
            controllerAs: 'registrationpage',
            data: {
                access: {
                    roles: []
                }
            }
        })
    .state('projectpage', {
        url: '/project?projectId',
        templateUrl: 'ProjectPage.html',
        controller: 'ProjectCtrl',
        controllerAs: 'projectpage',
        params: {
            projectId: {
                value: ''
            }
        },
        data: {
            access: {
                roles: ['User', 'Manager', 'Admin']
            }
        }
    })

    .state('page1', {
        url: '/page1',
        templateUrl: 'Page1.html',
        data: {
            access: {
                roles: ['User', 'Manager', 'Admin']
            }
        }
    })

    .state('page2', {
        url: '/page2',
        templateUrl: 'Page2.html',
        data: {
            access: {
                roles: ['User', 'Manager', 'Admin']
            }
        }
    });
}]);