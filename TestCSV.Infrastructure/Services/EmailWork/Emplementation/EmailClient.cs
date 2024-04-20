using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using TestCSV.Infrastructure.Services.EmailWork.Abstraction;

namespace TestCSV.Infrastructure.Services.EmailWork.Emplementation
{
    internal class EmailClient : IEmailClient
    {
        public MailOptions Options { get; set; } = null!;

        public EmailClient(MailOptions options)
        {
            Options = options;
        }

        public async Task<string> SaveFileFromemailAsync(string path)
        {
            using(var client = new ImapClient())
            {
                await client.ConnectAsync(Options.Host, Options.Port);
                await client.AuthenticateAsync(Options.EmailName, Options.Password);
                await client.Inbox.OpenAsync(FolderAccess.ReadOnly);

                var countMessage = client.Inbox.Count;

                for (int i = Math.Max(0,countMessage - 1); i < countMessage; i++)
                {
                    var message = await client.Inbox.GetMessageAsync(i);

                    foreach (var attachment in message.Attachments)
                    {
                        var part = attachment as MimePart ?? throw new Exception();
                        if (part.ContentType.MimeType == ".csv" ||
                             part.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                        {
                             return SaveFile(part, path);
                        }
                    }
                }

                throw new MessageNotFoundException("сообщения не найдены");
            }
        }

        private string SaveFile(MimePart attachment, string folderName)
        {
            Directory.CreateDirectory(folderName);
            var fileName = Path.Combine(folderName, attachment.FileName);
            using var stream = File.Create(fileName);
            attachment.Content.DecodeTo(stream);
            return fileName;
        }
    }
}
