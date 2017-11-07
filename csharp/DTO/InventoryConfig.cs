using System;
using System.Collections.Generic;

namespace csharp.DTO
{
    [Serializable]
    public class InventoryConfig
    {
        public string DefaultUpdaterClass { get; set; }
        public List<ItemUpdaterMap> ItemUpdaterMaps { get; set; }
    }
}
