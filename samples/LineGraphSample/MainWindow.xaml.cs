// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using InteractiveDataDisplay.WPF;

namespace LineGraphSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Random r = new Random();
            double[] x = new double[11] { 0, 1, 2, 3, 4,5,6,7,8,9,10};
            //for (int i = 0; i < x.Length; i++)
            //    x[i] = i;// 2 * i / (x.Length - 1);

            Loaded += (o, e) => plotter.HPlotAxis.Axis.LabelProvider = new Provider();

            //var bg = new BarGraph();
            //lines.Children.Add(bg);
            bg.StrokeThickness = 0;
            bg.BarsWidth = 0.5;
            bg.PlotBars(x, x.Select(o => o + r.Next(10)).ToArray());

            bg2.StrokeThickness = 0;
            bg2.BarsWidth = 0.5;
            bg2.PlotBars(x, x.Select(o => o + r.Next(100)).ToArray());

            //for (int i = 0; i < 2; i++)
            //{
                var i = 3;
            //lines.Children.Add(lg);
            //lg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, (byte)(i * 10), 0));
            //    lg.Description = String.Format("Data series {0}", i + 1);
            //    lg.StrokeThickness = 2;
            //    lg.Plot(x, x.Select(o => o + r.Next(100)).ToArray());// x.Select(v => Math.Sin(v + i / 10.0)).ToArray());
            //}
        }
    }

    public class VisibilityToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Visibility)value) == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    public class Provider : ILabelProvider
    {
        public FrameworkElement[] GetLabels(double[] ticks)
        {
            return ticks.Select(o =>
            {
                var label = new System.Windows.Controls.TextBlock();
                label.Text = $"Lina {o}";
                return label;
            }).ToArray();
        }
    }
}
