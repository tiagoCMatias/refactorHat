using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RefactorHat
{
    class Hat
    {
        private DispatcherTimer _timer;
        private Stopwatch _stopWatch;

        private String _hatName;

        public Hat(string name)
        {
            _hatName = name;
            _stopWatch = new Stopwatch();
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
        }

        public String GetHatName()
        {
            return _hatName;
        }

        public bool IsActive()
        {
            return _timer.IsEnabled;
        }

        public void StartTimer()
        {
                    
            _stopWatch.Start();
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer?.Stop();
            _stopWatch?.Stop();
        }

        public string TimerValue()
        {
            if (_stopWatch == null)
                return "0";

            return TimeSpan.FromSeconds(_stopWatch.Elapsed.TotalSeconds).ToString(@"hh\:mm\:ss");
        }
    }
}
