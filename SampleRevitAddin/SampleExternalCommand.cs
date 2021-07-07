using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace SampleRevitAddin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class SampleExternalCommand : Autodesk.Revit.UI.IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
#if REVIT2017
            Autodesk.Revit.UI.TaskDialog.Show("SampleExternalCommand", "Sample Revit 2017 Add-in");
#elif REVIT2018
            Autodesk.Revit.UI.TaskDialog.Show("SampleExternalCommand", "Sample Revit 2018 Add-in");
#elif REVIT2019
            Autodesk.Revit.UI.TaskDialog.Show("SampleExternalCommand", "Sample Revit 2019 Add-in");
#elif REVIT2020
            Autodesk.Revit.UI.TaskDialog.Show("SampleExternalCommand", "Sample Revit 2020 Add-in");
#endif

            return Result.Succeeded;
        }
    }
}