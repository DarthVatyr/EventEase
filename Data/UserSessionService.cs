using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace EventEase.Data
{
    // Tracks the user's session and registered events, persisted in local storage
    public class UserSessionService
    {
        private const string StorageKey = "registeredEvents";
        private readonly ILocalStorageService _localStorage;
        private Dictionary<int, string> _registeredEvents = new();

        public UserSessionService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        // Load attendance from local storage (call this in OnInitializedAsync)
        public async Task LoadAsync()
        {
            var events = await _localStorage.GetItemAsync<Dictionary<int, string>>(StorageKey);
            _registeredEvents = events ?? new Dictionary<int, string>();
        }

        // Register for an event and persist
        public async Task RegisterEventAsync(int eventId, string registrantName)
        {
            _registeredEvents[eventId] = registrantName;
            await _localStorage.SetItemAsync(StorageKey, _registeredEvents);
        }

        // Check if the user is registered for an event
        public bool IsRegistered(int eventId) => _registeredEvents.ContainsKey(eventId);

        // Get all registered event IDs
        public IEnumerable<KeyValuePair<int, string>> GetRegisteredEvents() => _registeredEvents;
    }
}