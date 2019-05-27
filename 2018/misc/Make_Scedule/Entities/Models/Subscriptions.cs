using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Subscriptions
    {
        public int Id { get; set; }
        /// <summary>
        /// Название подписки
        /// </summary>
        public string SubscriptionsName { get; set; }
        /// <summary>
        /// стоимость подписки
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Конец подписки
        /// </summary>
        public DateTime End { get; set; }
    }
}
