abstract class State<T>
{
    context: Context;
    apiService: IApiService;
    title: string;
    backToUsersVisible: boolean;
    newRecordPlaceholder: string;
    gridOpt: GridOpt<T>;
    paginOpt: PaginOpt;
    requestDetails: RequestDetails;

    constructor(context: Context, apiService: IApiService, requestDetails: RequestDetails)
    {
        let sortCallBack = (d: boolean) => context.state.sortChangedHandler(d);
        this.context = context;
        this.apiService = apiService;
        this.title = null;
        this.newRecordPlaceholder = null;
        this.gridOpt = new GridOptFactory<T>(context.ctrlScope, sortCallBack).getOpt();
        this.gridOpt.columnDefs = this.getColumnDefs();
        this.paginOpt = new PaginOpt();
        this.requestDetails = requestDetails;
    }

    abstract cellClickEvent(row, col);
    abstract backToUsersHandler();
    abstract getColumnDefs(): ColumnDef[];

    protected getHttpConfig(): HttpRequestConfig
    {
        let config = new HttpRequestConfig();
        config.params = this.requestDetails.requestedPage;
        return config;
    }

    updateGrid(): void
    {
        let config = this.getHttpConfig();

        this.apiService.get<PaginationSet<T>>(this.requestDetails.url, config, (result) =>
        {
            this.paginOpt.totalItems = result.data.totalCount;
            this.gridOpt.data = result.data.items;
        }, null);
    }

    addNewRecord(inputs, recordForm): void
    {
        if (recordForm.$valid && inputs !== undefined)
        {
            let entity = this.buildNewEntityForPost(inputs);
            this.apiService.post(this.requestDetails.url, entity, () => this.updateGrid(), null);
        }
    }

    protected buildNewEntityForPost(inputs): BaseEntity
    {
        return new BaseEntity(inputs.newRecord);
    }

    sortChangedHandler(descending: boolean)
    {
        if (descending !== this.requestDetails.requestedPage.descending)
        {
            this.requestDetails.requestedPage.descending = descending;
            this.updateGrid();
        }
    }

    pageChanged(): void
    {
        this.requestDetails.requestedPage.pageIndex = this.paginOpt.currentPage;
        this.updateGrid();
    }

    removeBtnEvent(row): void
    {
        let url = this.requestDetails.url + row.entity.id;
        this.apiService.remove(url, () =>
        {
            if (this.wasLastElement())
            {
                this.clearGrid();
            }
            else
            {
                this.updateGrid();
            }
        }, null);
    }

    protected clearGrid()
    {
        this.gridOpt.data = [];
        this.paginOpt.totalItems = 0;
    }

    protected wasLastElement(): boolean
    {
        return this.paginOpt.totalItems === 1;
    }
}