
var app = angular.module('productApp');
app.controller('productsController', ['$scope', 'productsService', '$rootScope', function ($scope, productsService, $rootScope) {
    
    var vm = this;
    vm.products = [];

    $rootScope.loadProduct = $rootScope.loadProduct == undefined ? true : false;

    if ($rootScope.loadProduct) {
        productsService.loadProduct(productsLoaded);
        
    } else {
        $rootScope.loadProduct = true;
    }


    function productsLoaded(data, responseText, response) {
        vm.products = data;

    }
    


}]);