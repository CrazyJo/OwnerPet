class RequestDetails
{
    url: string;
    requestedPage: RequestedPage;

    constructor(url: string, requestedPage: RequestedPage)
    {
        this.url = url;
        this.requestedPage = requestedPage;
    }
}

class RequestedPage
{
    pageIndex: number;
    descending: boolean;

    constructor()
    {
        this.pageIndex = 1;
        this.descending = false;
    }
}

class PetsRequest extends RequestedPage
{
    ownerId: number;

    constructor(ownerId: number)
    {
        super();
        this.ownerId = ownerId;
    }
}