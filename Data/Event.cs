using System;

namespace EventEase.Data
{
    // Represents an event in the EventEase application
    public class Event
    {
        // Unique identifier for the event
        public int Id { get; set; }

        // Name or title of the event
        public string? Name { get; set; }

        // Date and time when the event occurs
        public DateTime Date { get; set; }

        // Location where the event takes place
        public string? Location { get; set; }
    }
}