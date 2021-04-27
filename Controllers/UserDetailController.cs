using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CravingAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {

        private readonly cravingContext usercontext;

        public UserDetailController(cravingContext context)
        {
            usercontext = context;
        }


        [HttpGet]
        public IEnumerable<Userdetail> Get()
        {
            return usercontext.Userdetails;
        }

        [HttpGet("{id}")]
        public ActionResult GetUserDetail(string id)
        {
            Userdetail u;

            if (id.Contains("@"))
            {
                u = usercontext.Userdetails.Where(e => e.Email == id).FirstOrDefault();
                if (u == null)
                    return NotFound();
                return CreatedAtAction("GetUser", new { id = u.Email }, u);
            }
            else
            {
               
                u = usercontext.Userdetails.Find(id);
                if(u==null)
                    return NotFound();
                return CreatedAtAction("GetUser", new { id = u.Userid }, u);

            }
             

                
        }





    }
}
