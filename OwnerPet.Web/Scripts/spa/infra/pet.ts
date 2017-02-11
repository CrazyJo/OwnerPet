class Pet extends BaseEntity
{
    id: number;
    name: string;
    ownerId: number;

    constructor(name: string, ownerId: number)
    {
        super(name);
        this.ownerId = ownerId;
    }
}