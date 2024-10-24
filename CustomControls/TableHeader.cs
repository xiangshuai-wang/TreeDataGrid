using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeDataGrid.CustomControls
{
    public class TableHeader : Control
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TableHeader), new PropertyMetadata(string.Empty));

        public TextTrimming TextTrimming
        {
            get { return (TextTrimming)GetValue(TextTrimmingProperty); }
            set { SetValue(TextTrimmingProperty, value); }
        }
        public static readonly DependencyProperty TextTrimmingProperty =
        DependencyProperty.Register("TextTrimming", typeof(TextTrimming), typeof(TableHeader), new PropertyMetadata(TextTrimming.None));

        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }
        public static readonly DependencyProperty TextWrappingProperty =
        DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(TableHeader), new PropertyMetadata(TextWrapping.NoWrap));

        private Thumb _thumb;

        static TableHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TableHeader), new FrameworkPropertyMetadata(typeof(TableHeader)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _thumb = (Thumb)GetTemplateChild("PART_Thumb");

            _thumb.Loaded += _thumb_Loaded;
            _thumb.DragDelta += _thumb_DragDelta;
        }

        private void _thumb_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = (Grid)this.Parent;
            if (grid == null) return;
            foreach (var item in grid.ColumnDefinitions)
            {
                Trace.WriteLine(item.ActualWidth);
            }
        }

        private void _thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var grid = (Grid)this.Parent;
            if (grid == null) return;

            int currentColumnIndex = Grid.GetColumn(this);
            if (currentColumnIndex < 0 || currentColumnIndex >= grid.ColumnDefinitions.Count - 1) return;

            var currentColumn = grid.ColumnDefinitions[currentColumnIndex];

            double newWidth = currentColumn.ActualWidth + e.HorizontalChange;

            if (newWidth > 30 && newWidth < 200)
            {
                currentColumn.Width = new GridLength(newWidth);
            }
        }
    }
}
