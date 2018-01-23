using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Angular5Core2.Data;
using Microsoft.EntityFrameworkCore;
using Angular5Core2.Data.Interface;
using Angular5Core2.Data.DataModels;
using Angular5Core2.Data.Models;

namespace Angular5Core2.Controllers
{
    [Produces("application/json")]
    [Route("api/InventoryMasterAPI")]
    public class InventoryMasterAPIController : Controller
    {
        private readonly InventoryContext _context;

        public IInventory _inventory;

        //public InventoryMasterAPIController(InventoryContext context)
        public InventoryMasterAPIController()
        {
            //_context = context;
            this._inventory = new InventoryDM(new InventoryContext());
        }

        [HttpGet]
        [Route("Inventory")]        
        public IEnumerable<InventoryMaster> GetInventoryMaster()
        {
            try
            { 
                //return _context.InventoryMaster;

                return _inventory.GetInventoryMaster();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostInventoryMaster([FromBody] InventoryMaster InventoryMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.InventoryMaster.Add(InventoryMaster);
            

            try
            {
                //await _context.SaveChangesAsync();
                await _inventory.AddInventory(InventoryMaster);
            }
            catch (DbUpdateException)
            {
                if (InventoryMasterExists(InventoryMaster.InventoryID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventoryMaster", new { id = InventoryMaster.InventoryID }, InventoryMaster);
        }
        private bool InventoryMasterExists(int id)
        {
            //return _context.InventoryMaster.Any(e => e.InventoryID == id);
            return _inventory.InventoryMasterExists(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryMaster([FromRoute] int id, [FromBody] InventoryMaster InventoryMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != InventoryMaster.InventoryID)
            {
                return BadRequest();
            }

            //_context.Entry(InventoryMaster).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();

                await _inventory.UpdateInventory(InventoryMaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteInventoryMaster([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //InventoryMaster InventoryMaster = await _context.InventoryMaster.SingleOrDefaultAsync(m => m.InventoryID == id);
            InventoryMaster InventoryMaster = await _inventory.GetInventoryDetails(id);

            if (InventoryMaster == null)
            {
                return NotFound();
            }

            //_context.InventoryMaster.Remove(InventoryMaster);
            //await _context.SaveChangesAsync();

            await _inventory.DeleteInventory(InventoryMaster);
            return Ok(InventoryMaster);
        }
    }
}