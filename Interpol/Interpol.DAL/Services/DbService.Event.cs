using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Event>> GetEvents() {
            try {
                var event1s = await _db.QueryAsync<Event>("SELECT Id, Label, Value, IsDeleted FROM Events WHERE IsDeleted = 0");
                return event1s.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Event> GetEvent(int id) {
            try {
                var event1 = await _db.QueryFirstAsync<Event>("SELECT Id, Label, Value, IsDeleted FROM Events WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return event1;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddEvent(Event event1) {
            try {
                event1.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Events ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Events VALUES (@id, @label, @value, 0)", new { id = event1.Id, label = event1.Label, value = event1.Value });
                return event1.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditEvent(Event event1) {
            try {
                await _db.ExecuteAsync("UPDATE Events SET Label = @label, Value = @value WHERE Id = @id AND IsDeleted != 0", new { id = event1.Id, label = event1.Label, value = event1.Value });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteEvent(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Events SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
