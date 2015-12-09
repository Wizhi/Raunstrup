using System;
using System.Data;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class ProjectProxy : Project
    {
        private readonly Lazy<Project> _real;

        public override int Id { get { return _real.Value.Id; } }
        public override Draft Draft { get { return _real.Value.Draft; } }
        public override DateTime OrderDate { get { return _real.Value.OrderDate; } }

        public ProjectProxy(DataContext context, int id)
            : base(null)
        {
            _real = new Lazy<Project>(() => new ProjectMapper(context).Get(id));
        }
    }
}
