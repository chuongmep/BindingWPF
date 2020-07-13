using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace BindingWPF
{
    public class ViewModel : ViewModelBase
    {
        public Document Doc;
        public UIDocument UiDoc;
        public RelayCommand PickCommand { get; set; }

        public RelayCommand RemoveCommand { get; set; }

        public ViewModel(UIDocument uidoc)
        {
            UiDoc = uidoc;
            Doc = uidoc.Document;
            PickCommand = new RelayCommand(x => PickElement(), x => true);
            RemoveCommand = new RelayCommand(x=>RemoveElement(),x=>true);
        }

        public void PickElement()
        {
            Reference r = UiDoc.Selection.PickObject(ObjectType.Element, "Pick a element");
            Element element = Doc.GetElement(r);
            TaskDialog.Show("Info", element.Name);
            
        }

        public void RemoveElement()
        {
            Reference r = UiDoc.Selection.PickObject(ObjectType.Element, "Pick element to delete");
            Element element = Doc.GetElement(r.ElementId);
            try
            {
                using (Transaction tran = new Transaction(Doc))
                {
                    tran.Start("Start");
                    element.Pinned = false;
                    Doc.Delete(element.Id);
                    tran.Commit();
                }
            }
            catch (Exception )
            {
               throw new Exception("Can't Delete Element");
            }
        }
    }
}
