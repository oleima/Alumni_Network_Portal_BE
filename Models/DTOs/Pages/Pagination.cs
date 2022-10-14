namespace Alumni_Network_Portal_BE.Models.DTOs.Pages
{
    public class Pagination
    {
        private int _maxItemsPerPage = 50;
        private int itemsPerPage;
        public int Page { get; set; }
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }
    }
}
