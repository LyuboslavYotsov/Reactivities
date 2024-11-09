namespace Application.Core
{
    public class PagingParams
    {
        private int _pageSize = 10;

        private const int MaxiPageSize = 50;

        public int pageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxiPageSize) ? MaxiPageSize : value;
        }
        
    }
}