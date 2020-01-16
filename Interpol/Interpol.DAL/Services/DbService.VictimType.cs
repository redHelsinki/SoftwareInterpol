using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<VictimType>> GetVictimTypes() {
            try {
                var victimTypes = await _db.QueryAsync<VictimType>("SELECT Id, Label, IsDeleted FROM VictimTypes WHERE IsDeleted = 0");
                return victimTypes.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<VictimType> GetVictimType(int id) {
            try {
                var victimType = await _db.QueryFirstAsync<VictimType>("SELECT Id, Label, IsDeleted FROM VictimTypes WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return victimType;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddVictimType(VictimType victimType) {
            try {
                victimType.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM VictimTypes ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO VictimTypes VALUES (@id, @label, 0)", new { id = victimType.Id, label = victimType.Label });
                return victimType.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditVictimType(VictimType victimType) {
            try {
                await _db.ExecuteAsync("UPDATE VictimTypes SET Label = @label WHERE Id = @id AND IsDeleted != 0", new { id = victimType.Id, label = victimType.Label });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteVictimType(int id) {
            try {
                await _db.ExecuteAsync("UPDATE VictimTypes SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
