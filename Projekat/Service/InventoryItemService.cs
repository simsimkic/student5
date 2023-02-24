using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class InventoryItemService
    {
        public Boolean IsInventoryItemNameValid(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }
        public Boolean IsSameInventoryItem(InventoryItem inventoryItem, InventoryItem otherInventoryItem)
        {
            if (inventoryItem.Name == otherInventoryItem.Name && inventoryItem.Id == otherInventoryItem.Id) return true;
            else return false;
        }
        public Boolean IsInventoryItemQuantityValid(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        public InventoryItem UpdateInventoryItem(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        //PROVERI OVO
        public void DeleteInventoryItem(Room room,InventoryItem inventoryItem)
        {
            InventoryItemInfoValidation(inventoryItem);
            inventoryItemRepository.Delete(inventoryItem.Id);
            room.InventoryItems.Remove(inventoryItem);
            roomRepository.Update(room);

        }

        public void OrderInventoryItems(List<InventoryItem> inventoryItemList)
        {
            validateInventoryItemsOrder(inventoryItemList);
            foreach (InventoryItem item in inventoryItemList)
                inventoryItemRepository.Create(item);
            //TODO: SMANJIVANJE KAPACITETA PRI DODAVANJU ITEMA U SOBE
            Room warehouse = roomRepository.GetWarehouse();
            AddItemsToWareHouse(warehouse, inventoryItemList);
        }
        public void AddItemsToWareHouse(Room warehouse, List<InventoryItem> items)
        {
            foreach (InventoryItem item in items)
                warehouse.InventoryItems.Add(item);
            roomRepository.Update(warehouse);
        }
        public void validateInventoryItemsOrder(List<InventoryItem> inventoryItems)
        {
            foreach (InventoryItem inventoryItem in inventoryItems) InventoryItemInfoValidation(inventoryItem);
        }
        public void InventoryItemInfoValidation(InventoryItem inventoryItem)
        {
            if (String.IsNullOrEmpty(inventoryItem.Name)) throw new EmptyFieldException("Inventory item name");
        }
        public InventoryItemRepository inventoryItemRepository = new InventoryItemRepository();
        public RoomRepository roomRepository = new RoomRepository();

    }
}