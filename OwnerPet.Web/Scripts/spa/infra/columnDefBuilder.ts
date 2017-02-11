class ColumnDefBuilder
{
    customCellTemplate: string;
    removeTemplate: string;
    columnDefs: ColumnDef[];

    constructor()
    {
        this.customCellTemplate = '/Scripts/spa/views/shared/grid/_customCell.html';
        this.removeTemplate = '/Scripts/spa/views/shared/grid/_removeBtn.html';
        this.columnDefs = new Array();
    }

    addColumn(field: string, enableSorting: boolean)
    {
        let newColumn = new ColumnDef();
        newColumn.cellTemplate = this.customCellTemplate;
        newColumn.field = field;
        newColumn.enableSorting = enableSorting;
        this.columnDefs.push(newColumn);
    }

    private addRemoveColumn()
    {
        let newColumn = new ColumnDef();
        newColumn.cellTemplate = this.removeTemplate;
        newColumn.name = 'delete';
        newColumn.enableSorting = false;
        newColumn.displayName = '';
        newColumn.width = '13%';
        this.columnDefs.push(newColumn);
    }

    private addServicesColumn()
    {
        this.addRemoveColumn();
    }

    getColumns(): ColumnDef[]
    {
        this.addServicesColumn();
        return this.columnDefs;
    }
}