using my_wpf_miner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_wpf_miner.BaseClasses {
    public class GameBase<T> : IGame where T : ICellCollection<ICell> {
        public GameBase() {
            Random rnd = new Random();
            Rows = rnd.Next(5, 20);
            Columns = rnd.Next(5, 20);
            Bombs = (Rows * Columns) / 5;
        }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Bombs { get; set; }

        private T cells;
        public T Cells {
            get { return cells; }
            set { cells = value; }
        }


        public void Close() {
            throw new NotImplementedException();
        }

        public void Load() {
            throw new NotImplementedException();
        }

        public void Restart() {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public void Start() {
            cells.Generate(Rows, Columns, Bombs);
        }
    }
}
