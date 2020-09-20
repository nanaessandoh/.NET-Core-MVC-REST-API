using System.Collections.Generic;
using Commander.Models;
using Commander.Service.Interface;

namespace Commander.Service
{
    public class SQLCommanderService : ICommandRepository
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command {Id=0, HowTo="Boil and Egg", Line="Boil Water", Platform="Kettle & Pan"},
                new Command {Id=1, HowTo="Cut Bread", Line="Get a Knife", Platform="Knife and Chopping Board"},
                new Command {Id=2, HowTo="Make Cup of Tea", Line="Place Teabag in Cup", Platform="Kettle & Cup"}
            };

            return commands;
            
        }

        public Command GetCommandById(int id)
        {
            return new Command {Id=0, HowTo="Boil and Egg", Line="Boil Water", Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }

}