using Microsoft.AspNetCore.Mvc;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public interface IItemService<Item>
{
    Task<IEnumerable<Item>> GetAll();
    Task<Item> Get(int id);
    Task<Item> Add(Item item);
    Task<Item> Update(Item item);
    Task<Item> Delete(int id);

    Task AddImageFilePath(string filePath, int itemId, bool isPrimary);

    Task RemovePrimaries(int id);

}
