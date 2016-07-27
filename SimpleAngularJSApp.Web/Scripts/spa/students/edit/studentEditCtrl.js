(function (app) {
    'use strict';

    app.controller('studentEditCtrl', studentEditCtrl);

    studentEditCtrl.$inject = ['$scope', '$http', '$routeParams', '$location'];

    function studentEditCtrl($scope, $http, $routeParams, $location) {

        $scope.pageClass = 'container';
        $scope.editStudent = editStudent;
        // for datetime picker
        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

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
                    $scope.student.BirthDate = new Date(result.data.BirthDate);
                }, function (response) {

                });
        }

        loadStudent();

    }

})(angular.module('simpleAngularJSApp'));