using my_wpf_miner.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace my_wpf_miner.BaseClasses {
    public class CellBase : ICell {
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

        public  void Open() { }

        public void Open(object sender, RoutedEventArgs e) {
            Console.WriteLine($"{IsBomb}");
        }

    }
}
