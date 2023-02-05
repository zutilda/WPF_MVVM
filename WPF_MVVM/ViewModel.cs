using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_MVVM
{
    internal class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public CommandBinding bind; // создание объекта для привязки команды
        public RoutedCommand Command { get; set; } = new RoutedCommand();
        private static int CBIndex = -1;
        private bool CheckStart = true;

        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;  // добавление обработчика событий
        }

        public List<string> ComboBoxChange // свойство для заполнения Combobox
        {
            get
            {
                return Model.OperationList;
            }
        }

        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                CBIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Operation"));  // событие, которое реагирует на изменение свойства
            }
        }

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        }

        public string Result
        {
            get
            {
                return Check(Model.One.Text, Model.Two.Text);
            }
            set
            {
            }
        }

        private string Check(string One, string Two)
        {
            try
            {
                double one = Convert.ToDouble(One);
                double two = Convert.ToDouble(Two);

                if (CBIndex == 3 && two == 0)
                {
                    MessageBox.Show("Ошибка деления на 0");
                    return "";
                }

                else return Calc(one, two);
            }
            catch
            {
                if (CheckStart)
                {
                    CheckStart = false;
                    return "";
                }
                MessageBox.Show("Введите данные корректно");
                return "";
            }
        }

        private string Calc(double one, double two)
        {
            switch (CBIndex)
            {
                case 0:
                    return (one + two).ToString();
                case 1:
                    return (one - two).ToString();
                case 2:
                    return (one * two).ToString();
                case 3:
                    return (one / two).ToString();
                default:
                    return "Выберите операцию";
            }
        }
        public string Operation
        {
            get
            {
                if (CBIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataList[CBIndex];
                }

            }
        }
    }
}
