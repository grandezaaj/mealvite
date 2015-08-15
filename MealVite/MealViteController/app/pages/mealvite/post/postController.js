'use strict';

function postController(feedsService, $scope, fileReader) {
    var vm = this;
    vm.form = {};
    vm.alerts = [];

    $scope.getFile = function () {
        $scope.progress = 0;
        fileReader.readAsDataUrl($scope.file, $scope)
                      .then(function (result) {
                          $scope.imageSrc = result;
                          $('#submit').prop('disabled', false);
                      });
    };

    vm.save = function () {
        var data = {
            entity: vm.form,
            file: $scope.file
        };

        feedsService.add(data).then(function () {
            vm.alerts.push({ type: 'success', msg: 'Success!' });
        }, function (error) {
            vm.alerts.push({ type: 'danger', msg: error });
        });

    }
}