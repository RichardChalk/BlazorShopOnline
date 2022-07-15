namespace ShopOnline.Api.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; } //Foreign key
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
