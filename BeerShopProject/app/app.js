/// <reference path="E:\MY WORLD\latest programming\Angular js with ASP.NET MVC\BeerShopProject\BeerShopProject\Scripts/angular.js" />

angular.module("app", ["BeerShopProject.BeerController"])
    //We will make a custom directive to implement loading button. If we make this in app, then we will be able to use all over the project. 
    //and if we make this in controller, we will only be able to use this in the corresponding controller
    .directive('loadingButton', function () {

    });