using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace auto
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Random r = new Random();
        private double celvonal = 650;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Mozog(auto);
            Mozog(auto2);
            Mozog(auto3);
        }

        private void Mozog(Button auto)
        {
            double aktualpos = Canvas.GetLeft(auto);
            double sebesseg = r.Next(1, 6);
            double ujpos = aktualpos + sebesseg;
            Canvas.SetLeft(auto, ujpos);
            if (ujpos >= celvonal)
            {
                timer.Stop();
                MessageBox.Show($"{auto.Content} nyert!");
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(auto, 20);
            Canvas.SetLeft(auto2, 20);
            Canvas.SetLeft(auto3, 20);
            timer.Start();
        }
    }
}