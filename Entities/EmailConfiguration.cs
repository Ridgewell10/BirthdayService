
namespace Entities
{
    public class EmailConfiguration 
    {
        private string FROM = "";
        private string SMTPSERVER = "";
        private int PORT = 0;
        private string USERNAME = "";
        private string PASSWORD = "";


        public string From { get => FROM; set => FROM = value; }
        public string SmtpServer { get => SMTPSERVER; set => SMTPSERVER = value; }
        public int Port { get => PORT; set => PORT = value; }
        public string UserName { get => USERNAME; set => USERNAME = value; }
        public string Password { get => PASSWORD; set => PASSWORD = value; }
    }
}
