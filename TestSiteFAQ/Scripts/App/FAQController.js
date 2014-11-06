var App = angular.module("App", []);

App.controller("FAQController", function ($scope, $http) {

    var url = '/api/FAQ/';

    $scope.sletteFeil = false;

    console.log("FAQ-controller.js found");

    function getAllFaqs() {
        $scope.sletteFeil = false;
        $http.get(url).
          success(function (allFaqs) {
              $scope.faqs = allFaqs;
              $scope.laster = false;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
    $scope.visFaqs = true;
    $scope.regKnapp = true;
    $scope.laster = true;
    getAllFaqs();

});