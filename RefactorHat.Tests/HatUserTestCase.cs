using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RefactorHat.Tests
{
    [TestFixture]
    class HatUserTestCase
    {
        private HatUser User;

        [SetUp]
        public void Init()
        {
            User = new HatUser("testUser");
        }

        [Test]
        public void PutOnRedHat_UserPutOnRedHat_GreenHatIsZero()
        {
            User.PutOnRedHat();
            var timerValue = float.Parse(User.GetGreenHatTimerValue(), CultureInfo.InvariantCulture);
            Assert.AreEqual(timerValue, 0);
        }

        [Test]
        public void PutOnRedHat_UserPutOnRedHat_RefactorHatIsZero()
        {
            User.PutOnRedHat();
            // Parse Doesnt Recognize "."
            var timerValue = float.Parse(User.GetRefactorHatTimerValue(), CultureInfo.InvariantCulture);
            Assert.AreEqual(timerValue, 0);
        }

        [Test]
        public void PutOnRedHat_UserPutOnRedHat_RedHatIsNotZero()
        {
            User.PutOnRedHat();
            // Parse Doesnt Recognize "."
            var timerValue = float.Parse(User.GetRedHatTimerValue(), CultureInfo.InvariantCulture);
            Assert.IsTrue(timerValue > 0);
        }
    }
}
