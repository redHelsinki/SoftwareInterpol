using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Locality>> GetLocalities() {
            try {
                var localities = await _db.QueryAsync<Locality>("SELECT Id, Name, CoordX, CoordY, Nation, Risk, IsDeleted FROM Localities WHERE IsDeleted = 0");
                return localities.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Locality> GetLocality(int id) {
            try {
                var locality = await _db.QueryFirstAsync<Locality>("SELECT Id, Name, CoordX, CoordY, Nation, Risk, IsDeleted FROM Localities WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return locality;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddLocality(Locality locality) {
            try {
                locality.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Localities ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Localities VALUES (@id, @name, @coordX, @coordY, @nation, @risk, 0)", new { id = locality.Id, name = locality.Name , coordX = locality.CoordX, coordY = locality.CoordY, nation = locality.Nation, risk = locality.Risk});
                return locality.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditLocality(Locality locality) {
            try {
                await _db.ExecuteAsync("UPDATE Localities SET Name = @name WHERE Id = @id AND IsDeleted != 0", new { id = locality.Id, name = locality.Name, coordX = locality.CoordX, coordY = locality.CoordY, nation = locality.Nation, risk = locality.Risk });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteLocality(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Localities SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
