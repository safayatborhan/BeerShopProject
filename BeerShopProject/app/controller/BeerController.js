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

    //for posting data into server side
    $scope.beer = {}; //The reason of using the curly bracket is to store json object, I suppose. It's my hypothesis
    $scope.addBeer = function () {
        $scope.isAdding = true;  //this will start the spinning
        $http.post('/BeerEditVMs/AddBearIntoDB', $scope.beer).success(function (data) {
            //$scope.dataFromJson.Beers.push(data);
            $scope.isAdding = false;  //this will stop the spinning
            $scope.dataFromJson.push(data);
            $scope.beer = {};
        })
    };

    //This variable makes a condition when the loading spin will start and when end
    $scope.isAdding = false;
});