using System;
using System.Collections.Generic;
using System.Linq;

namespace EventEase.Data
{
    // Provides event data to the app
    public class EventService
    {
        private readonly List<Event> _events;

        public EventService()
        {
            _events = new List<Event>();
            for (int i = 1; i <= 1000; i++)
            {
                _events.Add(new Event
                {
                    Id = i,
                    Name = $"Event {i}",
                    Date = DateTime.Now.AddDays(i),
                    Location = $"Location {i}"
                });
            }
        }

        public List<Event> GetEvents() => _events;

        public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);
    }
}