using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string  itemName;
        public int count;
        public int maxAllowed;
        public Sprite icon;
        public Slot()
        {
            itemName = "";
            count = 0;
            maxAllowed = 99;
        }


        public bool CanAddItem()
        {
            return count < maxAllowed;
        }

    }


    public List<Slot> slots = new List<Slot>();


    // Make the constructor public
    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }


    public bool Add(Item item)
    {
        foreach (Slot slot in slots)
        {
            if (string.IsNullOrEmpty(slot.itemName) || (slot.itemName == item.data.itemName && slot.CanAddItem()))
            {
                slot.itemName = item.data.itemName;
                slot.icon = item.data.icon;
                slot.count++;
                return true; // Item added successfully
            }
        }

        return false; // Inventory is full, couldn't add the item
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < slots.Count)
        {
            Slot slot = slots[index];
            slot.count--;

            if (slot.count == 0)
            {
                slot.itemName = "";
                slot.icon = null;
            }
        }
    }
}


