using Microsoft.CodeAnalysis.CSharp.Syntax;
using MusicBlazorApp.Data;

namespace MusicApi.Data;

public class ItemDto
{
    public int Id { get; set; }
    public string? ItemName { get; set; }

    public string? SerialNumber { get; set; }

    public string? Description { get; set; }

    public decimal? SellPrice { get; set; }
    public decimal? SuggestedRentalPrice { get; set;}

    public List<string>? ImageFilePaths { get; set; } = new List<string>();

    public string? PrimaryImagePath { get; set; }

    public List<string>? ItemStatuses { get; set; }
    public List<string>? ItemCategories { get; set; }

    public List<Review>? Reviews { get; set; } = new List<Review>();

    public ItemDto(Item item)
    {
        Id = item.Id;
        ItemName = item.ItemName;
        Description = item.Description;
        SellPrice = item.SellPrice;
        SuggestedRentalPrice = item.SuggestedRentalPrice;
        SerialNumber = item.SerialNumber;

        
        if (item.ItemStatuses != null)
        {
            ItemStatuses = item.ItemStatuses.Select(x => x.Status.StatusName).ToList();
        }

        if (item.ItemCategories != null)
        {
            ItemCategories = item.ItemCategories.Select(x => x.Category.CategoryName).ToList();
        }

        if (item.Reviews != null)
        {
            Reviews = item.Reviews.ToList();
        }

        foreach (var path in item.ItemImages)
        {
            if (path.IsPrimary == true)
            {
                PrimaryImagePath = path.Filepath.ToString();
            }
            ImageFilePaths.Add(path.Filepath.ToString());
        }
    }

    public ItemDto()
    {

    }

}

public static class DbObjToDtoObj
{
    public static ItemDto ToItemDto(this Item item)
    {
        ItemDto newDto = new(item);
        return newDto;
    }

}
