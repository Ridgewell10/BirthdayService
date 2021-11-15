using System;

namespace API
{
    public class EmployeeDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTimeOffset dateOfBirth { get; set; }
        public DateTime employmentStartDate { get; set; }
        public DateTimeOffset? employmentEndDate { get; set; }
        public DateTime? lastNotification { get; set; }
    }
}
