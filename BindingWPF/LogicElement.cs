using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace BindingWPF
{
    [Transaction(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class LogicElement
    {
        public void RemoveElement(UIDocument uidoc,Document doc)
        {
            Reference r = uidoc.Selection.PickObject(ObjectType.Element, "Pick element to delete");
            Element element = doc.GetElement(r.ElementId);
            try
            {
                using (Transaction tran = new Transaction(doc))
                {
                    tran.Start("Change");
                    element.Pinned = false;
                    doc.Delete(element.Id);
                    tran.Commit();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public void PickElement(UIDocument uidoc)
        {
            Document doc = uidoc.Document;
            Reference r = uidoc.Selection.PickObject(ObjectType.Element, "Pick a element");
            Element element = doc.GetElement(r);
            TaskDialog.Show("Info", element.Name);

        }
    }
}
