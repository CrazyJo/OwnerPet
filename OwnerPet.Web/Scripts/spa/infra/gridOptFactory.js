class GridOptFactory {
    constructor(ctrlScope, sortChangedCallback) {
        this.ctrlScope = ctrlScope;
        this.sortChangedCallback = sortChangedCallback;
        this.gridOpt = new GridOpt();
        this.gridOpt.useExternalSorting = true;
        this.gridOpt.enableHorizontalScrollbar = 0;
        this.gridOpt.enableVerticalScrollbar = 0;
        this.gridOpt.enableColumnMenus = false;
        this.gridOpt.data = [];
        this.gridOpt.onRegisterApi = (gridApi) => {
            gridApi.core.on.sortChanged(ctrlScope, (grid, sortColumns) => {
                if (sortColumns.length !== 0) {
                    let direction = sortColumns[0].sort.direction;
                    let descending = direction === 'asc' ? false : true;
                    sortChangedCallback(descending);
                }
            });
        };
    }
    getOpt() {
        return this.gridOpt;
    }
}
//# sourceMappingURL=gridOptFactory.js.map