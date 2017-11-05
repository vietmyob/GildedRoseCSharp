using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic.Updater
{
    public class SulfurasUpdater : IUpdater
    {
        public void Update(Item item)
        {
            item.Quality = item.Quality;
            item.SellIn = item.SellIn;
        }
    }
}