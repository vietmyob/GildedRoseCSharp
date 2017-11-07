using csharp.DTO;

namespace csharp.Logic
{
    public class ItemUpdater
    {
        public void UpdateSellInDate(Item item)
        {
            item.SellIn--;
        }
    }
}
