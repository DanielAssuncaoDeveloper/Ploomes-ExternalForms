using ExternalForms_Domain.Dtos.Commum;

namespace ExternalForms_Domain.Commum.Utils
{
    public static class QueryFiltersUtils
    {
        public static int PaginationRecords(QueryFiltersBaseDto queryFilters)
        {
            queryFilters.Limit = queryFilters.Limit == 0 ? 50 : queryFilters.Limit;
            queryFilters.Page = queryFilters.Page == 0 ? 1 : queryFilters.Page;

            return (queryFilters.Page - 1) * queryFilters.Limit;
        }
    }
}
