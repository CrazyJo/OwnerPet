class ColumnDefBuilder {
    constructor() {
        this.customCellTemplate = '/Scripts/spa/views/shared/grid/_customCell.html';
        this.removeTemplate = '/Scripts/spa/views/shared/grid/_removeBtn.html';
        this.columnDefs = new Array();
    }
    addColumn(field, enableSorting) {
        let newColumn = new ColumnDef();
        newColumn.cellTemplate = this.customCellTemplate;
        newColumn.field = field;
        newColumn.enableSorting = enableSorting;
        this.columnDefs.push(newColumn);
    }
    addRemoveColumn() {
        let newColumn = new ColumnDef();
        newColumn.cellTemplate = this.removeTemplate;
        newColumn.name = 'delete';
        newColumn.enableSorting = false;
        newColumn.displayName = '';
        newColumn.width = '13%';
        this.columnDefs.push(newColumn);
    }
    addServicesColumn() {
        this.addRemoveColumn();
    }
    getColumns() {
        this.addServicesColumn();
        return this.columnDefs;
    }
}
//# sourceMappingURL=columnDefBuilder.js.map