import { FilterProjectQueryParams } from "./filter-project-query-params";

export interface ProjectQueryParams {
    filters?: FilterProjectQueryParams;
    pageSize?: number;
    pageNumber?: number;
    searchText?: string;
}