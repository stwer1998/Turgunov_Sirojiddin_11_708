using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeInterval
{
    public static class StaticTimeIntervalMethods
    {
        /// <summary>
        /// Вернет как можно больше интервалов которые не пересекаются.
        /// В интервале начало берется самое маленькое дата, конец самое большое дата из колекции
        /// </summary>
        /// <param name="timeIntervals"></param>
        /// <returns></returns>
        public static List<TimeInterval> GetIntervalsWithOutInrersection(this ICollection<TimeInterval> timeIntervals)
        {/*На основе набора интервалов получать другой набор интервалов без пересечений 
            (например, на входе набор, состоящий из трёх интервалов: 10:00-12:00, 11:00-13:00 и 12:00-14:00. 
            На выходе будет следующий набор интервалов: 10:00-12:00, 12:00-13:00 и 13:00-14:00).

            Не очень понятно по тз что должен делать метод. Сделал по своему вернет
            как можно больше интервалов которые не пересекаются.
            начало интервалов берется самое маленькое дата из коллекции, конец самое большое дата из колекции.
            */
            var timespans = new List<TimeSpan>();
            foreach (var timeInterval in timeIntervals)
            {
                timespans.Add(timeInterval.EndOfInterval - timeInterval.StartOfInterval);
            }
            timespans.Sort();
            var result = new List<TimeInterval>();
            var start = timeIntervals.OrderBy(x => x.StartOfInterval).FirstOrDefault().StartOfInterval;
            var finish = timeIntervals.OrderByDescending(x => x.EndOfInterval).FirstOrDefault().EndOfInterval;
            var index = 0;
            while (start <= finish && index < timespans.Count)
            {
                result.Add(new TimeInterval(start, start + timespans[index]));
                start += timespans[index];
                index++;
            }

            return result;
        }
    }
}
