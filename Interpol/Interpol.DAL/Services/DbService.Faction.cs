using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Faction>> GetFactions() {
            try {
                var factions = await _db.QueryAsync<Faction>("SELECT Id, Name, IsDeleted FROM Factions WHERE IsDeleted = 0");
                return factions.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Faction> GetFaction(int id) {
            try {
                var faction = await _db.QueryFirstAsync<Faction>("SELECT Id, Name, IsDeleted FROM Factions WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return faction;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddFaction(Faction faction) {
            try {
                faction.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Factions ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Factions VALUES (@id, @name, 0)", new { id = faction.Id, name = faction.Name });
                return faction.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditFaction(Faction faction) {
            try {
                await _db.ExecuteAsync("UPDATE Factions SET Name = @name WHERE Id = @id AND IsDeleted != 0", new { id = faction.Id, name = faction.Name });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteFaction(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Factions SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
