using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_wpf_miner {
    public class Settings {
        public Settings() {

        }
        private int rows;
        public int Rows {
            get { return rows; }
            set { rows = value; }
        }
        private int columns;
        public int Columns {
            get { return columns; }
            set { columns = value; }
        }

        private int bombs;
        public int Bombs {
            get { return bombs; }
            set { bombs = value; }
        }




    }
}
