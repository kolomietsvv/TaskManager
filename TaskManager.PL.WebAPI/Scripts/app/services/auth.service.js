'use strict'
App.service('Auth', ['userData', function (userData) {
    this.isAvailable = function (access) {
        return access.roles.length === 0 || userData.Roles && _.intersection(userData.Roles, access.roles).length;
    };

}]);
