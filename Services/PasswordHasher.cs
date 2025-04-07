using Microsoft.AspNetCore.Identity;
using moontest1.Models;

namespace moontest1.Services
{
    public class PasswordHasher // encapsulates password hashing and verification logic.
    {
        // Creates an instance of the built-in PasswordHasher using your User model as the type.
        private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();

        // passes a plain text password (string) and returns the hashed result (string).
        public string HashPassword(User user, string password)
        {
            // user isn't needed to be passed but it allows for use based salting or 
                                          // time stamping abilities based on users 
            return _hasher.HashPassword(user, password);
        }
        // reverse opperation of hashing the password. 
        public bool VerifyPassword(User user, string password)
        {
            // check if the hash of the input password matches the stored hash.
            // returns true if they match, false otherwise.
            return _hasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
        }
    }
}

