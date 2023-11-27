namespace MusicApi.Data;

public class ReviewDto
{
    public string Text { get; set; }
    public int? Rating { get; set; }
    public string Author { get; set; }
    public DateOnly? Date { get; set; }    
}
