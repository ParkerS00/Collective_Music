
namespace MusicApi.Request
{
    public class AddReviewRequest
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? CustomerId { get; set; }
        public DateOnly? ReviewDate { get; set; }
        public string? ReviewText { get; set; }
        public int? Rating { get; set; }

        AddReviewRequest() 
        {

        }

        public AddReviewRequest( int? itemId, int? customerId, DateOnly? reviewDate, string? reviewText, int? rating)
        {
            ItemId = itemId;
            CustomerId = customerId;
            ReviewDate = reviewDate;
            ReviewText = reviewText;
            Rating = rating;
        }
    }
}
