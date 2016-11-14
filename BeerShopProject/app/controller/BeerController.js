angular.module("BeerShopProject.BeerController", [])
.controller("BeerController", function ($scope,$http) {
    $scope.message = "This is beer controller from angular";

    //we are gonna create a object, from which we will fetch data
    $scope.dataFromJson = {};

    //this will get if the add form will load or not
    $scope.showOrNotAtFirst = false;
    $scope.showOrNot = function (data) {
        $scope.showOrNotAtFirst = data;
    }


    //thid http.get will get the url's json data and automatically serialize into javascript variable
    $http.get('/BeerEditVMs/IndexForJson')
        .success(function (data) {
            $scope.dataFromJson = data;
        });
});