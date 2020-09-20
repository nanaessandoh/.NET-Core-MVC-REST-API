using System.Collections.Generic;
using Commander.Models;

namespace Commander.Service.Interface
{
    public interface ICommandRepository
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand (Command cmd);

    }
}