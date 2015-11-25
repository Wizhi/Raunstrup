using Raunstrup.Data.Sql.Command;

namespace Raunstrup.Data.Command
{
    public interface IInsertCommandBuilder<TField> : ICommandBuilder
    {
        IInsertCommandBuilder<TField> Fields(params TField[] fields);

        IInsertCommandBuilder<TField> Values(params object[] values);
    }
}