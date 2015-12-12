using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");

            var company = new Company();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var controller = company.CreateDraftController();
            controller.EditDraft(2);
            //Application.Run(new DraftCreateForm(company/*,controller.GetDraft()*/));
            //Application.Run(new EmployeeStatisticsForm(company));
            //Application.Run(new ProductSelectForm(company));
            Application.Run(new EmployeeCRUDForm(company));
        }
               
    }
    }
