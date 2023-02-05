using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace WPF_MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel VM; // объект для работы с VievModel
        public MainWindow()
        {
            InitializeComponent();
            VM = new ViewModel();

            Model.One = one;
            Model.Two = two;

            DataContext = VM;  // добавление объекта VievModel в ресурсы страницы
            CommandBindings.Add(VM.bind);  // добавление объекта привязки на страницу
        }
    }
}
