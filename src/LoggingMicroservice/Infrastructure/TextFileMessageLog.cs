namespace LoggingMicroservice.Infrastructure
{
    using System;
    using System.IO;
    using LoggingMicroservice.Config;
    using LoggingMicroservice.Core;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    /// <summary>
    /// A message log that writes to a text file
    /// </summary>
    public class TextFileMessageLog : IMessageLog
    {
        private readonly string messageLogPath;

        public TextFileMessageLog(
            IOptions<MessageLogOptions> messageLogOptionsAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            messageLogPath = Path.Combine(hostingEnvironment.WebRootPath, messageLogOptionsAccessor.Value.FilePath);
        }

        public void WriteEntry(Message message)
        {
            File.AppendAllText(messageLogPath, JsonConvert.SerializeObject(message) + Environment.NewLine);
        }
    }
}
