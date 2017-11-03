using System;
using System.Collections.Generic;

namespace csharp.DTO
{
    [Serializable]
    public class InventoryConfig
    {
        public List<ItemUpdaterMap> ItemUpdaterMaps { get; set; }
    }
}
