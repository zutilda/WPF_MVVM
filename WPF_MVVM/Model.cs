﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_MVVM
{
    internal class Model
    {      

        public static List<string> OperationList = new List<string> { "Сложение", "Вычитание", "Умножение", "Деление" };
        public static List<string> dataList = new List<string> { "+", "-", "*", "/" };

        public static TextBox One;
        public static TextBox Two;
    }
}
