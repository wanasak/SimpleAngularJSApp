(function (app) {
    'use strict';

    app.controller('studentIndexCtrl', studentIndexCtrl);

    studentIndexCtrl.$inject = ['$scope', '$http', '$location', '$modal'];

    function studentIndexCtrl($scope, $http, $location, $modal) {

        $scope.pageClass = 'container';
        $scope.students = [];
        $scope.deleteStudent = deleteStudent;

        function deleteStudent(index, id) {
            $modal.open({
                templateUrl: "scripts/spa/students/index/deleteStudentModal.html",
                controller: "deleteStudentModalCtrl",
                size: 'sm',
                scope: $scope
            }).result.then(function () {
                $http.get("api/student/delete/" + id, null)
                    .then(function (result) {
                        $scope.students.splice(index, 1);
                    }, function (response) {

                    });
            }, function (error) {
            });
        }

        function loadStudents() {
            $http.get("api/student", null)
                .then(function (result) {
                    $scope.students = result.data;
                }, function (response) {

                });
        }

        loadStudents();

    }


})(angular.module('simpleAngularJSApp'));