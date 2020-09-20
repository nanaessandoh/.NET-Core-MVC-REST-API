using System.Collections.Generic;
using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using Commander.Service;
using Commander.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/commands")] // or [Route("api/[controller]")] 
    [ApiController]
    public class CommandsController : ControllerBase
    {
        // Calls an object of our CommandService - Not Good Implementation
        //private readonly CommandService _ICommand = new CommandService();
         private readonly ICommandRepository _ICommand;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository ICommand, IMapper mapper)
         {
             _ICommand  = ICommand;
             _mapper = mapper;
         }
        //Get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandItems = _ICommand.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
            
        }

        //Get api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _ICommand.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            else
            return NotFound();
            
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreate)
        {
            var commandModel = _mapper.Map<Command>(commandCreate);
            _ICommand.CreateCommand(commandModel);
            _ICommand.SaveChanges();


            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDTO.Id}, commandReadDTO);
            //return Ok(commandReadDTO);
        } 
    }

    
}