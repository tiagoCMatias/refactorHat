using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using NUnit.Framework.Internal;
using Timer = System.Timers.Timer;

namespace RefactorHat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private DispatcherTimer _mainTimer;
        private Stopwatch _stopWatch;

        public String _mainTimerText;

        public string MainTimerText
        {
            get => _mainTimerText;
            set => _mainTimerText = value;
        }

        private HatUser User;

        public MainWindow()
        {
            User = new HatUser("NewUser");
            InitializeComponent();            
        }

        public String MainTimerValue()
        {
            if (_stopWatch == null)
                return "0";

            return TimeSpan.Parse(_stopWatch.Elapsed.ToString()).TotalSeconds
                .ToString(CultureInfo.InvariantCulture);
        }

        public bool IsTimerRunning()
        {
            return _mainTimer.IsEnabled;
        }

        //Application Timer
        public void StartTimer()
        {
            _mainTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };

            _mainTimer.Tick += DispatcherMainTimerTick;
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
            _mainTimer.Start();
        }

        //Timer Handler
        private void DispatcherMainTimerTick(object sender, EventArgs e)
        {
            //MainTimerText = TimeSpan.Parse(_stopWatch.Elapsed.ToString()).TotalSeconds.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
            MainTimerText = TimeSpan.FromSeconds(_stopWatch.Elapsed.TotalSeconds).ToString(@"hh\:mm\:ss");
            MainTimerTxt.Text = MainTimerText;

            RedHatTimer.Text = User.GetRedHatTimerValue();
            GreenHatTimer.Text = User.GetGreenHatTimerValue();
            RefactorHatTimer.Text = User.GetRefactorHatTimerValue();

            Debug.WriteLine("Main " + _mainTimerText);
        }

        private void RedHatBtn_Click(object sender, RoutedEventArgs e)
        {
            User.PutOnRedHat();
            RedHatBtn.Background = Brushes.Red;
            GreenHatBtn.Background = Brushes.Gray;
            RefactorHatBtn.Background = Brushes.Gray;
        }

        private void GreenHatBtn_Click(object sender, RoutedEventArgs e)
        {
            User.PutOnGreenHat();
            RedHatBtn.Background = Brushes.Gray;
            GreenHatBtn.Background = Brushes.Green;
            RefactorHatBtn.Background = Brushes.Gray;
        }

        private void RefactorHatBtn_Click(object sender, RoutedEventArgs e)
        {
            User.PutOnRefactorHat();
            RedHatBtn.Background = Brushes.Gray;
            GreenHatBtn.Background = Brushes.Gray;
            RefactorHatBtn.Background = Brushes.GreenYellow;
        }

        public void StartTimerBtn_Click(object sender, RoutedEventArgs e)
        {
            User = new HatUser("Ola");
            StartTimer();
        }

       
    }
}
