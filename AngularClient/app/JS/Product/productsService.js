var app = angular.module('productApp');
app.service('productsService', ['$http','productConstants', function ($http,prodConstants) {
    this.loadProduct= function (onSuccess, onError) {
        
        onError = onError || function () { alert('Failure saving Data'); };
        $http
            .get(prodConstants.url.apiURL + prodConstants.url.products)
            .success(onSuccess)
            .error(onError);
    };


    this.loadProductById = function (id,onSuccess, onError) {

        onError = onError || function () { alert('Failure saving Data'); };
        $http
            .get(prodConstants.url.apiURL + prodConstants.url.products+"/"+id)
            .success(onSuccess)
            .error(onError);
    };

    this.saveProduct = function (data, onReady, onError) {

        //var urlMetaData = window.frsApiUrl + '/api/LoadMetaData';

        onError = onError || function () { alert('Failure saving Data'); };

        $http(
            {
                method: 'POST',
                url: prodConstants.url.apiURL + prodConstants.url.products,
                data: JSON.stringify(data)
            }
          )
          .then(onReady, onError);
    }
}]);

