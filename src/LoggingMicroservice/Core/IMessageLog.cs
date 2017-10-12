namespace LoggingMicroservice.Core
{
    /// <summary>
    /// Provides a message log to write messages to
    /// </summary>
    public interface IMessageLog
    {
        /// <summary>
        /// Write an entry to the message log
        /// </summary>
        /// <param name="message">The message to write</param>
        void WriteEntry(Message message);
    }
}
