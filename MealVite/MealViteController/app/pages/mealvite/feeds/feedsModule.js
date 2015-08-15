(function () {
    'use strict';

    angular
        .module('feedsModule', [])
        .service('feedsService', feedsService)
        .controller('feedsController', feedsController)
        .controller('feedsReserveControllerModalCtrl', feedsReserveControllerModalCtrl)
        .controller('postController', postController)

    feedsService.$inject = ['$http', '$q', 'globals'];
    feedsController.$inject = ['$location', 'feedsService', '$modal'];
    feedsReserveControllerModalCtrl.$inject = ['$modalInstance', 'items'];
    postController.$inject = ['feedsService', '$scope', 'fileReader'];

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
                    data: entity,
                    headers: { 'Content-Type': undefined },
                    transformRequest: function (data) {
                        var formData = new FormData();
                        formData.append("entity", angular.toJson(data.entity));
                        //angular.forEach(data.files, function (file, key) {
                            formData.append(data.file.name, data.file);
                        //});

                        return formData;
                    }
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

    function feedsController($location, feedsService, $modal) {
        /* jshint validthis:true */
        var vm = this;
        vm.alerts = [];
        vm.list = [];
        vm.template = "app/pages/mealvite/feeds/feedTemplate.html";
        vm.closeAlert = function (index) {
            vm.alerts.splice(index, 1);
        };

        vm.open = function () {
            var modalInstance = $modal.open({
                animation: vm.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'feedsReserveControllerModalCtrl as ct',
                windowClass: 'app-window-size',
                resolve: {
                    items: function () {
                        return vm.list;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                vm.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        vm.toggleAnimation = function () {
            vm.animationsEnabled = !vm.animationsEnabled;
        };

        function init() {
            feedsService.getAll().then(function (data) {
                vm.list = data;
            });          
        }

        init();
    }


    function feedsReserveControllerModalCtrl($modalInstance, items) {
        var vm = this;

        vm.items = items;
        vm.selected = {
            item: vm.items[0]
        };

        vm.ok = function () {
            $modalInstance.close(vm.selected.item);
        };

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
})();
