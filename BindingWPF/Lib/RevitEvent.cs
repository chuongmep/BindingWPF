using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace BindingWPF
{
    public class RevitEvent : IExternalEventHandler

    {
        public LogicElement logic { get; set; }
        public Option Option { get; set; }
        public void Execute(UIApplication uiapp)
        {

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Option = Option.Pick;
            switch (Option)
            {
                case Option.Pick:
                    logic.PickElement(uidoc);
                    break;
                case Option.Remove:
                    logic.RemoveElement(uidoc,doc);
                    break;
            }
            
            
        }

        public string GetName()
        {
            return "Do Job";
        }


       
    }

}
