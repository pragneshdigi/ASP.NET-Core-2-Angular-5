using Angular5Core2.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Angular5Core2.Data.Interface
{
    public partial interface IInventory
    {
        IEnumerable<InventoryMaster> GetInventoryMaster();

        bool InventoryMasterExists(int id);

        Task<InventoryMaster> AddInventory(InventoryMaster inventoryMaster);

        Task<InventoryMaster> UpdateInventory(InventoryMaster inventoryMaster);

        Task<InventoryMaster> GetInventoryDetails(int id);

        Task<InventoryMaster> DeleteInventory(InventoryMaster inventoryMaster);
    }
}
