var app = angular.module('app1', []);

app.controller('DataCtrl', function ($scope, $http) {

    $http.get("http://localhost:49964/api/CSM_PaymentTerm/")
      .then(function (response) {
          $scope.book = response.data;
      });

    function post($scope, $http) {
        var url = 'http://localhost:49964/api/CSM_PaymentTerm/', data = 'JSON.stringify(data)';
        $http.post(url, data).then(function (response) {

        });
    };

     $scope.names = ['morpheus', 'neo', 'trinity'];




});