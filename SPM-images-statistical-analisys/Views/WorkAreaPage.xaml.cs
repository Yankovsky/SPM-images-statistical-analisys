using System.Windows;
using System.Windows.Controls;

namespace Vasya.Views
{
    public partial class WorkAreaPage : UserControl
    {
        public WorkAreaPage()
        {
            InitializeComponent();
        }

        private void FindConvexHullClicked(object sender, RoutedEventArgs e)
        {
            var vm = (this.DataContext as VasyaVM);
            vm.Logic.FindConvexHull(vm.Value);
            
        }
    }
}