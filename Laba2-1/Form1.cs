using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Runtime.InteropServices;

namespace Laba2_1
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private string surname = "Комарова";

        [DllImport("Lib2-1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern double TheFunc(string surname, double x);

        private static double OperA(string surname) // A
        {
            double x = TheFunc(surname, 1);
            double y = TheFunc(surname, -1);
            return (x + y) / 2;
        }

        private static double OperB(string surname) // B
        {
            double x = TheFunc(surname, 1);
            double y = TheFunc(surname, -1);
            return (x - y) / 2;
        }

        private static double OperC(string surname) // C
        {
            return TheFunc(surname, 0);
        }

        private void TheFunc1() //  y=a*x^2+b*x+c
        {
            cartesianChart1.AxisX.Clear(); 
            cartesianChart1.AxisY.Clear();
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            for (var x = -10; x <= 10; ++x)
            {
                points.Add(new ObservablePoint(x, OperA(surname) * Math.Pow(x, 2) + OperB(surname) * x + OperC(surname)));
            }
            cartesianChart1.Series.Clear();
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = points,
            });
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            textBox.Text = $"A = {OperA(surname)}\tB = {OperB(surname)}\tC = {OperC(surname)}";
            for (int x = 0; x <= 10; x++)
            {
                points.Add(new ObservablePoint(x, TheFunc(surname, x)));
            }
            cartesianChart1.Series.Clear();
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = points,
            });
            TheFunc1();
        }
    }
}
