using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class InventoryItem
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String Name { get; set; }

        public InventoryItem()
        {
        }

        public InventoryItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public InventoryItem(InventoryItem inventoryItem)
        {
            Id = inventoryItem.Id;
            Name = inventoryItem.Name;
        }
        public override bool Equals(object obj)
        {
            return obj is InventoryItem item &&
                   Id == item.Id;
        }
    }
}