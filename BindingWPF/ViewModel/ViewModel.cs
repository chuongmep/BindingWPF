using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private readonly RevitTask _revitTask = new RevitTask();
        public ViewModel()
        {
            RemoveCommand = new RelayCommand(Remove);
            CloseCommand = new RelayCommand(CloseAction);

        }

        public ICommand PickCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand MoveCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        void CloseAction()
        {
            MessageBox.Show("Test");
            try
            {
                Window Window = new Window();
                Window.Close();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        private async void Remove()
        {

            await _revitTask.Run((uiApp) =>
                RemoveElement(
                    uiApp.ActiveUIDocument));
        }

        private void RemoveElement(UIDocument uidoc)
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
                TaskDialog.Show("Info", e.ToString());
            }
        }

    }
}
