using AutoMapper;
using Commander.DTOs;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        // Constructor
        public CommandsProfile()
        {
            // Source to target - Command(source) convert to CommandReadDTO(target) 
            CreateMap<Command, CommandReadDTO>();
            // Source to target 
            CreateMap<CommandCreateDTO, Command>();    
        }
        
        
    }
}