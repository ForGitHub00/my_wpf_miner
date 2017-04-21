using my_wpf_miner.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace my_wpf_miner {
    public abstract class BoardPanelBase : Panel {
        public BoardPanelBase() {

        }
        protected override Size ArrangeOverride(Size finalSize) {
            for (int i = 0; i < InternalChildren.Count; i++) {
                double tempX = 50 * (i % Columns);
                double tempY = 50 * (i / Columns);
                InternalChildren[i].Arrange(new Rect(new Point(tempX, tempY), InternalChildren[i].DesiredSize));
            }
            return new Size(5 * Rows, 5 * Columns);
        }
        protected override Size MeasureOverride(Size availableSize) {
            foreach (UIElement child in InternalChildren) {
                child.Measure(availableSize);
            }
            return new Size(Rows * 50 + 10, Columns * 50 + 10);
        }

        public void redraw() {
            Children.Clear();
            foreach (var item in Data.Cells) {
                Children.Add(item);
            }
        }

        public int Rows {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(int), typeof(BoardPanelBase), new PropertyMetadata(0));


        public int Columns {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Columns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(int), typeof(BoardPanelBase), new PropertyMetadata(0));



        public  ICellCollection<ICell> Data {
            get { return (ICellCollection<ICell>)GetValue(DataProperty); }
            set {
                SetValue(DataProperty, value);
                redraw();
            }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(ICellCollection<ICell>), typeof(BoardPanelBase), new PropertyMetadata(null));


    }
}
