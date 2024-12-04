﻿using System;
using System.Globalization;
using System.Linq;

namespace CSharp.ExtensionMethods
{
    /// <summary>
    /// Date Extension Type
    /// </summary>
    public static class DateExtensions
    {
        #region Between

        /// <summary>
        /// Function to check if the given date is between a date range i.e. start date and end date
        /// </summary>
        /// <param name="inputDate">Input date to check between a range</param>
        /// <param name="rangeStart">Range start date</param>
        /// <param name="rangeEnd">Range end date</param>
        /// <returns></returns>
        public static bool Between(this DateTime inputDate, DateTime rangeStart, DateTime rangeEnd)
        {
            return inputDate.Ticks >= rangeStart.Ticks && inputDate.Ticks <= rangeEnd.Ticks;
        }

        #endregion

        #region GetFirstDayOfWeek

        /// <summary>
        /// Returns the first day of the week that the specified date is in using the current culture. 
        /// </summary>
        /// <param name="date">Input date parameter</param>
        /// <returns>First day of a week of a given input date</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = date.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        #endregion

        #region GetLastDayOfWeek

        /// <summary>
        /// Returns the last day of the week that the specified date is in using the current culture. 
        /// </summary>
        /// <param name="date">Input date parameter</param>
        /// <returns>Last day of a week of a given input date</returns>
        public static DateTime GetLastDayOfWeek(this DateTime date)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = date.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek.AddDays(6); 
        }

        #endregion

        #region GetOrdinalSuffix

        /// <summary>
        /// Get the ordinal suffix for a given date
        /// </summary>
        /// <param name="datetime">Input date</param>
        /// <returns>Ordinal suffix of a given input date</returns>
        public static string GetOrdinalSuffix(this DateTime datetime)
        {
            int day = datetime.Day;

            if (day % 100 >= 11 && day % 100 <= 13)
                return String.Concat(day, "th");

            switch (day % 10)
            {
                case 1:
                    return String.Concat(day, "st");
                case 2:
                    return String.Concat(day, "nd");
                case 3:
                    return String.Concat(day, "rd");
                default:
                    return String.Concat(day, "th");
            }
        }

        #endregion

        #region IsWeekday

        public static bool IsWeekday(this DateTime date)
        {
            return new[] { DayOfWeek.Monday,
                           DayOfWeek.Tuesday,
                           DayOfWeek.Wednesday,
                           DayOfWeek.Thursday,
                           DayOfWeek.Friday
                         }.Contains(date.DayOfWeek);
        }

        #endregion

        #region IsWeekend

        public static bool IsWeekend(this DateTime date)
        {
            return new[] { DayOfWeek.Sunday, DayOfWeek.Saturday }.Contains(date.DayOfWeek);
        }

        #endregion

        #region NextWeekDay

        public static DateTime NextWeekDay(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                return dateTime.AddDays(2);
            return dateTime.AddDays(1);
        }

        #endregion

        #region PreviousWeekDay

        public static DateTime PreviousWeekDay(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                return dateTime.AddDays(-2);
            return dateTime.AddDays(-1);
        }

        #endregion

        #region Tomorrow

        public static DateTime Tomorrow(this DateTime datetime)
        {
            return datetime.AddDays(1);
        }

        #endregion

        #region Yesterday

        public static DateTime Yesterday(this DateTime datetime)
        {
            return datetime.AddDays(-1);
        }

        #endregion
    }
}
