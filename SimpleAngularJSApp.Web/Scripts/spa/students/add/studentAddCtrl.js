(function (app) {
    'use strict';

    app.controller('studentAddCtrl', studentAddCtrl);

    studentAddCtrl.$inject = ['$scope', '$http', '$location'];

    function studentAddCtrl($scope, $http, $location) {

        $scope.pageClass = 'container';
        $scope.student = {
            FirstName: '',
            LastName: '',
            BirthDate: new Date()
        };
        $scope.addStudent = addStudent;
        // for datetime picker
        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };  

        function addStudent() {

            $http.post("api/student/add", $scope.student)
                .then(function (result) {
                    $location.path("#/");
                }, function (response) {

                });
        }

    }

})(angular.module('simpleAngularJSApp'));