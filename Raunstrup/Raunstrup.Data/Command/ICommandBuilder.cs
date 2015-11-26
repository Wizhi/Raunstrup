using Raunstrup.Data.Command;

namespace Raunstrup.Data.Sql.Command
{
    public interface ICommandBuilder
    {
        ICommand Compile();
    }
}
