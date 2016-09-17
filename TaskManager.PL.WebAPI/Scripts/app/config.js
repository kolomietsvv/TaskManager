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
            url: '/userpage?login',
            templateUrl: 'UserPage.html',
            controller: 'UserCtrl',
            controllerAs: 'userpage',
            params: {
                login: {
                    value: ''
                }
            },
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

        .state('taskpage', {
            url: '/task?taskId',
            templateUrl: 'TaskPage.html',
            controller: 'TaskCtrl',
            controllerAs: 'taskpage',
            params: {
                taskId: {
                    value: ''
                }
            },
            data: {
                access: {
                    roles: ['User', 'Manager', 'Admin']
                }
            }
        })
    .state('searchpage', {
        url: '/search',
        templateUrl: 'SearchPage.html',
        controller: 'SearchCtrl',
        controllerAs: 'searchpage',
        data: {
            access: {
                roles: ['User', 'Manager', 'Admin']
            }
        }
    });
}]);