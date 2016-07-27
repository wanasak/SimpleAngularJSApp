(function () {
    'use strict';

    angular.module('simpleAngularJSApp', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/students/index/index.html",
                controller: "studentIndexCtrl"
            })
            .when("/student/add", {
                templateUrl: "scripts/spa/students/add/studentAdd.html",
                controller: "studentAddCtrl"
            })
            .when("/student/edit/:id", {
                templateUrl: "scripts/spa/students/edit/studentEdit.html",
                controller: "studentEditCtrl"
            })
            .when("/student/detail/:id", {
                templateUrl: "scripts/spa/students/detail/studentDetail.html",
                controller: "studentDetailCtrl"
            })
            .otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$http'];

    function run($rootScope, $location, $http) 
    {
        
    }

})();