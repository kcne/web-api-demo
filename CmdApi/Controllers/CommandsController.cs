using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CmdApi.Models;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context)
        {
            _context = context;
        }
        
        //HttpGet: api/Commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;
        }

        // GET: api/Commands/5
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return commandItem;
        }

        // POST: api/Commands
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command item)
        {
            _context.CommandItems.Add(item);
            _context.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command {Id = item.Id}, item);
        }

    //     [HttpGet]
    //    public ActionResult<IEnumerable<string>> GetString(){
    //           return new string[] {"This", "is", "hard", "coded"};
    //    }
    }
}