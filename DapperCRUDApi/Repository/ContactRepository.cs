using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUDApi.Model;
using System.Data;

namespace DapperCRUDApi.Repository
{
    public class ContactRepository
    {
        private string connectionString;

        public ContactRepository()
        {
            connectionString = @"Server=WNB024547CPS;Database=crudzin;MultipleActiveResultSets=true;User Id=betinho;Password=enois12345!;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public async Task<int> Add(Contact entity)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sql = "INSERT INTO Contacts (Name, Nickname, Emoji) Values (@Name, @Nickname, @Emoji);";
                dbConnection.Open();
                var affectedRows = await dbConnection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sql = "DELETE FROM Contacts WHERE Id = @Id;";
                dbConnection.Open();
                var affectedRows = await dbConnection.ExecuteAsync(sql, new { Id = id });
                return affectedRows;
            }
        }

        public async Task<Contact> Get(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sql = "SELECT * FROM Contacts WHERE Id = @Id;";
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Contact>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sql = "SELECT * FROM Contacts;";
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Contact>(sql);
                return result;
            }
        }

        public async Task<int> Update(Contact entity)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sql = "UPDATE Contacts SET Name = @Name, Nickname = @Nickname, Emoji = @Emoji WHERE Id = @Id;";
                dbConnection.Open();
                var affectedRows = await dbConnection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
    }
}