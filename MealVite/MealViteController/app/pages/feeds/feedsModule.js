(function () {
    'use strict';

    angular
        .module('app')
        .controller('feedsModule', feedsModule);

    feedsModule.$inject = ['$location']; 

    function feedsModule($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'feedsModule';

        activate();

        function activate() { }
    }
})();
