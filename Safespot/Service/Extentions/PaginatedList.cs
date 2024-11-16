using Safespot.Service.Exceptions;

namespace Safespot.Service.Extentions
{
    public static class PaginatedList
    {

        //public PaginatedList(List<T> items,int pageIndex,int totalPages) 
        //{
        //    Items = items;
        //    PageIndex = pageIndex;
        //    TotalPages = totalPages;
        //}


        public static IList<T> ToPagedList<T>(this IList<T> itemList, PaginationParams @params)
        {
            if (@params.PageIndex < 1)
                throw new SafespotException("Page index should be positive integer number", 400);
            else if (@params.PageSize < 1)
                throw new SafespotException("Page size should be positive integer number", 400);
            else if (@params.PageSize > itemList.Count)
                throw new SafespotException("Page can not be greater than maximum number of elements", 400);

            return itemList.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize).ToList();
        }
    }
}
