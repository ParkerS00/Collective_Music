using Microsoft.CodeAnalysis.CSharp.Syntax;
using MusicBlazorApp.Data;

namespace MusicApi.Data;

public class ItemDto
{
    public int Id { get; set; }
    public string? ItemName { get; set; }

    public int? SerialNumber { get; set; }

    public string? Description { get; set; }

    public decimal? SellPrice { get; set; }
    public decimal? SuggestedRentalPrice { get; set;}

    public List<string>? ImageFilePaths { get; set; }

    public List<string>? ItemStatuses { get; set; }
    public List<string>? ItemCategories { get; set; }

    public ItemDto(Item item)
    {
        ItemName = item.ItemName;
        Description = item.Description;
        SellPrice = item.SellPrice;
        SuggestedRentalPrice = item.SuggestedRentalPrice;

        
        if (item.ItemStatuses != null)
        {
            ItemStatuses = item.ItemStatuses.Select(x => x.Status.StatusName).ToList();
        }

        if (item.ItemCategories != null)
        {
            ItemCategories = item.ItemCategories.Select(x => x.Category.CategoryName).ToList();
        }
    }

}

public static class DbObjToDtoObj
{
    public static ItemDto ToItemDto(this Item item)
    {
        return new(item);

    }

}
