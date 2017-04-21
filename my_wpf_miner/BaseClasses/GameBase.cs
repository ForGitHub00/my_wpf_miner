using my_wpf_miner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_wpf_miner.BaseClasses {
    public class GameBase : IGame {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Bombs { get; set; }

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
            throw new NotImplementedException();
        }
    }
}
