using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class BirthdayProcessor : IBirthdayProcessor
    {
        private const string BASE_ADDRESS = "https://interview-assessment-1.realmdigital.co.za";
        private const string DO_NOT_SEND = "/do-not-send-birthday-wishes";
        private const string EMPLOYEES = "/employees";

        private readonly ILoggerManager _logger;
        private BirthdayServiceClient _client;
        private readonly SendEmailNotification _notification;


        public BirthdayProcessor(ILoggerManager logger)
        {
            _logger = logger;
            _client = new BirthdayServiceClient(BASE_ADDRESS, logger);
            _notification = new SendEmailNotification();
        }

        private async Task<List<EmployeeDto>> RemoveEmployees()
        {
            try
            {
                var dontSendList = await _client.GetDoNotSendEmail(BASE_ADDRESS, DO_NOT_SEND);
                var employeeList = await _client.GetAllEmployees(BASE_ADDRESS, EMPLOYEES);

                foreach (var id in dontSendList)
                {
                    var remove = employeeList.Where(a => a.id == id)
                                                .FirstOrDefault();

                    employeeList.Remove(remove);

                }
                return employeeList;
            }
            catch (Exception ex) { return null; }
        }


        public async Task<bool> GetEmployeeBirthday()
        {
            try
            {
                var list = await RemoveEmployees();

                var employeeList = list.Where(a => a.employmentStartDate < DateTime.Now && a.employmentEndDate == null).ToList();

                foreach (var employee in employeeList)
                {
                    if (employee.dateOfBirth.Month == DateTime.Now.Month && employee.dateOfBirth.Day == DateTime.Now.Day)
                    {
                        if (await _notification.SendNotificationAsync(employee) == false)
                        {
                            _logger.LogWarn("No birthday email sent to employees");
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
