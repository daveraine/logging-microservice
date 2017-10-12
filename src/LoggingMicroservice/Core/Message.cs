namespace LoggingMicroservice.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter an Id greater than 0")]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [StringLength(255, MinimumLength = 1, ErrorMessage = "Please enter between 1 and 255 characters of text")]
        [Required(ErrorMessage = "Please enter text")]
        public string Text { get; set; }
    }
}
