(function (app)
{
    var homeCtrl = class {
        constructor($scope, apiService)
        {
            let self = this;
            let ctrlScope = $scope;
            this.ctrlScope = ctrlScope;
            this.state = new UsersState(this, apiService);
            ctrlScope.addNewRecord = (inputs, recordForm) =>
            {
                self.state.addNewRecord(inputs, recordForm);
            }
            ctrlScope.cellClickEvent = (row, col) =>
            {
                self.state.cellClickEvent(row, col);
            }
            ctrlScope.removeBtnEvent = (row) =>
            {
                self.state.removeBtnEvent(row);
            }
        }
        get title()
        {
            return this.state.title;
        }
        get backToUsersVisible()
        {
            return this.state.backToUsersVisible;
        }
        get newRecordPlaceholder()
        {
            return this.state.newRecordPlaceholder;
        }
        get gridOpt()
        {
            return this.state.gridOpt;
        }
        get paginOpt()
        {
            return this.state.paginOpt;
        }
        backToUsersHandler()
        {
            this.state.backToUsersHandler();
        }
        pageChanged()
        {
            this.state.pageChanged();
        }
    };

    app.controller('homeCtrl', homeCtrl);

})(angular.module('app'));