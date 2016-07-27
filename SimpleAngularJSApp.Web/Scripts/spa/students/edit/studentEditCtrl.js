(function (app) {
    'use strict';

    app.controller('studentEditCtrl', studentEditCtrl);

    studentEditCtrl.$inject = ['$scope', '$http', '$routeParams', '$location'];

    function studentEditCtrl($scope, $http, $routeParams, $location) {

        $scope.pageClass = 'container';
        $scope.editStudent = editStudent;

        function editStudent() {
            $http.post("api/student/edit", $scope.student)
                .then(function (result) {
                    $location.path('#/');
                }, function (response) {

                });
        }

        function loadStudent() {
            $http.get("api/student/edit/" + $routeParams.id, $scope.student)
                .then(function (result) {
                    $scope.student = result.data;
                }, function (response) {

                });
        }

        loadStudent();

    }

})(angular.module('simpleAngularJSApp'));