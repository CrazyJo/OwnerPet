class PetsState extends State<Pet>
{
    owner: User;
    waybackHome: WayBackHome;

    constructor(owner: User, context: Context, apiService: IApiService, restorePage: WayBackHome = null)
    {
        super(context, apiService, new RequestDetails('/api/pets/', new PetsRequest(owner.id)));
        this.waybackHome = restorePage;
        this.backToUsersVisible = true;
        this.owner = owner;
        this.title = this.getTitle();
        this.newRecordPlaceholder = 'Enter Pet\'s Name';

        if (owner.petsCount > 0)
            this.updateGrid();
    }

    protected buildNewEntityForPost(inputs): BaseEntity
    {
        return new Pet(inputs.newRecord, this.owner.id);
    }

    private getTitle(): string
    {
        return PossessiveCaseFormatter.convert(this.owner.name) + " pets";
    }

    cellClickEvent(row, col)
    {
    }

    backToUsersHandler()
    {
        this.context.state = new UsersState(this.context, this.apiService, this.waybackHome);
    }

    getColumnDefs(): ColumnDef[]
    {
        let columnBuilder = new ColumnDefBuilder();
        columnBuilder.addColumn('name', true);

        return columnBuilder.getColumns();
    }
}