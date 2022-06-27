using System.Security.Cryptography;
using System.Text;

namespace API.Utils.Cryptography;

public static class PasswordHandler
{
    /// <summary>
    /// Produces a random value to be used when hashing a password. The random value is generated using a
    /// cryptographically secure random number generator.
    /// </summary>
    /// <param name="length">The number of bytes of the result.</param>
    /// <returns>The random value as a byte array.</returns>
    public static byte[] CreatePasswordSalt(int length) =>
        RandomNumberGenerator.GetBytes(length);

    /// <summary>
    /// Generates a hash value using the given password and salt.
    /// </summary>
    /// <param name="password">The password to be hashed.</param>
    /// <param name="salt">The random value combined with the password before hashing.</param>
    /// <returns>The created hash value.</returns>
    public static byte[] ComputePasswordHash(string password, byte[] salt)
    {
        byte[] algInput = GetHashAlgInput(password, salt);
        SHA512 sha512 = SHA512.Create();

        return sha512.ComputeHash(algInput);
    }

    /// <summary>
    /// Verifies that the provided password produces the same hash value as the stored password hash.
    /// </summary>
    /// <param name="password">The password to be verified.</param>
    /// <param name="salt">The random value used when initially creating the password hash.</param>
    /// <param name="passwordHash">The hash value of the true password.</param>
    /// <returns>A boolean value indicating whether the password was correct.</returns>
    public static bool VerifyPassword(string password, byte[] salt, byte[] passwordHash) =>
        ComputePasswordHash(password, salt).SequenceEqual(passwordHash);

    /// <summary>
    /// Combines the password and salt into one array of bytes.
    /// </summary>
    private static byte[] GetHashAlgInput(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return salt.Concat(passwordBytes).ToArray();
    }
}