using System;
using System.Collections.Generic;
using System.Linq;
using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic
{
    public class InventoryProcessor
    {
        private readonly InventoryConfigSerialiser _configSerialiser;
        private readonly Reflector _reflector;

        public InventoryProcessor()
        {
            _configSerialiser = new InventoryConfigSerialiser();
            _reflector = new Reflector();
        }

        public void Update(List<Item> items )
        {
            var inventoryConfig = _configSerialiser.Load("Config/InventoryConfig.xml");
            foreach (var item in items)
            {
                var updaterClass = inventoryConfig.ItemUpdaterMaps.Where(x => item.Name == x.ItemName);
                if (!updaterClass.Any())
                {
                    updaterClass = inventoryConfig.ItemUpdaterMaps.Where(x => x.ItemName == "Normal Item");
                }
                var updaterClassType = _reflector.GetIUpdaterClassType(updaterClass.First().UpdaterClass);
                var updater = (IUpdater)Activator.CreateInstance(updaterClassType);
                updater.Update(item);
            }
        }
    }
}
