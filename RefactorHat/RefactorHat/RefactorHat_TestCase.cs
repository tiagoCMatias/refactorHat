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
    class RefactorHat_TestCase
    {


        public void StartTimer_clickOnStartBtn_toStartTimer()
        {
            var wasCalled = false;

            MainWindow testWindow = new MainWindow();

            testWindow.StartTimerBtn.Click += testWindow.StartTimerBtn_Click;

            testWindow.StartTimerBtn.Click += (sender, args) => wasCalled = true;

            Assert.True(wasCalled);

        }
    }
}
