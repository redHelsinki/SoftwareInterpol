using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Interpol.DAL.Models;

namespace Interpol.DAL.Services {
    public partial class DbService {
        public async Task<List<Group>> GetGroups() {
            try {
                var groups = await _db.QueryAsync<Group>("SELECT Id, Label, Description, IsDeleted FROM Groups WHERE IsDeleted = 0");
                return groups.AsList();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Group> GetGroup(int id) {
            try {
                var group = await _db.QueryFirstAsync<Group>("SELECT Id, Label, Description, Date, IsDeleted FROM Groups WHERE Id = @id AND IsDeleted = 0", new { id = id });
                return group;
            } catch (Exception) {
                return null;
            }
        }

        public async Task<int> AddGroup(Group group) {
            try {
                group.Id = await _db.QueryFirstAsync<int>("SELECT Id FROM Groups ORDER BY Id DESC");
                await _db.ExecuteAsync("INSERT INTO Groups VALUES (@id, @label, @description, @date, 0)", new { id = group.Id, label = group.Label, description = group.Description, date = group.Date });
                return group.Id;
            } catch (Exception) {
                return 0;
            }
        }

        public async Task EditGroup(Group group) {
            try {
                await _db.ExecuteAsync("UPDATE Groups SET Label = @label, Description = @description,  Date = @date, WHERE Id = @id AND IsDeleted != 0", new { id = group.Id, label = group.Label, description = group.Description, date = group.Date });
            } catch (Exception) {
                throw;
            }
        }

        public async Task DeleteGroup(int id) {
            try {
                await _db.ExecuteAsync("UPDATE Groups SET IsDeleted = 0 WHERE Id = @id", new { id = id});
            } catch (Exception) {
                throw;
            }
        }
    }
}
