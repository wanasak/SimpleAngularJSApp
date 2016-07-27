(function (app) {
    'use strict';

    app.controller('deleteStudentModalCtrl', deleteStudentModalCtrl);

    deleteStudentModalCtrl.$inject = ['$scope', '$modalInstance'];

    function deleteStudentModalCtrl($scope, $modalInstance) {

        $scope.ok = ok;
        $scope.cancel = cancel;

        function ok() {
            $modalInstance.close();
        }

        function cancel() {
            $modalInstance.dismiss();
        }

    }


})(angular.module('simpleAngularJSApp'));