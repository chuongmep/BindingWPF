using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.UI;
using BindingWPF;

namespace BindingWPF
{
    /// <summary>
    /// Interaction logic for FrmDemo.xaml
    /// </summary>
    public partial class FrmDemo
    {
        private RevitEvent _revitEvent;
        ExternalEvent _myExternalEvent;
        private ViewModel _ViewModel;
        public FrmDemo(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            this._ViewModel = viewModel;
            //Topmost = true;
            _revitEvent = new RevitEvent();
            _myExternalEvent = ExternalEvent.Create(_revitEvent);
            _myExternalEvent.Raise();
        }
    }
}
