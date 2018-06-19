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
using Timer = System.Timers.Timer;

namespace RefactorHat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private String HAT_STATE_RED = "RED";
        private String HAT_STATE_GREEN = "GREEN";
        private String HAT_STATE_REFACTOR = "REFACTOR";
        private DispatcherTimer _mainTimer;
        private Stopwatch _stopWatch;

        public String MainTimerText;

        public String STATE = "NO_STATE";

        private Hat _redHat;
        private Hat _greenHat;
        private Hat _refactorHat;


        public MainWindow()
        {
            _redHat = new Hat("Red Hat");
            _greenHat = new Hat("Green Hat");
            _refactorHat = new Hat("Refactor Hat");
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
                Interval = TimeSpan.FromSeconds(1)
            };

            _mainTimer.Tick += DispatcherMainTimerTick;
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
            _mainTimer.Start();
        }

        //Timer Handler
        private void DispatcherMainTimerTick(object sender, EventArgs e)
        {
            MainTimerText = TimeSpan.Parse(_stopWatch.Elapsed.ToString()).TotalSeconds.ToString(CultureInfo.InvariantCulture);
            Debug.WriteLine("Main " + MainTimerText);
            Debug.WriteLine("Red Hat " + _redHat.TimerValue());
            Debug.WriteLine("Green Hat " + _greenHat.TimerValue());
            Debug.WriteLine("Refactor Hat " + _refactorHat.TimerValue());
        }

        private void RedHatBtn_Click(object sender, RoutedEventArgs e)
        {
            StartRedHat();
        }

        private void GreenHatBtn_Click(object sender, RoutedEventArgs e)
        {
            StartGreenHat();
        }

        private void RefactorHatBtn_Click(object sender, RoutedEventArgs e)
        {
            StartRefactorHat();
        }

        public void StartTimerBtn_Click(object sender, RoutedEventArgs e)
        {
            StartTimer();
        }

        public void StartRedHat()
        {
            _redHat.StartTimer();
            _greenHat.StopTimer();
            _refactorHat.StopTimer();
            STATE = HAT_STATE_RED;
        }

        public void StartGreenHat()
        {
            _greenHat.StartTimer();
            _redHat.StopTimer();
            _refactorHat.StopTimer();
            STATE = HAT_STATE_GREEN;
        }

        public void StartRefactorHat()
        {
            _refactorHat.StartTimer();
            _greenHat.StopTimer();
            _redHat.StopTimer();
            STATE = HAT_STATE_REFACTOR;
        }
    }
}
