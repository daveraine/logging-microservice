namespace LoggingMicroservice.Infrastructure
{
    using System.IO;
    using LoggingMicroservice.Config;
    using LoggingMicroservice.Core;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    /// <summary>
    /// A message log that writes to a text file
    /// </summary>
    public class TextFileMessageLog : IMessageLog
    {
        private readonly MessageLogOptions messageLogOptions;

        public TextFileMessageLog(IOptions<MessageLogOptions> messageLogOptionsAccessor)
        {
            messageLogOptions = messageLogOptionsAccessor.Value;
        }

        public void WriteEntry(Message message)
        {
            File.AppendAllText(messageLogOptions.FilePath, JsonConvert.SerializeObject(message));
        }
    }
}
