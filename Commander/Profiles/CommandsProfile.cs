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
            // Source -> Target
            // For Get 
            CreateMap<Command, CommandReadDTO>();
            // For Post 
            CreateMap<CommandCreateDTO, Command>();
            // For Put 
            CreateMap<CommandUpdateDTO, Command>(); 
            // For Patch     
            CreateMap<Command, CommandUpdateDTO>();
        }
        
        
    }
}