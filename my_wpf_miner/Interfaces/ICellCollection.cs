using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_wpf_miner.Interfaces {
    public interface ICellCollection<T> where T : ICell {
        int Size { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }
        int Bombs { get; set; }
        int ClosedCells { get; set; }
        int OpenCells { get; set; }
        void Generate(int bombs);
        void Generate(int rows, int height, int bombs);
        void Click(T cell);
        void Click(int index);
        void Click(int LIndex, int RIndex);
        T[,] Cells { get; set; }

    }
}
