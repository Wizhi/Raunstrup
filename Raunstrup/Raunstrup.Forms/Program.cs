using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Core.Statistics;
using Raunstrup.Core.Xml;
using Raunstrup.Domain;

namespace Raunstrup.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var company = new Company();
            var controller = company.GetDraftController();
            controller.EditDraft(2);
            Application.Run(new DraftCreateForm(company/*,_draftController.GetDraft()*/));
            //Application.Run(new EmployeeStatisticsForm(_company));
        }
               
    }
    }
