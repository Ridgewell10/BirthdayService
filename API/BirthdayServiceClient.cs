using Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API
{
    public class BirthdayServiceClient 
    {
        private readonly ILoggerManager _logger;
        private readonly string _baseAddress;

        public BirthdayServiceClient(string baseAddress, ILoggerManager logger)
        {
            _logger = logger;
            _baseAddress = baseAddress.EndsWith("/")
           ? baseAddress
           : $"{baseAddress}/";
        }

        public async Task<List<EmployeeDto>>  GetAllEmployees(params object[] parameters)
        {
            var baseAddress = (string)parameters[0];
            var employeesEndpoint = (string)parameters[1];

            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };

            var requestUrl = baseAddress + employeesEndpoint;
            var httpResponse = httpClient.GetAsync(requestUrl).Result;
            httpResponse.EnsureSuccessStatusCode();
            _logger.LogInfo($"Returned all employess from database.");
            var response =  await httpResponse.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<EmployeeDto>>(response);
            return result;
        }

        public async Task<int[]> GetDoNotSendEmail(params object[] parameters)
        {
            var baseAddress = (string)parameters[0];
            var doNotSendendpoint = (string)parameters[1];

            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };

            var requestUrl = baseAddress + doNotSendendpoint;
            var httpResponse = httpClient.GetAsync(requestUrl).Result;
            httpResponse.EnsureSuccessStatusCode();
            _logger.LogInfo($"Returned do not send employess from database.");
            var response = await httpResponse.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<int[]>(response);
            return result;
        }

        public void Dispose()
        {
        }
    }
}
