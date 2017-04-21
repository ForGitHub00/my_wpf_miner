using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using my_wpf_miner.Interfaces;

namespace my_wpf_miner.BaseClasses {
    public class CellCollectionBase<T> : ICellCollection<T> where T : ICell, new() {
        
        #region ctor
        public CellCollectionBase() {

        }
        public CellCollectionBase(int rows, int columns, int bombs) {
            Generate(rows, columns, bombs);
        }
        #endregion

        #region prop
        public int Size { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Bombs { get; set; }
        public int ClosedCells { get; set; }
        public int OpenCells { get; set; }

        public T[,] Cells { get => cells; set => cells = value; }
        private T[,] cells;
        #endregion

        #region actions
        public virtual void Click(T cell) {
            throw new NotImplementedException();
        }
        public virtual void Click(int index) {
            throw new NotImplementedException();
        }
        public virtual void Click(int RowIndex, int ColumnIndex) {
            throw new NotImplementedException();
        }
        public void Generate(int bombs) {
            throw new NotImplementedException();
        }
        public virtual void Generate(int rows, int columns, int bombs) {
            Rows = rows;
            Columns = columns;
            Size = Rows * Columns;
            Bombs = bombs;

            Cells = new T[Rows, Columns];
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    Cells[i, j] = new T();
                }
            }

            generateBombs();
            calculateValues();
        }
        private void generateBombs() {
            Random rnd = new Random();
            int bombsCount = Bombs;
            while (bombsCount > 0) {
                int i = rnd.Next(0, Rows);
                int j = rnd.Next(0, Columns);
                if (!Cells[i, j].IsBomb) {
                    Cells[i, j].IsBomb = true;
                    bombsCount--;
                }
            }
        }
        private void generateBombs2() {
            List<int> tempMas = new List<int>();
            for (int i = 0; i < Size; i++) {
                tempMas.Add(i);
            }
            int bombsCount = Bombs;
            Random rnd = new Random();
            while (bombsCount > 0) {
                int index = rnd.Next(0, tempMas.Count);
                tempMas.Remove(index);
                int i = index / Columns;
                int j = index % Columns;
                Cells[i, j].IsBomb = true;
                Cells[i, j].Value = -1;
                bombsCount--;
            }
        }
        private void calculateValues() {
            int[,] map = new int[Rows + 2, Columns + 2];
            for (int i = 1; i <= Rows; i++) {
                for (int j = 1; j <= Columns; j++) {
                    if (Cells[i - 1, j - 1].IsBomb) {
                        map[i, j] = 1;
                    }
                }
            }
            for (int i = 1; i <= Rows; i++) {
                for (int j = 1; j <= Columns; j++) {
                    if (map[i, j] != 1) {
                        int value = 0;
                        value += map[i - 1, j - 1];
                        value += map[i - 1, j];
                        value += map[i - 1, j + 1];
                        value += map[i, j - 1];
                        value += map[i, j + 1];
                        value += map[i + 1, j - 1];
                        value += map[i + 1, j];
                        value += map[i + 1, j + 1];
                        Cells[i - 1, j - 1].Value = value;
                    }
                }
            }
        }


        #endregion

        #region testing 
        public override string ToString() {
            string str = "";
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    if (Cells[i, j].IsBomb) {
                        str += "X";
                    } else {
                        str += Cells[i, j].Value.ToString();
                    }
                }
                str += "\n";
            }
            return str;
        }
        #endregion

    }
}
