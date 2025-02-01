﻿using Batoulapps.Adhan;
using Batoulapps.Adhan.Internal;
using Adhan.Test.Internal;

namespace Adhan.Test
{
    public class PrayerTimesTest
    {
        [Fact]
        public void DaysSinceSolstice()
        {
            DaysSinceSolsticeTest(11, /* year */ 2016, /* month */ 1, /* day */ 1, /* latitude */ 1);
            DaysSinceSolsticeTest(10, /* year */ 2015, /* month */ 12, /* day */ 31, /* latitude */ 1);
            DaysSinceSolsticeTest(10, /* year */ 2016, /* month */ 12, /* day */ 31, /* latitude */ 1);
            DaysSinceSolsticeTest(0, /* year */ 2016, /* month */ 12, /* day */ 21, /* latitude */ 1);
            DaysSinceSolsticeTest(1, /* year */ 2016, /* month */ 12, /* day */ 22, /* latitude */ 1);
            DaysSinceSolsticeTest(71, /* year */ 2016, /* month */ 3, /* day */ 1, /* latitude */ 1);
            DaysSinceSolsticeTest(70, /* year */ 2015, /* month */ 3, /* day */ 1, /* latitude */ 1);
            DaysSinceSolsticeTest(365, /* year */ 2016, /* month */ 12, /* day */ 20, /* latitude */ 1);
            DaysSinceSolsticeTest(364, /* year */ 2015, /* month */ 12, /* day */ 20, /* latitude */ 1);

            DaysSinceSolsticeTest(0, /* year */ 2015, /* month */ 6, /* day */ 21, /* latitude */ -1);
            DaysSinceSolsticeTest(0, /* year */ 2016, /* month */ 6, /* day */ 21, /* latitude */ -1);
            DaysSinceSolsticeTest(364, /* year */ 2015, /* month */ 6, /* day */ 20, /* latitude */ -1);
            DaysSinceSolsticeTest(365, /* year */ 2016, /* month */ 6, /* day */ 20, /* latitude */ -1);
        }


        [Fact]
        public void PrayerTimesAmericaNewYork()
        {
            TimeZoneInfo timezone = TestUtils.GetTimeZone("America/New_York");

            DateComponents date = new DateComponents(2015, 7, 12);
            CalculationParameters calcParams = CalculationMethod.NORTH_AMERICA.GetParameters();
            calcParams.Madhab = Madhab.HANAFI;

            Coordinates coordinates = new Coordinates(35.7750, -78.6336);
            PrayerTimes prayerTimes = new PrayerTimes(coordinates, date, calcParams);

            Assert.True(GetHour(prayerTimes.Fajr, timezone) == "04:42 AM");
            Assert.True(GetHour(prayerTimes.Sunrise, timezone) == "06:08 AM");
            Assert.True(GetHour(prayerTimes.Dhuhr, timezone) == "01:21 PM");
            Assert.True(GetHour(prayerTimes.Asr, timezone) == "06:22 PM");
            Assert.True(GetHour(prayerTimes.Maghrib, timezone) == "08:32 PM");
            Assert.True(GetHour(prayerTimes.Isha, timezone) == "09:57 PM");
        }

        [Fact]
        public void OffsetTests()
        {
            TimeZoneInfo timezone = TestUtils.GetTimeZone("America/New_York");

            DateComponents date = new DateComponents(2015, 12, 1);
            Coordinates coordinates = new Coordinates(35.7750, -78.6336);      
            CalculationParameters parameters = CalculationMethod.MUSLIM_WORLD_LEAGUE.GetParameters();

            PrayerTimes prayerTimes = new PrayerTimes(coordinates, date, parameters);
            Assert.True(GetHour(prayerTimes.Fajr, timezone) == "05:35 AM");
            Assert.True(GetHour(prayerTimes.Sunrise, timezone) == "07:06 AM");
            Assert.True(GetHour(prayerTimes.Dhuhr, timezone) == "12:05 PM");
            Assert.True(GetHour(prayerTimes.Asr, timezone) == "02:42 PM");
            Assert.True(GetHour(prayerTimes.Maghrib, timezone) == "05:01 PM");
            Assert.True(GetHour(prayerTimes.Isha, timezone) == "06:26 PM");

            parameters.Adjustments.Fajr = 10;
            parameters.Adjustments.Sunrise = 10;
            parameters.Adjustments.Dhuhr = 10;
            parameters.Adjustments.Asr = 10;
            parameters.Adjustments.Maghrib = 10;
            parameters.Adjustments.Isha = 10;

            prayerTimes = new PrayerTimes(coordinates, date, parameters);
            Assert.True(GetHour(prayerTimes.Fajr, timezone) == "05:45 AM");
            Assert.True(GetHour(prayerTimes.Sunrise, timezone) == "07:16 AM");
            Assert.True(GetHour(prayerTimes.Dhuhr, timezone) == "12:15 PM");
            Assert.True(GetHour(prayerTimes.Asr, timezone) == "02:52 PM");
            Assert.True(GetHour(prayerTimes.Maghrib, timezone) == "05:11 PM");
            Assert.True(GetHour(prayerTimes.Isha, timezone) == "06:36 PM");

            parameters.Adjustments = new PrayerAdjustments();
            prayerTimes = new PrayerTimes(coordinates, date, parameters);
            Assert.True(GetHour(prayerTimes.Fajr, timezone) == "05:35 AM");
            Assert.True(GetHour(prayerTimes.Sunrise, timezone) == "07:06 AM");
            Assert.True(GetHour(prayerTimes.Dhuhr, timezone) == "12:05 PM");
            Assert.True(GetHour(prayerTimes.Asr, timezone) == "02:42 PM");
            Assert.True(GetHour(prayerTimes.Maghrib, timezone) == "05:01 PM");
            Assert.True(GetHour(prayerTimes.Isha, timezone) == "06:26 PM");
        }

        [Fact]
        public void MoonsightingMethod()
        {
            TimeZoneInfo timezone = TestUtils.GetTimeZone("America/New_York");

            DateComponents date = new DateComponents(2016, 1, 31);
            Coordinates coordinates = new Coordinates(35.7750, -78.6336);
            PrayerTimes prayerTimes = new PrayerTimes(
                coordinates, date, CalculationMethod.MOON_SIGHTING_COMMITTEE.GetParameters());

            Assert.True(GetHour(prayerTimes.Fajr, timezone) == "05:48 AM");
            Assert.True(GetHour(prayerTimes.Sunrise, timezone) == "07:16 AM");
            Assert.True(GetHour(prayerTimes.Dhuhr, timezone) == "12:33 PM");
            Assert.True(GetHour(prayerTimes.Asr, timezone) == "03:20 PM");
            Assert.True(GetHour(prayerTimes.Maghrib, timezone) == "05:43 PM");
            Assert.True(GetHour(prayerTimes.Isha, timezone) == "07:05 PM");
        }

        [Fact]
        public void MoonsightingMethodHighLat()
        {
            TimeZoneInfo timezone = TestUtils.GetTimeZone("Europe/Oslo");
        
            // Values from http://www.moonsighting.com/pray.php
            DateComponents date = new DateComponents(2016, 1, 1);
            CalculationParameters parameters = CalculationMethod.MOON_SIGHTING_COMMITTEE.GetParameters();
            parameters.Madhab = Madhab.HANAFI;
            Coordinates coordinates = new Coordinates(59.9094, 10.7349);

            PrayerTimes prayerTimes = new PrayerTimes(coordinates, date, parameters);

            Assert.True(GetHour(prayerTimes.Fajr, timezone) == "07:34 AM");
            Assert.True(GetHour(prayerTimes.Sunrise, timezone) == "09:19 AM");
            Assert.True(GetHour(prayerTimes.Dhuhr, timezone) == "12:25 PM");
            Assert.True(GetHour(prayerTimes.Asr, timezone) == "01:36 PM");
            Assert.True(GetHour(prayerTimes.Maghrib, timezone) == "03:25 PM");
            Assert.True(GetHour(prayerTimes.Isha, timezone) == "05:02 PM");
        }

        [Fact]
        public void TimeForPrayer()
        {
            DateComponents components = new DateComponents(2016, 7, 1);
            CalculationParameters parameters = CalculationMethod.MUSLIM_WORLD_LEAGUE.GetParameters();
            parameters.Madhab = Madhab.HANAFI;
            parameters.HighLatitudeRule = HighLatitudeRule.TWILIGHT_ANGLE;
            Coordinates coordinates = new Coordinates(59.9094, 10.7349);

            PrayerTimes p = new PrayerTimes(coordinates, components, parameters);
            Assert.True(p.Fajr == p.TimeForPrayer(Prayer.FAJR));
            Assert.True(p.Sunrise == p.TimeForPrayer(Prayer.SUNRISE));
            Assert.True(p.Dhuhr == p.TimeForPrayer(Prayer.DHUHR));
            Assert.True(p.Asr == p.TimeForPrayer(Prayer.ASR));
            Assert.True(p.Maghrib == p.TimeForPrayer(Prayer.MAGHRIB));
            Assert.True(p.Isha == p.TimeForPrayer(Prayer.ISHA));
            Assert.Null(p.TimeForPrayer(Prayer.NONE));
        }

        [Fact]
        public void CurrentPrayer()
        {
            DateComponents components = new DateComponents(2015, 9, 1);
            CalculationParameters parameters = CalculationMethod.KARACHI.GetParameters();
            parameters.Madhab = Madhab.HANAFI;
            parameters.HighLatitudeRule = HighLatitudeRule.TWILIGHT_ANGLE;
            Coordinates coordinates = new Coordinates(33.720817, 73.090032);

            PrayerTimes p = new PrayerTimes(coordinates, components, parameters);

            Assert.True(p.CurrentPrayer(TestUtils.AddSeconds(p.Fajr, -1)) == Prayer.NONE);
            Assert.True(p.CurrentPrayer(p.Fajr) == Prayer.FAJR);
            Assert.True(p.CurrentPrayer(TestUtils.AddSeconds(p.Fajr, 1)) == Prayer.FAJR);
            Assert.True(p.CurrentPrayer(TestUtils.AddSeconds(p.Sunrise, 1)) == Prayer.SUNRISE);
            Assert.True(p.CurrentPrayer(TestUtils.AddSeconds(p.Dhuhr, 1)) == Prayer.DHUHR);
            Assert.True(p.CurrentPrayer(TestUtils.AddSeconds(p.Asr, 1)) == Prayer.ASR);
            Assert.True(p.CurrentPrayer(TestUtils.AddSeconds(p.Maghrib, 1)) == Prayer.MAGHRIB);
            Assert.True(p.CurrentPrayer(TestUtils.AddSeconds(p.Isha, 1)) == Prayer.ISHA);
        }

        [Fact]
        public void NextPrayer()
        {
            DateComponents components = new DateComponents(2015, 9, 1);
            CalculationParameters parameters = CalculationMethod.KARACHI.GetParameters();
            parameters.Madhab = Madhab.HANAFI;
            parameters.HighLatitudeRule = HighLatitudeRule.TWILIGHT_ANGLE;
            Coordinates coordinates = new Coordinates(33.720817, 73.090032);

            PrayerTimes p = new PrayerTimes(coordinates, components, parameters);

            Assert.True(p.NextPrayer(TestUtils.AddSeconds(p.Fajr, -1)) == Prayer.FAJR);
            Assert.True(p.NextPrayer(p.Fajr) == Prayer.SUNRISE);
            Assert.True(p.NextPrayer(TestUtils.AddSeconds(p.Fajr, 1)) == Prayer.SUNRISE);
            Assert.True(p.NextPrayer(TestUtils.AddSeconds(p.Sunrise, 1)) == Prayer.DHUHR);
            Assert.True(p.NextPrayer(TestUtils.AddSeconds(p.Dhuhr, 1)) == Prayer.ASR);
            Assert.True(p.NextPrayer(TestUtils.AddSeconds(p.Asr, 1)) == Prayer.MAGHRIB);
            Assert.True(p.NextPrayer(TestUtils.AddSeconds(p.Maghrib, 1)) == Prayer.ISHA);
            Assert.True(p.NextPrayer(TestUtils.AddSeconds(p.Isha, 1)) == Prayer.NONE);
        }

        private void DaysSinceSolsticeTest(int value, int year, int month, int day, double latitude)
        {
            // For Northern Hemisphere start from December 21
            // (DYY=0 for December 21, and counting forward, DYY=11 for January 1 and so on).
            // For Southern Hemisphere start from June 21
            // (DYY=0 for June 21, and counting forward)
            DateTime date = TestUtils.MakeDate(year, month, day);
            int dayOfYear = TestUtils.GetDayOfYear(date);
            Assert.True(PrayerTimes.DaysSinceSolstice(dayOfYear, date.Year, latitude) == value);            
        }

        private string GetHour(DateTime inputDateTime, TimeZoneInfo destinationTimeZoneInfo)
        {
            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(inputDateTime, destinationTimeZoneInfo);
            return localDateTime.ToString("hh:mm tt");
        }
    }
}
