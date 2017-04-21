using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_wpf_miner.Interfaces {
    public interface ICell {
        bool IsBomb { get; set; }
        bool IsEmpty { get; set; }
        bool IsOpen { get; set; }
        int Value { get; set; }
        void Open();
        bool Loss();
    }
}
