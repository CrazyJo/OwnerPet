class State {
    constructor(context, apiService, requestDetails) {
        this.context = context;
        this.apiService = apiService;
        this.title = null;
        this.newRecordPlaceholder = null;
        this.gridOpt = new GridOptFactory(context.ctrlScope, (d) => this.sortChangedHandler(d)).getOpt();
        this.gridOpt.columnDefs = this.getColumnDefs();
        this.paginOpt = new PaginOpt();
        this.requestDetails = requestDetails;
    }
    getHttpConfig() {
        let config = new HttpRequestConfig();
        config.params = this.requestDetails.requestedPage;
        return config;
    }
    updateGrid() {
        let config = this.getHttpConfig();
        this.apiService.get(this.requestDetails.url, config, (result) => {
            this.paginOpt.totalItems = result.data.totalCount;
            this.gridOpt.data = result.data.items;
        }, null);
    }
    addNewRecord(inputs, recordForm) {
        if (recordForm.$valid && inputs !== undefined) {
            let entity = this.buildNewEntityForPost(inputs);
            this.apiService.post(this.requestDetails.url, entity, () => this.updateGrid(), null);
        }
    }
    buildNewEntityForPost(inputs) {
        return new BaseEntity(inputs.newRecord);
    }
    sortChangedHandler(descending) {
        if (descending !== this.requestDetails.requestedPage.descending) {
            this.requestDetails.requestedPage.descending = descending;
            this.updateGrid();
        }
    }
    pageChanged() {
        this.requestDetails.requestedPage.pageIndex = this.paginOpt.currentPage;
        this.updateGrid();
    }
    removeBtnEvent(row) {
        let url = this.requestDetails.url + row.entity.id;
        this.apiService.remove(url, () => {
            if (this.wasLastElement()) {
                this.clearGrid();
            }
            else {
                this.updateGrid();
            }
        }, null);
    }
    clearGrid() {
        this.gridOpt.data = [];
        this.paginOpt.totalItems = 0;
    }
    wasLastElement() {
        return this.paginOpt.totalItems === 1;
    }
}
//# sourceMappingURL=state.js.map