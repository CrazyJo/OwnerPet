class PaginationSet<T> {
    page: number;
    count: number;
    totalPages: number;
    totalCount: number;
    items: T[];
}