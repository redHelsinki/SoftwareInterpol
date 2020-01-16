using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<File>> GetFiles() {
            try {
                var files = await _db.QueryAsync<File>("SELECT Id, Name, FactionId, DangerId, IsDeleted FROM Files WHERE IsDeleted = 0");
                return files.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<File> GetFile(int id) {
            try {
                var file = await _db.QueryFirstAsync<File>("SELECT Id, Name, FactionId, DangerId, IsDeleted FROM Files WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return file;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddFile(File file) {
            try {
                file.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Files ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Files VALUES (@id, @name, @factionId, @dangerId, 0)", new { id = file.Id, name = file.Name, factionId = file.FactionId, dangerId = file.DangerId });
                return file.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditFile(File file) {
            try {
                await _db.ExecuteAsync("UPDATE Files SET Name = @name, FactionId = @factionId, DangerId = @dangerId WHERE Id = @id AND IsDeleted != 0", new { id = file.Id, name = file.Name, factionId = file.FactionId, dangerId = file.DangerId });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteFile(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Files SET IsDeleted = 0 WHERE Id = @id", new { id = id });
            } catch (Exception) {
                throw;
            }
        }
    }
}
