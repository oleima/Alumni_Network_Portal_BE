namespace Alumni_Network_Portal_BE.Models.DTOs.UserDTO
{
    public class UserPostReadDTO
    {
        //Fields
        public int Id { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string? Bio { get; set; } //Nullable
        public string? FunFact { get; set; } //Nullable
        public string? Picture { get; set; }
    }
}
