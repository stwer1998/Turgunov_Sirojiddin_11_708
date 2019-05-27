using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Entities
{
    public interface IEventRepository:ICanCheck
    {
        /// <summary>
        /// Добавляет новое мероприятие данному пользователю
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user_login"></param>
        void AddEvent(string organizer_login,Event model);

        /// <summary>
        /// Добавит фотографию
        /// </summary>
        /// <param name="organizer_login"></param>
        /// <param name="id_event"></param>
        /// <param name="image"></param>
        void AddImageForEvent(string organizer_login, int id_event, Image image);
        void AddImageForEvent(string organizer_login, int id_event,int id_participant, Image image);
        
        /// <summary>
        /// Возвращает лист мероприятии пользователя
        /// </summary>
        /// <param name="user_login"></param>
        /// <returns></returns>
        List<Event> GetEventOrganization(string organizer_login);

        /// <summary>
        /// Возвращает все мероприятии которые еще не прошли
        /// </summary>
        /// <returns></returns>
        List<Event> GetEvents();

        /// <summary>
        /// Возвращает мероприятие по id
        /// </summary>
        /// <param name="id_event"></param>
        /// <returns></returns>
        Event GetEvent(string organizer_login,int id_event, params Expression<Func<Event, object>>[] includes);
        Event GetEvent(string organizer_login,int id_event);
        Event GetEvent(int id_event);

        /// <summary>
        /// Удаляет мероприятие
        /// </summary>
        /// <param name="id_event"></param>
        void DeleteEvent(string organizer_login,int id_event);

        /// <summary>
        /// Изменяет мероприятие или что-то в меромриятие зависет от параметров
        /// </summary>
        /// <param name="event"></param>
        void EditEvent(string organizer_login, int id_event, object model);

        /// <summary>
        /// Добавит передмнное в мероприятие
        /// </summary>
        /// <param name="organizer_login"></param>
        /// <param name="id_event"></param>
        /// <param name="participant"></param>
        /// <param name="seat"></param>
        void AddToEvent(string organizer_login, int id_event, object model);

        /// <summary>
        /// Удаляет из мероприятие что паредали
        /// </summary>
        /// <param name="organizer_login"></param>
        /// <param name="id_event"></param>
        /// <param name="participant"></param>
        /// <param name="seat"></param>
        void RemoveFromEvent(string organizer_login, int id_event, string parametr, int id);
        
        /// <summary>
        /// Проверяет является ли пользователь собственником мероприятия
        /// </summary>
        /// <param name="organizer_login"></param>
        /// <param name="id_event"></param>
        /// <returns></returns>
        bool CheckEvent(string organizer_login, int id_event);

        /// <summary>
        /// Добавит зрителя
        /// </summary>
        /// <param name="id_event"></param>
        /// <param name="viewer"></param>
        void AddViewer(int id_event, Viewer viewer);
    }
}
