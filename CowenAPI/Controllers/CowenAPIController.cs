using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CowenAPI.Models;

namespace CowenAPI.Controllers
{
    [Route("api/CowenAPI")]
    [ApiController]
    public class CowenAPIController : ControllerBase
    {
        private readonly CowenAPIContext _context;

        public CowenAPIController(CowenAPIContext context)
        {
            _context = context;
        }

        // GET: api/CowenAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTicker>>> GetStockTicker()
        {
            return await _context.StockTicker.ToListAsync();
        }

        // GET: api/CowenAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockTicker>> GetStockTicker(long id)
        {
            var stockTicker = await _context.StockTicker.FindAsync(id);

            if (stockTicker == null)
            {
                return NotFound();
            }

            return stockTicker;
        }

        [HttpGet("symbol/{symbol}")]
        public IActionResult GetStockTicker(string symbol)
        {
            //var stockTicker = _context.StockTicker.Find(symbol);
            var stockTicker = _context.StockTicker.Where(a => a.Symbol == symbol.ToUpper()).First();
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker);
        }

        [HttpGet("price/close/greater/{price}")]
        public IActionResult GetStockTicker(float price)
        {
            //var stockTicker = _context.StockTicker.Find(symbol);
            var stockTicker = _context.StockTicker.Where(a => a.Close > price);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker);
        }

        [HttpGet("price/close/less/{price}")]
        public IActionResult GetStockTickerClosePrice(float price)
        {
            //var stockTicker = _context.StockTicker.Find(symbol);
            var stockTicker = _context.StockTicker.Where(a => a.Close < price);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker);
        }

        [HttpGet("price/volume/greater/{volume}")]
        public IActionResult GetStockTickerVolume(float volume)
        {
            //var stockTicker = _context.StockTicker.Find(symbol);
            var stockTicker = _context.StockTicker.Where(a => a.Volume > volume);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker);
        }
            
        [HttpGet("price/volume/less/{volume}")]
        public IActionResult GetStockTickerVolumePrice(float volume)
        {
            //var stockTicker = _context.StockTicker.Find(symbol);
            var stockTicker = _context.StockTicker.Where(a => a.Volume < volume);
            if (stockTicker == null)
            {
                return NotFound();
            }
            return Ok(stockTicker);
        }


        // PUT: api/CowenAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockTicker(long id, StockTicker stockTicker)
        {
            if (id != stockTicker.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockTicker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockTickerExists(id))
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

        // POST: api/CowenAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockTicker>> PostStockTicker(StockTicker stockTicker)
        {
            _context.StockTicker.Add(stockTicker);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStockTicker", new { id = stockTicker.Id }, stockTicker);
            return CreatedAtAction(nameof(GetStockTicker), new { id = stockTicker.Id }, stockTicker);
        }

        // POST: api/CowenAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<StockTicker>> PostStockTicker(StockTicker[] stockTicker)
        {
            _context.StockTicker.AddRange(stockTicker);
            await _context.SaveChangesAsync();
            var ids = new List<Object>();
            foreach(StockTicker ticker in stockTicker)
            {
                ids.Add(new { id = ticker.Id });
            }

            //return CreatedAtAction("GetStockTicker", new { id = stockTicker.Id }, stockTicker);
            return CreatedAtAction(nameof(GetStockTicker), ids, stockTicker);
        }

        // DELETE: api/CowenAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockTicker(long id)
        {
            var stockTicker = await _context.StockTicker.FindAsync(id);
            if (stockTicker == null)
            {
                return NotFound();
            }

            _context.StockTicker.Remove(stockTicker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockTickerExists(long id)
        {
            return _context.StockTicker.Any(e => e.Id == id);
        }
    }
}
