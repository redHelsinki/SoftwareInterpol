using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Outcome>> GetOutcomes() {
            try {
                var outcomes = await _db.QueryAsync<Outcome>("SELECT Id, Label, IsDeleted FROM Outcomes WHERE IsDeleted = 0");
                return outcomes.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Outcome> GetOutcome(int id) {
            try {
                var outcome = await _db.QueryFirstAsync<Outcome>("SELECT Id, Label, IsDeleted FROM Outcomes WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return outcome;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddOutcome(Outcome outcome) {
            try {
                outcome.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Outcomes ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Outcomes VALUES (@id, @label, 0)", new { id = outcome.Id, label = outcome.Label });
                return outcome.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditOutcome(Outcome outcome) {
            try {
                await _db.ExecuteAsync("UPDATE Outcomes SET Label = @label WHERE Id = @id AND IsDeleted != 0", new { id = outcome.Id, label = outcome.Label });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteOutcome(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Outcomes SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
