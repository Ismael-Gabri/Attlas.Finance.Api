using Attlas.Domain.Commands.Output;
using Attlas.Domain.Entities;
using Attlas.Domain.Infra.Contexts;
using Attlas.Domain.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attlas.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AttlasFinanceContext _context;
        public UserRepository(AttlasFinanceContext context)
        {
            _context = context;
        }
        public bool CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int userId)
        {
            var query = @"
        DELETE FROM [users]
        WHERE [id] = @UserId";

            using (var connection = _context.GetConnection())
            {
                var affectedRows = connection.Execute(query, new { UserId = userId });
            }
        }

        public IEnumerable<GetUserCommandResult> GetAllUsers()
        {
            var query = @"
    SELECT TOP (1000) 
        [id],
        [first_name],
        [last_name],
        [email],
        [user_name],
        [password_hash],
        [profile_image],
        [role],
        [entry_date],
        [update_date],
        [last_login],
        [pix_type],
        [pix_key]
    FROM [users]";

            using (var connection = _context.GetConnection())
            {
                var users = connection.Query<GetUserCommandResult>(query);
                return users;
            }
        }

        public GetUserCommandResult GetUserById(int userId)
        {
            var query = @"
        SELECT 
            [id],
            [first_name],
            [last_name],
            [email],
            [user_name],
            [password_hash],
            [profile_image],
            [role],
            [entry_date],
            [update_date],
            [last_login],
            [pix_type],
            [pix_key]
        FROM [users]
        WHERE [id] = @UserId";

            using (var connection = _context.GetConnection())
            {
                var user = connection.QueryFirstOrDefault<GetUserCommandResult>(query, new { UserId = userId });
                return user;
            }
        }


        public void Save(User user)
        {
            using (var connection = _context.GetConnection())
            {
                var query = @"
            INSERT INTO
                users 
                       (first_name, last_name, email, user_name, password_hash, profile_image, role, entry_date, update_date, last_login, pix_type, pix_key)
             VALUES 
                       (@FirstName, @LastName, @Email, @UserName, @PasswordHash, @ProfileImage, @Role, @EntryDate, @UpdateDate, @LastLogin, @PixType, @PixKey);
        ";
                connection.Execute(query, new
                {
                    FirstName = user.Name.FirstName,
                    LastName = user.Name.LastName,
                    Email = user.Email.Address,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                    ProfileImage = user.ProfileImage,
                    Role = user.Role,
                    EntryDate = user.EntryDate,
                    UpdateDate = user.UpdateDate,
                    LastLogin = user.LastLogin,
                    PixType = user.PixType,
                    PixKey = user.PixKey
                });
            }
        }
    }
}
