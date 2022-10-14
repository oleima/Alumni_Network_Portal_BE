namespace Alumni_Network_Portal_BE.Models.DTOs.Pages
{
    public class PaginationMetadata
    {
        public PaginationMetadata(int elementCount, int currentPage, int itemsPerPage)
        {
            ElementCount = elementCount;
            CurrentPage = currentPage;
            PageCount = (int)Math.Ceiling(elementCount / (double)itemsPerPage);
        }

        public int CurrentPage { get; set; }
        public int ElementCount { get; set; }
        public int PageCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < PageCount;

    }
}
