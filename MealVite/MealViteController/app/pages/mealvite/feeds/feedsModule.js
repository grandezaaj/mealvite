(function () {
    'use strict';

    angular
        .module('feedsModule', [])
        .service('feedsService', feedsService)
        .controller('feedsController', feedsController);

    feedsService.$inject = ['$http', '$q', 'globals'];
    feedsController.$inject = ['$location', 'feedsService'];

    function feedsService($http, $q, globals) {
        var controllerUrl = globals.serviceUrl + '/Mealvite';

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

    function feedsController($location, feedsService) {
        /* jshint validthis:true */
        var vm = this;
        vm.alerts = [];
        vm.list = [];
        vm.template = "";
        vm.closeAlert = function (index) {
            vm.alerts.splice(index, 1);
        };

        function init() {
            //feedsService.getAll().then(function (data) {
            //    vm.list = data;
            //});

            // TODO: sample data
            var data = [
                {
                    title: 'Carribean Cruise Dinner Course',
                    description: 'Appetizer is lorem ipsum mother fucker',
                    host: 'Jan Patrick Sacay',
                    location: 'El Rio Phase 69, Davao City',
                    price: '200'
                },
                {
                    title: 'Chinese ',
                    description: 'Appetizer is lorem ipsum mother fucker 2',
                    host: 'Eric Bonga',
                    location: 'Country side Bangkal, Davao City',
                    price: '350'
                }
            ];
            vm.list = data;
        }

        init();
    }
})();
