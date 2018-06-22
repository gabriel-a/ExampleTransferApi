using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExampleTransferApi.DataInit;
using ExampleTransferApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTransferApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly TransferContext _context;

        public TransfersController(TransferContext context)
        {
            _context = context;

            if (_context.TransferItems.Any()) return;
            _context.TransferItems.AddRange(TransferItemsData.GetData());
            _context.SaveChanges();
        }

        // GET api/transfers
        [HttpGet]
        public IEnumerable<TransferItem> Get()
        {
            return _context.TransferItems.ToList();
        }

        // GET api/transfers/5
        [HttpGet("{id}")]
        public ActionResult<TransferItem> Get(int id)
        {
            var item = _context.TransferItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST api/transfers
        [HttpPost]
        public ActionResult<TransferItem> Post([FromBody] TransferItem transfer)
        {
            _context.TransferItems.Add(transfer);
            _context.SaveChanges();
            return Get(transfer.Id);
        }

        // PUT api/transfers/5
        [HttpPut]
        public ActionResult<TransferItem> Put([FromBody] TransferItem transferItem)
        {
            var transfer = _context.TransferItems.Find(transferItem.Id);
            if (transfer == null)
            {
                return NotFound();
            }

            transfer.Date = transferItem.Date;
            transfer.From = transferItem.From;
            transfer.OriginalBlock = transferItem.OriginalBlock;
            transfer.To = transferItem.To;
            transfer.TransferredBlocks = transferItem.TransferredBlocks;
            transfer.TransferType = transferItem.TransferType;

            _context.TransferItems.Update(transfer);
            _context.SaveChanges();
            return Get(transfer.Id);
        }

        // DELETE api/transfers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transfer = _context.TransferItems.Find(id);
            if (transfer == null)
            {
                return NotFound();
            }

            _context.TransferItems.Remove(transfer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}