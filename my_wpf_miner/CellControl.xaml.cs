using my_wpf_miner.Interfaces;
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

namespace my_wpf_miner {
    /// <summary>
    /// Логика взаимодействия для CellControl.xaml
    /// </summary>
    public partial class CellControl : UserControl, ICell {
        public CellControl() {
            InitializeComponent();
            DataContext = this;
            Value = 1;
        }

        public bool IsOpen { get; set; }
        public bool IsEmpty { get; set; }
        private bool _isBomb;
        public bool IsBomb {
            get { return _isBomb; }
            set {
                Value = -1;
                _isBomb = value;
            }
        }
        private int _value;
        public int Value {
            get { return _value; }
            set {
                IsOpen = false;
                if (value == 0)
                    IsEmpty = true;
                else
                    IsEmpty = false;
                _value = value;
            }
        }

        public bool Loss() {
            return false;
        }
        public void Open() { }
        public void Open(object sender, RoutedEventArgs e) {
            Console.WriteLine($"{IsBomb}");
        }
    }
}
