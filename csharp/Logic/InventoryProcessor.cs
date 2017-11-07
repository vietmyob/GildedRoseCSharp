using System;
using System.Collections.Generic;
using System.Linq;
using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic
{
    public class InventoryProcessor
    {
        private readonly InventoryConfigSerialiser _configSerialiser = new InventoryConfigSerialiser();
        private readonly Reflector _reflector = new Reflector();
        private readonly InventoryConfig _inventoryConfig;

        public InventoryProcessor()
        {
            _inventoryConfig = _configSerialiser.Load("Config/InventoryConfig.xml");
        }

        public void Update(List<Item> items )
        {
            foreach (var item in items)
            {
                var itemUpdaterMap = _inventoryConfig.ItemUpdaterMaps.FirstOrDefault(x => item.Name == x.ItemName);
                var updaterClassName = itemUpdaterMap?.UpdaterClass ?? _inventoryConfig.DefaultUpdaterClass;
                var updaterClassType = _reflector.GetIUpdaterClassType(updaterClassName);
                var updater = (IUpdater)Activator.CreateInstance(updaterClassType);
                updater.Update(item);
            }
        }
    }
}
