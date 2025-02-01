using Batoulapps.Adhan;
using Batoulapps.Adhan.Internal;
using Adhan.Test.Internal;

namespace Adhan.Test
{
    public class CalculationParametersTest
    {
        [Fact]
        public void NightPortionMiddleOfTheNight()
        {
            CalculationParameters calcParams = new CalculationParameters(18.0, 18.0);
            calcParams.HighLatitudeRule = HighLatitudeRule.MIDDLE_OF_THE_NIGHT;

            Assert.True(calcParams.NightPortions().Fajr.IsWithin(0.001, 0.5));
            Assert.True(calcParams.NightPortions().Isha.IsWithin(0.001, 0.5));
        }

        [Fact]
        public void NightPortionSeventhOfTheNight()
        {
            CalculationParameters calcParams = new CalculationParameters(18.0, 18.0);
            calcParams.HighLatitudeRule = HighLatitudeRule.SEVENTH_OF_THE_NIGHT;

            Assert.True(calcParams.NightPortions().Fajr.IsWithin(0.001, 1.0 / 7.0));
            Assert.True(calcParams.NightPortions().Isha.IsWithin(0.001, 1.0 / 7.0));
        }

        [Fact]
        public void NightPortionTwilightAngle()
        {
            CalculationParameters calcParams = new CalculationParameters(10.0, 15.0);
            calcParams.HighLatitudeRule = HighLatitudeRule.TWILIGHT_ANGLE;

            Assert.True(calcParams.NightPortions().Fajr.IsWithin(0.001, 10.0 / 60.0));
            Assert.True(calcParams.NightPortions().Isha.IsWithin(0.001, 15.0 / 60.0));
        }
    }
}
