using Microsoft.CodeAnalysis.CSharp.Syntax;
using MusicApi.Data;

namespace MusicApi.Dtos;

public class ItemDto
{
    public int Id { get; set; }

    public string? ItemName { get; set; }

    public string? SerialNumber { get; set; }

    public string? Description { get; set; }

    public decimal? SellPrice { get; set; }

    public decimal? SuggestedRentalPrice { get; set; }

    public List<string>? ImageFilePaths { get; set; } = new List<string>();

    public string? PrimaryImagePath { get; set; }

    public List<string>? ItemStatuses { get; set; }

    public int? Quantity { get; set; }

    public List<string>? ItemCategories { get; set; }

    public IEnumerable<ReviewDto>? Reviews { get; set; }

    public decimal? AverageItemRating { get; set; }

    public ItemDto(Item item)
    {
        Id = item.Id;
        ItemName = item.ItemName;
        Description = item.Description;
        SellPrice = item.SellPrice;
        SuggestedRentalPrice = item.SuggestedRentalPrice;
        SerialNumber = item.SerialNumber;


        if (item.Inventories != null)
        {
            ItemStatuses = item.Inventories.Select(x => x.Status.StatusName).ToList();
            Quantity = item.Inventories.GroupBy(i => i.ItemId).Count();
        }

        if (item.ItemCategories != null)
        {
            ItemCategories = item.ItemCategories.Select(x => x.Category.CategoryName).ToList();
        }


        if (item.Reviews != null)
        {
            Reviews = item.Reviews.Select(r => new ReviewDto
            {
                Text = r.ReviewText,
                Rating = r.Rating,
                Author = r.Customer.FirstName,
                Date = r.ReviewDate
            });
        }

        foreach (var path in item.ItemImages)
        {
            if (path.IsPrimary == true)
            {
                PrimaryImagePath = path.Filepath.ToString();
            }
            ImageFilePaths.Add(path.Filepath.ToString());
        }


        if (item.Reviews.Count() > 0 && Quantity > 0)
        {
            decimal sum = 0;
            foreach (var rating in item.Reviews)
            {
                sum += (decimal)rating.Rating;
            }

            AverageItemRating = Math.Round((sum / (decimal)item.Reviews.Count()), 1);
        }
    }

    public ItemDto()
    {

    }

}

public static class DbObjToDtoObj
{
    public static ItemDto ToItemDto(this Item item) // Extension Method to the Item class
    {
        ItemDto newDto = new(item);
        return newDto;
    }

}
