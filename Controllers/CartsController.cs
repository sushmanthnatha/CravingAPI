using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CravingAPI.Models;

namespace CravingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly cravingContext _context;

        public CartsController(cravingContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _context.Cart.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Cart>> GetCart(string id)
        {
            var C = _context.Cart.AsQueryable();
            C =  _context.Cart.Where(e => e.Userid == id && e.Orderid==null);

            if (C == null)
            {
                return NotFound();
            }

           return C.ToList();
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(string id, Cart cart)
        {
            if (id != cart.Cartid)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Cart.Add(cart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartExists(cart.Cartid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCart", new { id = cart.Cartid }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(string id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(string id)
        {
            return _context.Cart.Any(e => e.Cartid == id);
        }
    }
}
