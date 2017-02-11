class RequestDetails {
    constructor(url, requestedPage) {
        this.url = url;
        this.requestedPage = requestedPage;
    }
}
class RequestedPage {
    constructor() {
        this.pageIndex = 1;
        this.descending = false;
    }
}
class PetsRequest extends RequestedPage {
    constructor(ownerId) {
        super();
        this.ownerId = ownerId;
    }
}
//# sourceMappingURL=requestDetails.js.map