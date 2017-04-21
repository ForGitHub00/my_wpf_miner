using my_wpf_miner.Interfaces;
using my_wpf_miner.BaseClasses;
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
using System.Diagnostics;

namespace my_wpf_miner {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            CellCollectionBase<CellBase> temp = new CellCollectionBase<CellBase>(10, 10, 10);

            Stopwatch sw = new Stopwatch();

            //while (Console.ReadLine() != "q") {
            //    Console.Clear();
            //    sw.Start();
            //    temp.Generate(10, 10, 10);
            //    sw.Stop();
            //    Console.WriteLine(sw.ElapsedMilliseconds);
            //    sw.Reset();
            //    Console.WriteLine(temp.ToString());
            //}

            Console.WriteLine(temp.ToString());
            // temp.Generate(10, 10, 10);
            for (int i = 0; i < temp.Rows; i++) {
                grid.RowDefinitions.Add(new RowDefinition() {Height = GridLength.Auto});
                for (int j = 0; j < temp.Columns; j++) {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    Button bt = new Button() {
                        Content = temp.Cells[i, j].Value,
                    };
                    bt.Click += temp.Cells[i, j].Open;
                    Grid.SetRow(bt, i + 1);
                    Grid.SetColumn(bt, j + 1);
                    grid.Children.Add(bt);
                }
            }
        }

    }
}
