using Autodesk.Revit.UI;

namespace BindingWPF
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
