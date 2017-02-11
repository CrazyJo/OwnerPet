class UsersState extends State {
    constructor(context, apiService, wayBackHome = null) {
        super(context, apiService, null);
        this.restorePreviousState(wayBackHome);
        this.backToUsersVisible = false;
        this.title = 'All Users';
        this.newRecordPlaceholder = 'Enter Pet Owner\'s Name';
        this.updateGrid();
    }
    getColumnDefs() {
        let columnBuilder = new ColumnDefBuilder();
        columnBuilder.addColumn('name', true);
        columnBuilder.addColumn('petsCount', false);
        return columnBuilder.getColumns();
    }
    cellClickEvent(row, col) {
        if (col.field === 'name') {
            this.context.state = new PetsState(row.entity, this.context, this.apiService, this.createWaybackHome());
        }
    }
    restorePreviousState(wayBackHome) {
        let rP;
        if (wayBackHome !== null) {
            rP = wayBackHome.restorePage || new RequestedPage();
            this.paginOpt = wayBackHome.paginOpt;
        }
        else {
            rP = new RequestedPage();
        }
        this.requestDetails = new RequestDetails('/api/users/', rP);
    }
    createWaybackHome() {
        return new WayBackHome(this.paginOpt, this.requestDetails.requestedPage);
    }
    backToUsersHandler() {
    }
}
//# sourceMappingURL=usersState.js.map