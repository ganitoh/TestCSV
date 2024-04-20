namespace TestCSV.Infrastructure.Services.EmailWork
{
    public class MailOptions
    {
        public string? Host { get; set; }
        public string? EmailName { get; set; }
        public string? Password { get; set; }
        public int Port { get; set; }

        public MailOptions(string? host, string? emailName, string? password, string port)
        {
            Host = host;
            EmailName = emailName;
            Password = password;
            int portValue;

            if (int.TryParse(port, out portValue))
                Port = portValue;
            else
                Port = 0000;
        }
    }
}
