using System.Text.Json;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
            int itemsPerPage, int totalitems, int totalPages)
        {
            var paginationHeader = new 
            {
                currentPage,
                itemsPerPage,
                totalitems,
                totalPages
            };

            response.Headers.TryAdd("Pagination", JsonSerializer.Serialize(paginationHeader));
        }
    }
}