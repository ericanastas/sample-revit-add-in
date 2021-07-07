using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace SampleRevitAddin
{
    public class SampleExternalApplication : Autodesk.Revit.UI.IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var assem = System.Reflection.Assembly.GetExecutingAssembly();

            string message = "Version: " + assem.GetName().Version.ToString();
            message += "\nLocation: " + assem.Location;

            Autodesk.Revit.UI.TaskDialog.Show("Sample App", message);

            return Result.Succeeded;
        }
    }
}