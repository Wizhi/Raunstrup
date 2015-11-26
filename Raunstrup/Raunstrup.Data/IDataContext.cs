using Raunstrup.Data.Command;

namespace Raunstrup.Data
{
    public interface IDataContext<TTarget, TField>
    {
        ITransaction BeginTransaction();

        IInsertCommandBuilder<TField> CreateInsert(TTarget target);

        IUpdateCommandBuilder<TField> CreateUpdate(TTarget target);
    }
}
