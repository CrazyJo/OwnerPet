class PetsState extends State {
    constructor(owner, context, apiService, restorePage = null) {
        super(context, apiService, new RequestDetails('/api/pets/', new PetsRequest(owner.id)));
        this.waybackHome = restorePage;
        this.backToUsersVisible = true;
        this.owner = owner;
        this.title = this.getTitle();
        this.newRecordPlaceholder = 'Enter Pet\'s Name';
        if (owner.petsCount > 0)
            this.updateGrid();
    }
    buildNewEntityForPost(inputs) {
        return new Pet(inputs.newRecord, this.owner.id);
    }
    getTitle() {
        return PossessiveCaseFormatter.convert(this.owner.name) + " pets";
    }
    cellClickEvent(row, col) {
    }
    backToUsersHandler() {
        this.context.state = new UsersState(this.context, this.apiService, this.waybackHome);
    }
    getColumnDefs() {
        let columnBuilder = new ColumnDefBuilder();
        columnBuilder.addColumn('name', true);
        return columnBuilder.getColumns();
    }
}
//# sourceMappingURL=petsState.js.map