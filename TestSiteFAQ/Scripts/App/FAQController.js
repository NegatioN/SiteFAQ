/// <reference path="../LIBJS/jquery-2.1.1.js" />
var App = angular.module("App", []);

App.controller("FAQController", function ($scope, $http) {

    //TODO make loading-thing be a spinning load-image?

    var url = '/api/FAQ/';
    //used for sectioning the FAQ's into different tables.
    var faqCategories = ["Betaling", "Siden", "Om oss", "Handel"];

    console.log("FAQ-controller.js found");

    function getAllFaqs() {
        //define bool-states for single-page applcation
        $scope.visFaqs = true;
        $scope.regKnapp = true;
        $scope.laster = true;
        $scope.registrering = false;
        $scope.sendSpm = false;
        $scope.showRecipt = false;


        $http.get(url).
          success(function (allFaqs) {
              // $scope.faqs = allFaqs;
              var allCategories = new Array();
              for (var i = 0; i<faqCategories.length;i++) {
                  var Category = {
                      Heading: faqCategories[i],
                      Items: new Array()
                  }
                  console.log("Heading: " + Category.Heading);
                  //add all faqs to the category.
                  for (var i = 0; i < allFaqs.length; i++) {
                      var faq = allFaqs[i];
                      console.log(faq.Heading);
                      if (faq.Category == Category.Heading) {
                          Category.Items.push(faq);
                          console.log("is added to: " + Category.Heading);
                      }
                  }
                  allCategories.push(Category);
                  $scope.faqs = Category.Items;
              }
              $scope.categories = allCategories;

              $scope.laster = false;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    //gets called on Controller-start
    getAllFaqs();


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

    //regex used for splitting up descriptions of each FAQ into several paragraphs based on newlines
    $scope.regexFilter = function (faq) {
        var feedback = faq.Description.split(/\n/);

        return feedback;
    };

});
