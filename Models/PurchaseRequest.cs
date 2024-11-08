public class PurchaseRequest
{
    public int Id { get; set; }
    public string RequestNumber { get; set; }
    public string ItemCode { get; set; }
    public int ItemQuantity { get; set; }
    public int ItemCost { get; set; }
    public int TotalCost { get; set; }
    public string Status { get; set; } // "PENDING", "APPROVED", "DISAPPROVED"
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedDate { get; set; }
}