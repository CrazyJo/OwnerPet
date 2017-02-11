class PaginOpt {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    maxSize: number;

    constructor() {
        this.currentPage = 1;
        this.itemsPerPage = 3;
        this.totalItems = 0;
        this.maxSize = 5;
    }
}