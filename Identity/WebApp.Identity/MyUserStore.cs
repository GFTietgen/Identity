using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Identity
{
    public class MyUserStore : IUserStore<MyUser>, IUserPasswordStore<MyUser>
    {
        public async Task<IdentityResult> CreateAsync(MyUser user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync(
                    "INSERT INTO Users([Id], [UserName], [NormalizedUserName], [PasswordHash]) VALUES(@_id, @_userName, @_normalizedUserName, @_passwordHash)",
                    new
                    {
                        _id = user.Id,
                        _userName = user.UserName,
                        _normalizedUserName = user.NormalizedUserName,
                        _passwordHash = user.PasswordHash
                    }
                );

            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(MyUser user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync(
                    "DELETE FROM Users WHERE Id = @_id",
                    new
                    {
                        _id = user.Id
                    }
                );

            }

            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public static DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection("Data Source=LAPTOP-HKEORKLP;Initial Catalog=IdentityCurso;Integrated Security=True;Persist Security Info=False;");
            connection.Open();
            return connection;
        }

        public async Task<MyUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<MyUser>(
                    "SELECT * FROM Users WHERE Id=@_id",
                    new { _id = userId }
                );
            }
        }

        public async Task<MyUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<MyUser>(
                    "SELECT * FROM Users WHERE NormalizedUserName=@_name",
                    new { _name = normalizedUserName }
                );
            }
        }

        public Task<string> GetNormalizedUserNameAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(MyUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(MyUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(MyUser user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync(
                    "UPDATE Users SET [Id] = @_id, [UserName] = @_userName, [NormalizedUserName] = @_normalizedUserName, [PasswordHash] = @_passwordHash WHERE [Id] = @_id", 
                    new 
                    {
                        _id                 = user.Id, 
                        _userName           = user.UserName,
                        _normalizedUserName = user.NormalizedUserName,
                        _passwordHash       = user.PasswordHash
                    }
                );

            }

            return IdentityResult.Success;
        }

        public Task SetPasswordHashAsync(MyUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
    }
}
