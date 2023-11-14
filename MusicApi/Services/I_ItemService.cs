﻿using Microsoft.AspNetCore.Mvc;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public interface I_ItemService<Item>
{
    Task<IEnumerable<Item>> GetAll();
    Task<Item> Get(int id);
    Task<Item> Add(Item item);
    Task<Item> Update(Item item);
    Task<Item> Delete(int id);

}
