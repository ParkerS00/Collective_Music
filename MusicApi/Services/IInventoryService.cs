using MusicApi.Data;

namespace MusicApi.Services
{
    public interface IInventoryService<Inventory>
    {
        Task<IEnumerable<Inventory>> GetAll();

        Task<bool> Update(string email);    
    }
}
