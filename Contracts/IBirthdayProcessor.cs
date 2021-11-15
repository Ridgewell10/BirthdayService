using System.Threading.Tasks;

namespace Contracts
{
    public interface IBirthdayProcessor
    {
        Task<bool> GetEmployeeBirthday();
    }
}