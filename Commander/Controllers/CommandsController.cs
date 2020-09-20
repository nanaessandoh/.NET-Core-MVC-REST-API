using System.Collections.Generic;
using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using Commander.Service;
using Commander.Service.Interface;
using Microsoft.AspNetCore.JsonPatch;
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
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems)); // 200 Ok
            
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
            return NotFound(); // 404 Not Found
            
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreate)
        {
            var commandModel = _mapper.Map<Command>(commandCreate);
            _ICommand.CreateCommand(commandModel);
            _ICommand.SaveChanges();


            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDTO.Id}, commandReadDTO); // 201 Created
            //return Ok(commandReadDTO);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDTO commandUpdate)
        {
            var commandModelFromRepo = _ICommand.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound(); // 404 Not found
            }

            _mapper.Map(commandUpdate, commandModelFromRepo);
            _ICommand.UpdateCommand(commandModelFromRepo);
            _ICommand.SaveChanges();

            return NoContent(); // 204 No Content Success

        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchCommand)
        {
            var commandModelFromRepo = _ICommand.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound(); // 404 Not found
            }
            
            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);
            patchCommand.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _ICommand.UpdateCommand(commandModelFromRepo);
            _ICommand.SaveChanges();

            return NoContent(); //204 No Content Success
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _ICommand.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound(); // 404 Not found
            }

            _ICommand.DeleteCommand(commandModelFromRepo);
            _ICommand.SaveChanges();

            return NoContent(); // 204 No Content

        }



    }

    
}