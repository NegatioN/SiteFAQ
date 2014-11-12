/// <reference path="../LIBJS/jquery-2.1.1.js" />
var App = angular.module("App", []);

App.controller("FAQController", function ($scope, $http) {

    //TODO make loading-thing be a spinning load-image?

    var url = '/api/FAQ/';

    console.log("FAQ-controller.js found");

    function getAllFaqs() {
        //define bool-states for single-page applcation
        $scope.showAFAQ = false;
        $scope.registrering = false;
        $scope.visFaqs = true;
        $scope.regKnapp = true;
        $scope.laster = true;
        $scope.registrering = false;
        $scope.sendSpm = false;
        $scope.showRecipt = false;


        $http.get(url).
          success(function (allFaqs) {
              $scope.faqs = allFaqs;
              $scope.laster = false;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    //gets called on Controller-start
    getAllFaqs();

    /*
    $scope.showSingleFAQ = function(FAQ) {
        //define bool-states for single-page applcation
        $scope.visFaqs = false;
        $scope.registrering = false;
        $scope.showAFAQ = true;

        console.log("In ShowSingleFAQ");

        var currentFAQ = {
            Heading: FAQ.Heading,
            Description: FAQ.Description
        }
        $scope.current = currentFAQ;

        console.log($scope.current.Heading);
        console.log($scope.current.Description);

    };
    */

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

    //gets called on button-press in showQuestion-form
    $scope.sendQuestion = function () {
        // lag et object for overføring til server via post
        console.log("Inne i registerKunde");
        var question = {
            Email: $scope.epost,
            Description: $scope.sporsmal
        };
        $scope.newQuestion = question;
        console.log(question.Email);
        console.log(question.Description);

        //HTTP POST
        $http.post(url, question).
         success(function (data) {
             console.log("Lagre kunder OK!")
             $scope.showRecipt = true;
             //sett noe laster? som i sending
        }).
         error(function (data, status) {
            console.log(status + data);
  });

        //change state-bools
        $scope.sendSpm = false;
        $scope.registrering = false;
    };

    //method called for goBack-button
    $scope.goBack = function () {
        console.log("goBack called");
        getAllFaqs();
    };

    //toggles descriptions on each FAQ
    $scope.toggleDetail = function ($index) {
        $scope.activePosition = $scope.activePosition == $index ? -1 : $index;
    };

});
