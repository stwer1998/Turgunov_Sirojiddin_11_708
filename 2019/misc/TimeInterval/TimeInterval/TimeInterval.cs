using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TimeInterval
{
    public class TimeInterval
    {
        /// <summary>
        /// Начало интервала
        /// </summary>
        public DateTime StartOfInterval { get; private set; }
        /// <summary>
        /// Конец интервала
        /// </summary>
        public DateTime EndOfInterval { get; private set; }
        /// <summary>
        /// Передается начало и конец интервала
        /// </summary>
        /// <param name="StartOfInterval">Начало интервала</param>
        /// <param name="EndOfInterval">Конец интервала</param>
        public TimeInterval(DateTime StartOfInterval, DateTime EndOfInterval)
        {//Получаем сразу начало и конец интервала создавать конструктор с другими параметрами не вижу смысл
            //Если начало позже концы то сразу меняем местами это логично и хорошо для сравнивание
            if (StartOfInterval == EndOfInterval)
            {
                throw new ArgumentException("Начало и конец не может быть одинаковым");
            }
            else if (StartOfInterval < EndOfInterval)
            {
                this.StartOfInterval = StartOfInterval;
                this.EndOfInterval = EndOfInterval;
            }
            else
            {
                this.StartOfInterval = EndOfInterval;
                this.EndOfInterval = StartOfInterval;
            }
        }

        /// <summary>
        /// Сравнение интервалов. Интервалы равны если начало и конец совпадает
        /// </summary>
        /// <param name="timeInterval"></param>
        /// <returns></returns>
        public bool Equals(TimeInterval timeInterval)
        {
            return timeInterval.StartOfInterval == StartOfInterval && timeInterval.EndOfInterval == EndOfInterval;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.ToString()==((TimeInterval)obj).ToString(); 
        }

        public override string ToString()
        {
            return "Start : " + this.StartOfInterval + " end : " + this.EndOfInterval;
        }

        /// <summary>
        /// Проверка на пересечение интераплов
        /// </summary>
        /// <param name="timeInterval"></param>
        /// <returns></returns>
        public bool Intersection(TimeInterval timeInterval)
        {
            if (this.StartOfInterval>=timeInterval.EndOfInterval||this.EndOfInterval<=timeInterval.StartOfInterval)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Проверяет пересечение если есть то вернет время пересечение
        /// </summary>
        /// <param name="timeInterval"></param>
        /// <returns></returns>
        public TimeSpan IntersectionTime(TimeInterval timeInterval)
        {
            if (this.Intersection(timeInterval))
            {
                if (this.StartOfInterval < timeInterval.StartOfInterval)
                {
                    if (this.EndOfInterval > timeInterval.EndOfInterval)
                    {
                        return timeInterval.EndOfInterval - timeInterval.StartOfInterval;
                    }
                    else
                    {
                        return this.EndOfInterval - timeInterval.StartOfInterval;
                    }
                }
                else
                    if (this.EndOfInterval < timeInterval.EndOfInterval)
                {
                    return timeInterval.StartOfInterval - this.EndOfInterval;
                }
                else
                {
                    return timeInterval.StartOfInterval - timeInterval.EndOfInterval;
                }
            }
            else throw new ArgumentException("Интервалы не пересекаются");
        }

        /// <summary>
        /// Проверяет пересечение если есть то вернет интервал на пересечении
        /// </summary>
        /// <param name="timeInterval"></param>
        /// <returns></returns>
        public TimeInterval IntersectionInterval(TimeInterval timeInterval)
        {
            if (this.Intersection(timeInterval))
            {
                if (this.StartOfInterval >= timeInterval.StartOfInterval)
                {
                    if (this.EndOfInterval <= timeInterval.EndOfInterval)
                    {
                        return this;
                    }
                    else
                    {
                        return new TimeInterval(this.StartOfInterval, timeInterval.EndOfInterval);
                    }
                }
                else
                    if (timeInterval.EndOfInterval <= this.EndOfInterval)
                {
                    return timeInterval;
                }
                else
                {
                    return new TimeInterval(timeInterval.StartOfInterval, this.EndOfInterval);
                }
            }
            else throw new ArgumentException("Интервалы не пересекаются");
        }

        /// <summary>
        /// интервал, который начался раньше, меньше интервала, который начался позже; если интервалы начались одновременно,
        /// меньшим считается более короткий интервал
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator >(TimeInterval t1, TimeInterval t2)
        {
            if (t2.StartOfInterval > t1.StartOfInterval)
            {
                return false;
            }
            else if (t1.StartOfInterval == t2.StartOfInterval)
            {
                return t1.EndOfInterval > t2.EndOfInterval;
            }
            else return true;
        }

        /// <summary>
        /// интервал, который начался раньше, меньше интервала, который начался позже; если интервалы начались одновременно,
        /// меньшим считается более короткий интервал 
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator <(TimeInterval t1, TimeInterval t2)
        {
            return !(t1 > t2);
        }

        /// <summary>
        /// Сравнение интервалов. Интервалы равны если начало и конец совпадает
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator ==(TimeInterval t1, TimeInterval t2)
        {
            return t1.Equals(t2);
        }

        /// <summary>
        /// Сравнение интервалов. Интервалы равны если начало и конец совпадает
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator !=(TimeInterval t1, TimeInterval t2)
        {
            return !(t1.Equals(t1));
        }


    }
}
