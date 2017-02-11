class GridOpt<TData>
{
    useExternalSorting: boolean;
    enableColumnMenus:boolean;
    data: TData[];
    excludeProperties: string[];
    columnDefs: ColumnDef[];
    enableHorizontalScrollbar: number;
    enableVerticalScrollbar: number;
    onRegisterApi: (gridApi) => void;
}