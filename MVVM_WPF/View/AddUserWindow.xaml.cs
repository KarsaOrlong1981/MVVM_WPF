using MVVM_WPF.ViewModel;
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
using System.Windows.Shapes;

namespace MVVM_WPF.View
{
    /// <summary>
    /// Interaktionslogik für AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        
        public AddUserWindow()
        {
            InitializeComponent();
            //diese art den DataContext zu übergeben habe ich auf stack Overflow gefunden.
            //Diskutiert wurde hier ob MVVM weiter gegeben ist, argument für MVVM war unter anderem das die View das ViewModel kennen muss
            //aber nicht umgekehrt also wird hier MVVM nicht unterbrochen und das Fenster lässt sich auf einfache art und weise Schließen.
        
            AddUserViewModel vm = new AddUserViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
       
    }
}
