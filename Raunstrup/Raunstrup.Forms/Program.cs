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
        private static Company _company;
        private static DraftController _draftController;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _company = new Company();
            _draftController = _company.GetDraftController();
            _draftController.EditDraft(2);
            Application.Run(new DraftCreateForm(/*_draftController.GetDraft()*/));
        }
               
    }
    }
