'use strict';
App.run(['$rootScope', 'Auth', '$state', function ($rootScope, Auth, $state) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState) {
        if (!('data' in toState) || !('access' in toState.data)) {
            $rootScope.error = 'Access undefined for this state';
            event.preventDefault();
        } else if (!Auth.isAvailable(toState.data.access)) {
            event.preventDefault();
            $state.go('home');
        }
    });

}]);