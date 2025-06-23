namespace ezbuy.Models.DTOs.Request
{
    public class RemoveCartItemDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
