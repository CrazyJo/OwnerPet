(function (app)
{
    'use strict';

    app.factory('apiService', apiService);

    apiService.$inject = ['$http', '$location', '$rootScope'];

    function apiService($http, $location, $rootScope)
    {
        var service = {
            get: get,
            post: post,
            remove: remove
        };

        function get(url, config, success, failure)
        {
            return $http.get(url, config)
                    .then(function (result)
                    {
                        success(result);
                    }, function (error)
                    {
                        if (failure != null)
                        {
                            failure(error);
                        }
                    });
        }

        function post(url, data, success, failure)
        {
            return $http.post(url, JSON.stringify(data))
                    .then(function (result)
                    {
                        success(result);
                    }, function (error)
                    {
                        if (failure != null)
                        {
                            failure(error);
                        }
                    });
        }

        function remove(url, success, failure)
        {
            return $http.delete(url).then(function (result)
            {
                success(result);
            },
            function (error)
            {
                if (failure != null)
                {
                    failure(error);
                }
            });
        }

        return service;
    }

})(angular.module('app'));