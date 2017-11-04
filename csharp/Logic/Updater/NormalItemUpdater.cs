﻿using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic.Updater
{
    public class NormalItemUpdater : IUpdater
    {
        private readonly ItemChecker _itemChecker = new ItemChecker();
        private readonly ItemUpdater _itemUpdater = new ItemUpdater();

        public void Update(Item item)
        {
            _itemUpdater.UpdateSellInDate(item);
            UpdateQuality(item);
        }

        private void UpdateQuality(Item item)
        {
            if (_itemChecker.HasExpired(item))
                item.Quality = item.Quality >= 2 ? item.Quality - 2 : item.Quality - 1;
            else
                item.Quality = item.Quality > 0 ? item.Quality - 1 : item.Quality;
        }   
    }
}
