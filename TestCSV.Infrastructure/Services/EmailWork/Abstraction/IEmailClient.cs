namespace TestCSV.Infrastructure.Services.EmailWork.Abstraction
{
    public interface IEmailClient
    {
        public MailOptions Options { get; set; }
        Task<string> SaveFileFromemailAsync(string path);
    }
}
