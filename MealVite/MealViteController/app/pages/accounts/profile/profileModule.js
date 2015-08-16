(function () {
    'use strict';

    angular
        .module('profileModule', [])
        .service('profileService', profileService)
        .controller('profileController', profileController)

    profileService.$inject = ['$http', '$q', 'globals'];
    profileController.$inject = ['profileService', '$stateParams'];

    function profileService($http, $q, globals) {
        var controllerUrl = globals.serviceUrl + '/Profile';

        return {
            getAll: function () {
                var deferred = $q.defer();
                $http({
                    method: 'GET',
                    url: controllerUrl + '/List'
                }).success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
                return deferred.promise;
            },
            add: function (entity) {
                var deferred = $q.defer();
                $http({
                    method: 'POST',
                    url: controllerUrl + '/Add',
                    data: entity
                }).success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
                return deferred.promise;
            },
            update: function (entity) {
                var deferred = $q.defer();
                $http({
                    method: 'PUT',
                    url: controllerUrl + '/Update',
                    data: entity
                }).success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
                return deferred.promise;
            },
            find: function (id) {
                var deferred = $q.defer();
                $http({
                    method: 'GET',
                    url: controllerUrl + '/' + id
                }).success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
                return deferred.promise;
            },
            remove: function (id) {
                var deferred = $q.defer();
                $http({
                    method: 'PUT',
                    url: controllerUrl + '/Delete/' + id
                }).success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).error(function (data, status, headers, config) {
                    deferred.reject(status);
                });
                return deferred.promise;
            }
        }
    }

    function profileController(profileService, $stateParams) {
        var vm = this;
        vm.alerts = [];
        vm.entity = {};
        var init = function () {
            profileService.find($stateParams.id).then(function (data) {
                vm.entity = data;
            });
        }

        init();

    }
})();
