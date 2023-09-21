using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EShopWebAPI.Data;
using EShopWebAPI.Models;

namespace EShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly EShopWebAPIContext _context;

        public CartDetailsController(EShopWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/CartDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetails>>> GetCartDetails()
        {
          if (_context.CartDetails == null)
          {
              return NotFound();
          }
            return await _context.CartDetails.ToListAsync();
        }

        // GET: api/CartDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetails>> GetCartDetails(int id)
        {
          if (_context.CartDetails == null)
          {
              return NotFound();
          }
            var cartDetails = await _context.CartDetails.FindAsync(id);

            if (cartDetails == null)
            {
                return NotFound();
            }

            return cartDetails;
        }

        // PUT: api/CartDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetails(int id, CartDetails cartDetails)
        {
            if (id != cartDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartDetailsExists(id))
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

        // POST: api/CartDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartDetails>> PostCartDetails(CartDetails cartDetails)
        {
          if (_context.CartDetails == null)
          {
              return Problem("Entity set 'EShopWebAPIContext.CartDetails'  is null.");
          }
            _context.CartDetails.Add(cartDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartDetails", new { id = cartDetails.Id }, cartDetails);
        }

        // DELETE: api/CartDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartDetails(int id)
        {
            if (_context.CartDetails == null)
            {
                return NotFound();
            }
            var cartDetails = await _context.CartDetails.FindAsync(id);
            if (cartDetails == null)
            {
                return NotFound();
            }

            _context.CartDetails.Remove(cartDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartDetailsExists(int id)
        {
            return (_context.CartDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
