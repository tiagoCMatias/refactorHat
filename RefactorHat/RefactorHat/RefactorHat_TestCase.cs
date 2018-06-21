using System;
using System.Collections.Generic;
using System.Globalization;
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
        private HatUser _user;

        [SetUp]
        public void Init()
        {
            _user = new HatUser("testUser");
        }

        [Test]
        public void PutOnRedHat_UserPutOnRedHat_GreenHatIsZero()
        {
            _user.PutOnRedHat();
            var timerValue = float.Parse(_user.GetGreenHatTimerValue(), CultureInfo.InvariantCulture);
            Assert.AreEqual(timerValue, 0);
        }

        [Test]
        public void PutOnRedHat_UserPutOnRedHat_RefactorHatIsZero()
        {
            _user.PutOnRedHat();
            var timerValue = float.Parse(_user.GetRefactorHatTimerValue(), CultureInfo.InvariantCulture);
            Assert.AreEqual(timerValue, 0);
        }

        [Test]
        public void PutOnRedHat_UserPutOnRedHat_RedHatIsNotZero()
        {
            _user.PutOnRedHat();
            var timerValue = float.Parse(_user.GetRedHatTimerValue(), CultureInfo.InvariantCulture);
            Assert.IsTrue(timerValue > 0);
        }

        [Test]
        public void IsRedHatActive_OnlyOneHatActive_ReturnTrue()
        {
            _user.PutOnRedHat();
            Assert.IsTrue(_user.IsRedHatActive());
        }

        [Test]
        public void GreenHatActive_OnlyOneHatActive_ReturnTrue()
        {
            _user.PutOnGreenHat();
            Assert.IsTrue(_user.IsGreenHatActive());
        }

        [Test]
        public void RefactorHatActive_OnlyOneHatActive_ReturnTrue()
        {
            _user.PutOnRefactorHat();
            Assert.IsTrue(_user.IsRefactorHatActive());
        }
    }
}
