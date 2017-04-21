using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_wpf_miner.Interfaces {
    public interface IGame {
        int Rows { get; set; }
        int Columns { get; set; }
        int Bombs { get; set; }
        void Start();
        void Save();
        void Load();
        void Close();
        void Restart();

    }
}
