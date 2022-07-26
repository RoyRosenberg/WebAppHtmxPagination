namespace WebAppHtmxPagination.Models
{
    public class PersonModel
    {
        public Filter Filter { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public List<Person> Result { get; set; }
        public PersonModel()
        {
            Filter = new Filter();
            PagingInfo = new PagingInfo();
            Result = new List<Person>();
        }
    }

    public class Filter
    {
        public int? Priority { get; set; }
        public DateTime? DueDateMax { get; set; }
        public int? UserId { get; set; }
    }

    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; } = 10;
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
