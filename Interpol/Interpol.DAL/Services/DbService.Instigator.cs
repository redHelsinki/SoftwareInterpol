using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Instigator>> GetInstigators() {
            try {
                var instigators = await _db.QueryAsync<Instigator>("SELECT Id, FactionId, FileId, IsDeleted FROM Instigators WHERE IsDeleted = 0");
                return instigators.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Instigator> GetInstigator(int id) {
            try {
                var instigator = await _db.QueryFirstAsync<Instigator>("SELECT Id, FactionId, FileId, IsDeleted FROM Instigators WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return instigator;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddInstigator(Instigator instigator) {
            try {
                instigator.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Instigators ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Instigators VALUES (@id, @factionId, @fileId, 0)", new { id = instigator.Id, factionId = instigator.FactionId, fileId = instigator.FileId });
                return instigator.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditInstigator(Instigator instigator) {
            try {
                await _db.ExecuteAsync("UPDATE Instigators SET FactionId = @factionId, FileId = @fileId WHERE Id = @id AND IsDeleted != 0", new { id = instigator.Id, factionId = instigator.FactionId, fileId = instigator.FileId });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteInstigator(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Instigators SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
