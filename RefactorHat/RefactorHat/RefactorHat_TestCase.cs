using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using NUnit.Framework;

namespace RefactorHat
{
    [TestFixture]
    class RefactorHatTestCase
    {
        [Test]
        public void StartTimer_clickOnStartBtn_toStartTimer()
        {
            MainWindow testWindow = new MainWindow();

            testWindow.StartTimer();

            Assert.IsTrue(testWindow.IsTimerRunning());
        }
    }
}
