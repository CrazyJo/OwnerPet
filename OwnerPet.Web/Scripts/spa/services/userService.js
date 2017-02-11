(function (app)
{
    'use strict';

    app.factory('usersService', usersService);

    usersService.$inject = ['apiService'];

    function usersService(apiService)
    {
        var service = {
            getUsers: getUsers,
            postUser: postUser,
            removeUser: removeUser
        };

        function getUsers(params, success, failure)
        {
            var config = {
                params: params
                //    {
                //    pageIndex: page,
                //    pageSize: 5,
                //    orderBy: 'id',
                //    descending: true
                //}
            };
            apiService.get('/api/users/', config, success, failure);
        }

        function postUser(user, success, failure)
        {
            apiService.post('/api/users/', user, success, failure);
        }

        function removeUser(userId, success, failure)
        {
            debugger;
            var url = '/api/users/' + userId;
            apiService.remove(url, success, failure);
        }

        return service;
    }

})(angular.module('app'));