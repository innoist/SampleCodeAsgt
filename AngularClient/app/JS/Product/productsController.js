
var app = angular.module('productApp');
app.controller('productsController', ['$scope', 'productsService', function ($scope, productsService) {
    
    var vm = this;
    vm.hello = 'Hi';
    productsService.loadProduct(productsLoaded, productsFailed);


    function productsLoaded(data, responseText, response) {
        debugger
        $location.url('#/products');
    }
    function productsFailed(data, data2) {
        
    }


}]);