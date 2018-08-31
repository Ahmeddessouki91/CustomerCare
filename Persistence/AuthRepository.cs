using System;
using System.Threading.Tasks;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Persistence
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CuCareDbContext _context;
        public AuthRepository(CuCareDbContext context) { this._context = context; }
        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] PasswordHash, PasswordSalt;
            CreatePasswordHash(password, out PasswordHash, out PasswordSalt);
            user.PasswordSalt = PasswordSalt;
            user.PasswordHash = PasswordHash;

            await _context.Users.AddAsync(user);
            return user;
        }
        public async Task<bool> UserExist(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email) != null;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }

    }
}