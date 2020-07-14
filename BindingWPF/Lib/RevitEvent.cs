using System;
using Autodesk.Revit.UI;

namespace BindingWPF
{
    internal class RevitEvent : IExternalEventHandler

    {
        public option op;
        public ViewModel viewModel { get; set; }
        public void Execute(UIApplication uiapp)
        {
            switch (op)
            {
                case option.pick:
                    viewModel.PickElement();
                    break;
                case option.remove:
                    viewModel.RemoveElement();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
           
            
        }

        public string GetName()
        {
            return "element";
        }
    }

    enum  option
    {
        pick,remove
    }
}
