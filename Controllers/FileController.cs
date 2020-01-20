using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using loccitane_webapi.Models;

namespace loccitane_webapi.Controllers{
    [Route("api/files")]
    [ApiController]
    public class FileController: ControllerBase
    {
        private readonly LoccitaneWebApiContext _context;
        public FileController (LoccitaneWebApiContext context){
            _context = context;
            if(_context.Files.Count()==0){
                _context.Files.Add(new File {UserId = 123, Address ="anywhere"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            List<File> lFile = _context.Files.ToList();
            if(lFile!=null&&lFile.Count>0){
                return Ok(lFile);
            }
            return NotFound();
        }

        [HttpGet("{q}")]
        public async Task<IActionResult> Get (Int16 q){
            List<File> lFile = _context.Files.Where(x=>x.Id==q).ToList();
            if(lFile!=null&&lFile.Count>0){
                return Ok(lFile);
            }
            return NotFound(new{Message = q + "Not Found", Title ="Data Not Found"});
        }

        [HttpPost]
        public async Task<IActionResult> Post (Int16 userId, String address){
            if(!String.IsNullOrEmpty(address)){
                File file = new File(){
                    UserId = userId,
                    Address = address
                };
                _context.Files.Add(file);
                _context.SaveChanges();
                return Ok(file);
            }else{
                return BadRequest(new{Message = "failed to assgin data", Title = "fail bro!"});
            }
        }
    }
}