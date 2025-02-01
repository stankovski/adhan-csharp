using Batoulapps.Adhan;
using Batoulapps.Adhan.Internal;
using Adhan.Test.Internal;

namespace Adhan.Test
{
    public class CalculationMethodTest
    {
        [Fact]
        public void CalcuateMethodMuslimWorldLeague()
        {
            CalculationParameters calcParams = CalculationMethod.MUSLIM_WORLD_LEAGUE.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 18));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 17));
            Assert.Equal(0, calcParams.IshaInterval);
            Assert.Equal(CalculationMethod.MUSLIM_WORLD_LEAGUE, calcParams.Method);
        }

        [Fact]
        public void CalcuateMethodEgyptian()
        {
            CalculationParameters calcParams = CalculationMethod.EGYPTIAN.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 20));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 18));
            Assert.Equal(calcParams.IshaInterval, 0);
            Assert.Equal(calcParams.Method, CalculationMethod.EGYPTIAN);
        }

        [Fact]
        public void CalcuateMethodKarachi()
        {
            CalculationParameters calcParams = CalculationMethod.KARACHI.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 18));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 18));
            Assert.Equal(calcParams.IshaInterval, 0);
            Assert.Equal(calcParams.Method, CalculationMethod.KARACHI);
        }

        [Fact]
        public void CalcuateMethodUmmAlQura()
        {
            CalculationParameters calcParams = CalculationMethod.UMM_AL_QURA.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 18.5));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 0));
            Assert.Equal(calcParams.IshaInterval, 90);
            Assert.Equal(calcParams.Method, CalculationMethod.UMM_AL_QURA);
        }

        [Fact]
        public void CalcuateMethodDubai()
        {
            CalculationParameters calcParams = CalculationMethod.DUBAI.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 18.2));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 18.2));
            Assert.Equal(calcParams.IshaInterval, 0);
            Assert.Equal(calcParams.Method, CalculationMethod.DUBAI);
        }

        [Fact]
        public void CalcuateMethodMoonSightingCommittee()
        {
            CalculationParameters calcParams = CalculationMethod.MOON_SIGHTING_COMMITTEE.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 18));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 18));
            Assert.Equal(calcParams.IshaInterval, 0);
            Assert.Equal(calcParams.Method, CalculationMethod.MOON_SIGHTING_COMMITTEE);
        }

        [Fact]
        public void CalcuateMethodNorthAmerica()
        {
            CalculationParameters calcParams = CalculationMethod.NORTH_AMERICA.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 15));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 15));
            Assert.Equal(calcParams.IshaInterval, 0);
            Assert.Equal(calcParams.Method, CalculationMethod.NORTH_AMERICA);
        }

        [Fact]
        public void CalcuateMethodKuwait()
        {
            CalculationParameters calcParams = CalculationMethod.KUWAIT.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 18));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 17.5));
            Assert.Equal(calcParams.IshaInterval, 0);
            Assert.Equal(calcParams.Method, CalculationMethod.KUWAIT);
        }

        [Fact]
        public void CalcuateMethodQatar()
        {
            CalculationParameters calcParams = CalculationMethod.QATAR.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 18));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 0));
            Assert.Equal(calcParams.IshaInterval, 90);
            Assert.Equal(calcParams.Method, CalculationMethod.QATAR);
        }

        [Fact]
        public void CalcuateMethodOther()
        {
            CalculationParameters calcParams = CalculationMethod.OTHER.GetParameters();
            Assert.True(calcParams.FajrAngle.IsWithin(0.000001, 0));
            Assert.True(calcParams.IshaAngle.IsWithin(0.000001, 0));
            Assert.Equal(calcParams.IshaInterval, 0);
            Assert.Equal(calcParams.Method, CalculationMethod.OTHER);
        }
    }
}
