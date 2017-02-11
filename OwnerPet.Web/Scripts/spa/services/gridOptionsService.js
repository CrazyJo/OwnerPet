(function (app)
{
    'use strict';

    app.factory('gridOptionsService', function ()
    {
        debugger;

        var gridOptions = {
            useExternalSorting: true,
            data: [],
            excludeProperties: ['id'],
            columnDefs: [
                { field: 'name', cellTemplate: customCellTemplate },
                { field: 'petsCount', enableSorting: false },
                { name: 'delete', displayName: '', width: '10%', enableSorting: false, cellTemplate: removeTemplate }
            ],
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            onRegisterApi: function (gridApi)
            {
                gridApi.core.on.sortChanged($scope, sortChangedCallback);
            }
        };

        var service = {
            removeBtnTemplate: '',
            customCellTemplate: '',
            setData: '',
            getData: '',
            sortChangedCallback: '',
            gridOptions: gridOptions
        };


        return service;
    });

})(angular.module('app'));