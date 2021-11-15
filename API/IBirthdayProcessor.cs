using System.Threading.Tasks;

namespace API
{
    public interface IBirthdayProcessor
    {
        Task<bool> GetEmployeeBirthday();
    }
}