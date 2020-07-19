using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ArgumentException = System.ArgumentException;
using MessageBox = System.Windows.Forms.MessageBox;

namespace BindingWPF
{
    

    public class ViewModel : ViewModelBase
    {
        readonly RevitTask _revitTask = new RevitTask();
        public ViewModel()
        {
            CloseCommand = new CloseCommand();
            PickCommand = new RelayCommand(Pickelement);
            RemoveCommand = new RelayCommand(Remove);
            MoveCommand = new RelayCommand(Moveelement);


        }

        public CloseCommand  CloseCommand { get; set; }

        public ICommand PickCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand MoveCommand { get; set; }


        async void Remove()
        {

            await _revitTask.Run((uiApp) =>
                RemoveElement(
                    uiApp.ActiveUIDocument));
        }

        async void Pickelement()
        {
            await _revitTask.Run((uiApp) =>
                PickElement(
                    uiApp.ActiveUIDocument));
        }

        async void Moveelement()
        {
            await _revitTask.Run((uiApp) =>
                MoveElement(
                    uiApp.ActiveUIDocument));
        }

        #region Funtion Main

         static void RemoveElement(UIDocument uidoc)
        {
            Document doc = uidoc.Document;
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
               //do some thing
            }
        }

        static void PickElement(UIDocument uidoc)
        {

            try
            {
                while (true)
                {
                    Document doc = uidoc.Document;
                    Reference r = uidoc.Selection.PickObject(ObjectType.Element, "Please Pick a Element");
                    Element Element = doc.GetElement(r);
                    List<string> result = new List<string>();
                    result.Add("Category:"+ Element.Category.Name);
                    result.Add("Element Name: " + Element.Name);
                    MessageBox.Show(string.Join(Environment.NewLine,result),"Information",MessageBoxButtons.OK);
                }
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }
           
            
        }

        static void MoveElement(UIDocument uidoc)
        {
            Document doc = uidoc.Document;
            Reference r = uidoc.Selection.PickObject(ObjectType.Element, "Please Pick a Element");
            Element Element = doc.GetElement(r);
            using (Transaction tran = new Transaction(doc))
            {
                tran.Start("Move");
                ElementTransformUtils.MoveElement(doc,Element.Id,new XYZ(10,10,0));
                tran.Commit();
            }
            
        }

        #endregion

    }
}
