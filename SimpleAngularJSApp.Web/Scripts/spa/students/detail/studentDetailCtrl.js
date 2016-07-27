(function (app) {
    'use strict';

    app.controller('studentDetailCtrl', studentDetailCtrl);

    studentDetailCtrl.$inject = ['$scope', '$http', '$routeParams'];

    function studentDetailCtrl($scope, $http, $routeParams) {

        $scope.pageClass = 'container';
        $scope.student = {};

        function loadStudentDetail() {
            $http.get("api/student/detail/" + $routeParams.id, null)
                .then(function (result) {
                    $scope.student = result.data;
                }, function (response) {

                });
        }

        loadStudentDetail();

    }


})(angular.module('simpleAngularJSApp'));