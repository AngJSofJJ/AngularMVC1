
var myApp = angular.module('myApp', []);

myApp.controller('mainController', function ($scope, $http) {
    $http.get('/Home/GetProducts')
    .success(function (result) {
        $scope.products = result;
    })
    .error(function (data) {
        console.log(data);
    });


    $scope.newProduct = "";
    $scope.newProductPrice = "";
    $scope.newProductType = "";
    $scope.addProduct = function () {
        $http.post('/Home/AddProduct/', { newProduct: $scope.newProduct, newProductPrice: $scope.newProductPrice, newProductType :$scope.newProductType })
        .success(function (result) {
            $scope.products = result;
            $scope.newProduct = "";
            $scope.newProductPrice = "";
            $scope.newProductType = "";
        })
        .error(function (data) {
            console.log(data);
        });
    }

    $scope.deleteProduct = function (product) {
        $http.post('/Home/DeleteProduct/', { delProduct: product })
        .success(function (result) {
            $scope.products = result;
        })
        .error(function (data) {
            console.log(data);
        });
    }
});