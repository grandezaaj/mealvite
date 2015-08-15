(function () {
    'use strict';

    angular.module('app', [
        'ui.router',
        'ui.bootstrap',
        'angular-loading-bar',
        'feedsModule'
    ])
     .run([
            '$rootScope',
            '$location',
            function run(
                $rootScope, $location) {
                $rootScope.location = $location;
            }])
        .value('globals', {
            rootUrl: window.location.origin + '/',
            ServiceUrl: window.location.origin + '/api',
        })
    .config([
            '$stateProvider',
            '$urlRouterProvider',
            '$httpProvider',
            'cfpLoadingBarProvider',
            function config(
                $stateProvider, $urlRouterProvider, $httpProvider, cfpLoadingBarProvider) {
                cfpLoadingBarProvider.includeSpinner = false;
                $stateProvider
                    .state('module', {
                        url: '/:pageName',
                        templateUrl: function ($stateParams) {
                            return 'app/pages/' + $stateParams.pageName + '/' + $stateParams.pageName + '.html'
                        }
                    })

                    .state('submodule', {
                        url: '/:pageName/:subpageName',
                        templateUrl: function ($stateParams) {
                            return 'app/pages/' + $stateParams.pageName + '/' + $stateParams.subpageName + '/' + $stateParams.subpageName + '.html';
                        }
                    })

                $urlRouterProvider.otherwise('/accounts/login');
            }])
})();
