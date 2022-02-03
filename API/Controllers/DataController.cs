using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;




namespace API.Controllers
{
     [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly dataDbContext dataDbContexts;
        public DataController(dataDbContext datadbcontext)
        {
            dataDbContexts = datadbcontext;
        }

        [HttpGet]
        public IEnumerable<dataprop> GetFilm()
        {
            return dataDbContexts.dataProp.ToList();//select * from tutorial
        }
        [HttpGet("GetTutorialById")]
        public dataprop GetFilmById(int movieid)
        {
            return dataDbContexts.dataProp.Find(movieid);
        }

        [HttpPost("InsertTutorial")]
        public IActionResult InsertFilm([FromBody]dataprop dataProp)
        {
            if (dataProp.movieid.ToString() != "")
            {
                //insert into tutorial values(tutorial.id,tutorial,name,tutorial.desc,tutorial.publish,tutorial.fees)
                dataDbContexts.dataProp.Add(dataProp);
                dataDbContexts.SaveChanges();
                return Ok("Saved successfully");                
            }
            else
                return BadRequest(); //404 ERROR
        }

        [HttpPut("UpdateTutorial")]
        public IActionResult UpdateFilm([FromBody] dataprop dataProp)
        {
            if (dataProp.movieid.ToString() != "")
            {
                //update tutorial set name=tutorial.name , desc=tutorial.desc , fees=tutorial.fees , publish=tutorial.publish where id=tutorial.id
                dataDbContexts.Entry(dataProp).State = EntityState.Modified;
                dataDbContexts.SaveChanges();
                return Ok("Updated successfully");
            }
            else
                return BadRequest();
        }

        //localhost:3433/Tutorial/DeleteTutorial?tutorialId=3
        [HttpDelete("DeleteTutorial")]
        public IActionResult DeleteFilm(int movieid)
        {
            //select * from tutorial where tutorialId=3
            var result = dataDbContexts.dataProp.Find(movieid);
            dataDbContexts.dataProp.Remove(result);
            dataDbContexts.SaveChanges();
            return Ok("Deleted successfully");
        }
    }
} 