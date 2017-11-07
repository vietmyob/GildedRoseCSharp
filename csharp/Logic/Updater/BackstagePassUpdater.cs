﻿using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic.Updater
{
    public class BackstagePassUpdater : AbstractUpdater, IUpdater
    {
        private readonly ItemChecker _itemChecker = new ItemChecker();

        public void Update(Item item)
        {
            UpdateQuality(item);
            UpdateSellIn(item);
            DropQualityAfterExpired(item);
        }

        private void DropQualityAfterExpired(Item item)
        {
            if (_itemChecker.HasExpired(item))
                item.Quality = 0;
        }

        private void UpdateQuality(Item item)
        {
            IncreaseQualityByOne(item);
            IncreaseQualityForBackstagePass(item);
        }

        private void IncreaseQualityForBackstagePass(Item item)
        {
            UpdateBackstagePassQualityBasedOnSellIn(item, 11);
            UpdateBackstagePassQualityBasedOnSellIn(item, 6);
        }

        private void UpdateBackstagePassQualityBasedOnSellIn(Item item, int days)
        {
            if (_itemChecker.IsBelowMaxQuality(item) && _itemChecker.HasToBeSoldIn(item, days))
                item.Quality++;
        }
    }
}