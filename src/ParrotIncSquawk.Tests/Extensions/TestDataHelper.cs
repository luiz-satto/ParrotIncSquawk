using ParrotIncSquawk.Infrastructure.Models;
using System.Text;

namespace ParrotIncSquawk.Tests.Extensions
{
    public class TestDataHelper
    {
        public static IEnumerable<Squawk> GetFakeSquawkList()
        {
            return
            [
                new() {
                    Text = "Test 1",
                    SquawkId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    SquawkDate = DateTime.UtcNow,
                },
                new() {
                    Text = "Test 2",
                    SquawkId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    SquawkDate = DateTime.UtcNow,
                }
            ];
        }

        public static string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new(length);
            Random random = new();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
