'use strict'
App.service('userLoaded', ['$q', function ($q) {
    var deferred = $q.defer();
    this.deferred = function () {
        return deferred;
    };

    this.reset = function () {
        deferred = $q.defer();
    };
}]);
