using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace BindingWPF
{
    public class ViewModel : ViewModelBase
    {

        public ViewModel(UIDocument uidoc)
        {
            UiDoc = uidoc;
            Doc = uidoc.Document;
            RevitEvent revitEvent = new RevitEvent();
            this._event = ExternalEvent.Create(revitEvent);
            

        }


        RevitEvent revitEvent = new RevitEvent();
        LogicElement logicElement = new LogicElement();
        public ExternalEvent _event { get; }

        public Document Doc;
        public UIDocument UiDoc;

        private RelayCommand close;

        public RelayCommand Close
        {
            get
            {
                return close ??
                       (close = new RelayCommand(obj =>
                           {
                               try
                               {
                                   Window window = obj as Window;
                                   window.Close();
                               }
                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message);
                               }
                           },
                           obj => true));
            }
        }

        private RelayCommand _pickCommand;
        public RelayCommand PickCommand {  get
        {
            return _pickCommand ??
                   (_pickCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               //Do some thing code
                               
                             
                               revitEvent.Option = Option.Pick;
                               logicElement.PickElement(UiDoc);

                           }
                           catch (Exception ex)
                           {
                               MessageBox.Show(ex.Message);
                           }

                           _event.Raise();
                       },
                       obj => true));
        } }

        private RelayCommand _removeCommand;

        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                       (_removeCommand = new RelayCommand(obj =>
                           {
                               try
                               {
                                   // Window window = obj as Window;
                                   // window.Close();
                                   //Do some thing code
                                   revitEvent.Option = Option.Remove;

                                   logicElement.RemoveElement(UiDoc, Doc);
                               }
                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message);
                               }

                               _event.Raise();
                           },
                           obj => true));
            }
            
        }


       

    }
}
