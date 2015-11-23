using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Core.Domain;
using Raunstrup.Core.Repos;

namespace Raunstrup.Core.Controllers
{
    public class ProjectController
    {
        private IDraftRepository _draftRepository;

        public ProjectController(IDraftRepository draftRepository)
        {
            _draftRepository = draftRepository;
        }
        public Draft createDraft(Employee employee, string title, Customer customer)
        {
            Draft draft = new Draft(customer,title,employee);
            _draftRepository.Save(draft);
            return draft;
        }

        public void SetDraftTitle(Draft draft, string title)
        {
            
        }
    }
}
