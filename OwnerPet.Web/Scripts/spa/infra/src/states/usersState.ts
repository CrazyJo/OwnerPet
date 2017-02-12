class UsersState extends State<User>
{
    constructor(context: Context, apiService: IApiService, wayBackHome: WayBackHome = null)
    {
        super(context, apiService, null);
        this.restorePreviousState(wayBackHome);
        this.backToUsersVisible = false;
        this.title = 'All Users';
        this.newRecordPlaceholder = 'Enter Pet Owner\'s Name';

        this.updateGrid();
    }

    getColumnDefs(): ColumnDef[]
    {
        let columnBuilder = new ColumnDefBuilder();
        columnBuilder.addColumn('name', true);
        columnBuilder.addColumn('petsCount', false);

        return columnBuilder.getColumns();
    }

    cellClickEvent(row, col)
    {
        if (col.field === 'name')
        {
            this.context.state = new PetsState(row.entity, this.context, this.apiService, this.createWaybackHome());
        }
    }

    private restorePreviousState(wayBackHome: WayBackHome)
    {
        let rP: RequestedPage;
        if (wayBackHome !== null)
        {
            rP = wayBackHome.restorePage || new RequestedPage();
            this.paginOpt = wayBackHome.paginOpt;
        }
        else
        {
            rP = new RequestedPage();
        }
        this.requestDetails = new RequestDetails('/api/users/', rP);
    }

    private createWaybackHome(): WayBackHome
    {
        return new WayBackHome(this.paginOpt, this.requestDetails.requestedPage);
    }

    backToUsersHandler()
    {
    }
}