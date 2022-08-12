namespace DS.Domain.DynamicQuery
{
    public class DataDescriptor
    {
        public OrderDescriptor Order { get; set; }
        public FilterDescription[] Filter { get; set; }
        public PaginationDescriptor Pagination { get; set; }
    }
}
