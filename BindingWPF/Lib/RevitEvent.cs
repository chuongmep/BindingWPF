using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BindingWPF;

namespace RevitAPISamPle
{
  internal  class RevitEvent  : IExternalEventHandler

  {
      public ViewModel viewModel { get; set; }
      public void Execute(UIApplication uiapp)
      {

           viewModel.PickElement();
           viewModel.RemoveElement();
      }

      public string GetName()
      {
          return "element";
      }
    }
}
