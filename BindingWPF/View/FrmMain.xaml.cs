using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for FrmMain.xaml
    /// </summary>
    public partial class FrmMain
    {
        
        public FrmMain()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            InitializeComponent();
            Topmost = true;
            WindowStartupLocation = WindowStartupLocation.Manual;
            ResizeMode = ResizeMode.NoResize;
        }

        public FrmMain(ViewModel viewModel) : this()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            DataContext = viewModel;
        }
    }
}
