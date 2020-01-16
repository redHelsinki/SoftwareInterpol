using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Severity>> GetSeverities() {
            try {
                var outcomes = await _db.QueryAsync<Severity>("SELECT Id, Label, IsDeleted FROM Severities WHERE IsDeleted = 0");
                return outcomes.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Severity> GetSeverity(int id) {
            try {
                var severity = await _db.QueryFirstAsync<Severity>("SELECT Id, Label, IsDeleted FROM Severities WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return severity;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddSeverity(Severity severity) {
            try {
                severity.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Severities ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Severities VALUES (@id, @label, 0)", new { id = severity.Id, label = severity.Label });
                return severity.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditSeverity(Severity severity) {
            try {
                await _db.ExecuteAsync("UPDATE Severities SET Label = @label WHERE Id = @id AND IsDeleted != 0", new { id = severity.Id, label = severity.Label });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteSeverity(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Severities SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
