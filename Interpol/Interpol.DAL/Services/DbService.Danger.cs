using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Danger>> GetDangers() {
            try {
                var dangers = await _db.QueryAsync<Danger>("SELECT Id, Label, Value, IsDeleted FROM Dangers WHERE IsDeleted = 0");
                return dangers.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Danger> GetDanger(int id) {
            try {
                var danger = await _db.QueryFirstAsync<Danger>("SELECT Id, Label, Value, IsDeleted FROM Dangers WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return danger;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddDanger(Danger danger) {
            try {
                danger.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Dangers ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Dangers VALUES (@id, @label, @value, 0)", new { id = danger.Id, label = danger.Label, value = danger.Value });
                return danger.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditDanger(Danger danger) {
            try {
                await _db.ExecuteAsync("UPDATE Dangers SET Label = @label, Value = @value WHERE Id = @id AND IsDeleted != 0", new { id = danger.Id, label = danger.Label, value = danger.Value });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteDanger(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Dangers SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
