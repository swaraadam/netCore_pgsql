
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using loccitane_webapi.Models;

namespace loccitane_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly LoccitaneWebApiContext _context;
        public UserController(LoccitaneWebApiContext context)
        {
            _context = context;
            if (_context.Users.Count () == 0) {
                _context.Users.Add (new User { Name = "Item1" });
                _context.SaveChanges ();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            List<User> lUser = _context.Users.ToList ();

            if (lUser != null && lUser.Count > 0) {
                return Ok (lUser);
            }

            return NotFound ();
        }

        [HttpPost]
        public async Task<IActionResult> Post (String name){
            if(!String.IsNullOrEmpty(name)){
                User user = new User (){
                    Name = name
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }else {
                return BadRequest(new{Message = "asd", Titel = "message"});
            }
        }
    }
}