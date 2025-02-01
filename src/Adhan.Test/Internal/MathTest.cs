using Batoulapps.Adhan.Internal;

namespace Adhan.Test.Internal
{
    public class MathTest
    {
        [Fact]
        public void AngleConversion()
        {
            Assert.True(MathHelper.ToDegrees(Math.PI).IsWithin(0.00001, 180.0));
            Assert.True(MathHelper.ToDegrees(Math.PI / 2).IsWithin(0.00001, 90.0));
        }

        [Fact]
        public void Normalizing()
        {
            Assert.True(DoubleUtil.NormalizeWithBound(2.0, -5).IsWithin(0.00001, -3));
            Assert.True(DoubleUtil.NormalizeWithBound(-4.0, -5.0).IsWithin(0.00001, -4));
            Assert.True(DoubleUtil.NormalizeWithBound(-6.0, -5.0).IsWithin(0.00001, -1));

            Assert.True(DoubleUtil.NormalizeWithBound(-1.0, 24).IsWithin(0.00001, 23));
            Assert.True(DoubleUtil.NormalizeWithBound(1.0, 24.0).IsWithin(0.00001, 1));
            Assert.True(DoubleUtil.NormalizeWithBound(49.0, 24).IsWithin(0.00001, 1));

            Assert.True(DoubleUtil.NormalizeWithBound(361.0, 360).IsWithin(0.00001, 1));
            Assert.True(DoubleUtil.NormalizeWithBound(360.0, 360).IsWithin(0.00001, 0));
            Assert.True(DoubleUtil.NormalizeWithBound(259.0, 360).IsWithin(0.00001, 259));
            Assert.True(DoubleUtil.NormalizeWithBound(2592.0, 360).IsWithin(0.00001, 72));

            Assert.True(DoubleUtil.UnwindAngle(-45.0).IsWithin(0.00001, 315));
            Assert.True(DoubleUtil.UnwindAngle(361.0).IsWithin(0.00001, 1));
            Assert.True(DoubleUtil.UnwindAngle(360.0).IsWithin(0.00001, 0));
            Assert.True(DoubleUtil.UnwindAngle(259.0).IsWithin(0.00001, 259));
            Assert.True(DoubleUtil.UnwindAngle(2592.0).IsWithin(0.00001, 72));

            Assert.True(DoubleUtil.NormalizeWithBound(360.1, 360).IsWithin(0.01, 0.1));
        }

        [Fact]
        public void ClosestAngle()
        {
            Assert.True(DoubleUtil.ClosestAngle(360.0).IsWithin(0.000001, 0));
            Assert.True(DoubleUtil.ClosestAngle(361.0).IsWithin(0.000001, 1));
            Assert.True(DoubleUtil.ClosestAngle(1.0).IsWithin(0.000001, 1));
            Assert.True(DoubleUtil.ClosestAngle(-1.0).IsWithin(0.000001, -1));
            Assert.True(DoubleUtil.ClosestAngle(-181.0).IsWithin(0.000001, 179));
            Assert.True(DoubleUtil.ClosestAngle(180.0).IsWithin(0.000001, 180));
            Assert.True(DoubleUtil.ClosestAngle(359.0).IsWithin(0.000001, -1));
            Assert.True(DoubleUtil.ClosestAngle(-359.0).IsWithin(0.000001, 1));
            Assert.True(DoubleUtil.ClosestAngle(1261.0).IsWithin(0.000001, -179));
            Assert.True(DoubleUtil.ClosestAngle(-360.1).IsWithin(0.01, -0.1));
        }

        [Fact]
        public void TimeComponent()
        {
            TimeComponents comps1 = TimeComponents.FromDouble(15.199);
            Assert.NotNull(comps1);
            Assert.True(comps1.Hours == 15);
            Assert.True(comps1.Minutes == 11);
            Assert.True(comps1.Seconds == 56);

            TimeComponents comps2 = TimeComponents.FromDouble(1.0084);
            Assert.NotNull(comps2);
            Assert.True(comps2.Hours == 1);
            Assert.True(comps2.Minutes == 0);
            Assert.True(comps2.Seconds == 30);

            TimeComponents comps3 = TimeComponents.FromDouble(1.0083);
            Assert.NotNull(comps3);
            Assert.True(comps3.Hours == 1);
            Assert.True(comps3.Minutes == 0);

            TimeComponents comps4 = TimeComponents.FromDouble(2.1);
            Assert.NotNull(comps4);
            Assert.True(comps4.Hours == 2);
            Assert.True(comps4.Minutes == 6);

            TimeComponents comps5 = TimeComponents.FromDouble(3.5);
            Assert.NotNull(comps5);
            Assert.True(comps5.Hours == 3);
            Assert.True(comps5.Minutes == 30);
        }

        [Fact]
        public void MinuteRounding()
        {
            DateTime comps1 = TestUtils.MakeDate(2015, 1, 1, 10, 2, 29);
            DateTime rounded1 = CalendarUtil.RoundedMinute(comps1);
            Assert.True(rounded1.Minute == 2);
            Assert.True(rounded1.Second == 0);

            DateTime comps2 = TestUtils.MakeDate(2015, 1, 1, 10, 2, 31);
            DateTime rounded2 = CalendarUtil.RoundedMinute(comps2);
            Assert.True(rounded2.Minute == 3);
            Assert.True(rounded2.Second == 0);
        }
    }
}
