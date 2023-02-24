using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class InventoryItemController
    {

        public InventoryItem UpdateInventoryItem(int inventoryItemId)
        {
            throw new NotImplementedException();
        }

        public String DeleteInventoryItem(Room room, InventoryItem inventoryItem)
        {
            try
            {
                inventoryItemService.DeleteInventoryItem(room,inventoryItem);
                return "Inventory item deleted successfuly";
            }
            catch(EmptyFieldException e)
            {
                return e.FieldName + "must not be empty";
            }
        }

        public String OrderInventoryItems(List<InventoryItem> inventoryItemList)
        {
            try
            {
                inventoryItemService.OrderInventoryItems(inventoryItemList);
                return "Inventory items ordered successfuly";
            }
            catch(EmptyFieldException e)
            {
                return e.FieldName + "must not be empty";
            }
        }

        public InventoryItemService inventoryItemService = new InventoryItemService();

    }
}