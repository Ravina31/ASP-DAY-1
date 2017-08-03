
var app = angular.module('myApp', []);//set and get the angular module
app.controller('studentController', ['$scope', '$http', studentController]);

app.directive('ngConfirmClick', [
    function () {
        return {
            priority: 1,
            terminal: true,
            link: function (scope, element, attr) {
                var msg = attr.ngConfirmClick || "Are you sure?";
                var clickAction = attr.ngClick;
                element.bind('click', function (event) {
                    if (window.confirm(msg)) {
                        scope.$eval(clickAction)
                    }
                });
            }
        };
    }]);

//angularjs controller method
function studentController($scope, $http) {

    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all Student information
    $http.get('/api/StudentApi/').success(function (data) {
        $scope.students = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.student.editMode = !this.student.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Inser Student
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/StudentApi/', this.newstudent).success(function (data) {
            $scope.addMode = false;
            $scope.students.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Student! " + data;
            $scope.loading = false;
        });
    };

    //Edit Student
    $scope.save = function () {
        $scope.loading = true;
        var frien = this.student;
        $http.put('/api/StudentApi/' + frien.Id, frien).success(function (data) {
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Student! " + data;
            $scope.loading = false;
        });
    };

    //Delete Student
    $scope.deletestudent = function () {
        $scope.loading = true;
        var Id = this.student.Id;
        $http.delete('/api/StudentApi/' + Id).success(function (data) {
            $.each($scope.students, function (i) {
                if ($scope.students[i].Id === Id) {
                    $scope.students.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Student! " + data;
            $scope.loading = false;
        });
    };
}