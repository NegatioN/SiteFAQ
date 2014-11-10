/// <reference path="../LIBJS/jquery-2.1.1.js" />
var App = angular.module("App", []);

App.controller("FAQController", function ($scope, $http) {

    var url = '/api/FAQ/';

    console.log("FAQ-controller.js found");

    function getAllFaqs() {
        //define bools for single-page applcation
        $scope.showAFAQ = false;
        $scope.registrering = false;


        $http.get(url).
          success(function (allFaqs) {
              $scope.faqs = allFaqs;
              $scope.laster = false;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
    console.log("Much console");
    $scope.visFaqs = true;
    $scope.regKnapp = true;
    $scope.laster = true;
    getAllFaqs();


    $scope.showSingleFAQ = function(FAQ) {
        //define bools for single-page applcation
        $scope.showAFAQ = true;
        $scope.visFaqs = false;
        $scope.registrering = false;

        console.log("In ShowSingleFAQ");

        $scope.currentHeading = FAQ.Heading;
        $scope.currentDescription = FAQ.Description;

        console.log($scope.currentHeading);
        console.log($scope.currentDescription);
    };

    $scope.visSendSpm = function () {
        $scope.epost = "";
        $scope.sporsmal = "";
        // for å unngå at noen av feltene gir "falske" feilmeldinger 
        $scope.skjema.$setPristine();
        $scope.regKnapp = false; // dette er knappen fra listen av kunder til reg-skjema
        $scope.sendSpm = true;
        $scope.visFaqs = false;
        $scope.registrering = true; // dette er knappen for å registrere i form´en.

        console.log("In showSendSpm");
    };

    $scope.sendQuestion = function () {
        // lag et object for overføring til server via post
        console.log("Inne i registerKunde");
        var question = {
            epost: $scope.epost,
            sporsmal: $scope.sporsmal
        };
        console.log(question.epost);
        console.log(question.sporsmal);
    };

});