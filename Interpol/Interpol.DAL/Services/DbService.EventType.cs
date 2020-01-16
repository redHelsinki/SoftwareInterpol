using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<EventType>> GetEventTypes() {
            try {
                var eventTypes = await _db.QueryAsync<EventType>("SELECT Id, Label, IsDeleted FROM EventTypes WHERE IsDeleted = 0");
                return eventTypes.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<EventType> GetEventType(int id) {
            try {
                var eventType = await _db.QueryFirstAsync<EventType>("SELECT Id, Label, IsDeleted FROM EventTypes WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return eventType;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddEventType(EventType eventType) {
            try {
                eventType.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM EventTypes ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO EventTypes VALUES (@id, @label, 0)", new { id = eventType.Id, label = eventType.Label });
                return eventType.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditEventType(EventType eventType) {
            try {
                await _db.ExecuteAsync("UPDATE EventTypes SET Label = @label WHERE Id = @id AND IsDeleted != 0", new { id = eventType.Id, label = eventType.Label });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteEventType(int id) {
            try {
                await _db.ExecuteAsync("UPDATE EventTypes SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
