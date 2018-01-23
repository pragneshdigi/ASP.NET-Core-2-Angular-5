using Angular5Core2.Data.Interface;
using Angular5Core2.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5Core2.Data.DataModels
{
    public partial class InventoryDM : IInventory
    {
        public InventoryContext _context;
        public InventoryDM() { }

        public InventoryDM(InventoryContext context)
        {
            this._context = context;
        }

        public IEnumerable<InventoryMaster> GetInventoryMaster()
        {
            return _context.InventoryMaster;

        }

        public bool InventoryMasterExists(int id)
        {
            bool result = false;

            result = _context.InventoryMaster.Any(e => e.InventoryID == id);

            return result;
        }

        public async Task<InventoryMaster> AddInventory(InventoryMaster inventoryMaster)
        {
            _context.InventoryMaster.Add(inventoryMaster);
            await _context.SaveChangesAsync();

            return inventoryMaster;
        }

        public async Task<InventoryMaster> UpdateInventory(InventoryMaster inventoryMaster)
        {
            _context.Entry(inventoryMaster).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return inventoryMaster;
        }

        public async Task<InventoryMaster> GetInventoryDetails(int id)
        {
            return await _context.InventoryMaster.SingleOrDefaultAsync(m => m.InventoryID == id);
        }

        public async Task<InventoryMaster> DeleteInventory(InventoryMaster inventoryMaster)
        {
            _context.InventoryMaster.Remove(inventoryMaster);
            await _context.SaveChangesAsync();

            return inventoryMaster;
        }
    }
}
