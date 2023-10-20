namespace Domain.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 200;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 50;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string? OrderBy { get; set; }
        public string? Fields { get; set; }
    }
}
