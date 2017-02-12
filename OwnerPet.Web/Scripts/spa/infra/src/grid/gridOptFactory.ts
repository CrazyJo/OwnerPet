class GridOptFactory<T>
{
    private gridOpt: GridOpt<T>;
    private ctrlScope;
    private sortChangedCallback: (descending: boolean) => void;

    constructor(ctrlScope, sortChangedCallback: (descending: boolean) => void)
    {
        this.ctrlScope = ctrlScope;
        this.sortChangedCallback = sortChangedCallback;
        this.gridOpt = new GridOpt<T>();
        this.gridOpt.useExternalSorting = true;
        this.gridOpt.enableHorizontalScrollbar = 0;
        this.gridOpt.enableVerticalScrollbar = 0;
        this.gridOpt.enableColumnMenus = false;
        this.gridOpt.data = [];
        this.gridOpt.onRegisterApi = (gridApi) =>
        {
            gridApi.core.on.sortChanged(ctrlScope, (grid, sortColumns) =>
            {
                if (sortColumns.length !== 0)
                {
                    let direction = sortColumns[0].sort.direction;
                    let descending = !(direction === 'asc');
                    sortChangedCallback(descending);
                }
            });
        }
    }

    getOpt(): GridOpt<T>
    {
        return this.gridOpt;
    }
}