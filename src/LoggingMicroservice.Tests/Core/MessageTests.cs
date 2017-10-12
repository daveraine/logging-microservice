namespace LoggingMicroservice.Tests.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using LoggingMicroservice.Core;
    using Xunit;

    public class MessageTests
    {
        [Fact]
        public void IdIsZero_IsInvalid()
        {
            var message = new Message
            {
                Id = 0,
                Date = new DateTime(2017, 1, 1),
                Text = "text"
            };

            var result = Validate(message);

            Assert.Collection(result, r => r.MemberNames.Contains("Id"));
        }

        [Fact]
        public void IdIsNegative_IsInvalid()
        {
            var message = new Message
            {
                Id = -1,
                Date = new DateTime(2017, 1, 1),
                Text = "text"
            };

            var result = Validate(message);

            Assert.Collection(result, r => r.MemberNames.Contains("Id"));
        }

        [Fact]
        public void IdIsPositive_IsValid()
        {
            var message = new Message
            {
                Id = 1,
                Date = new DateTime(2017, 1, 1),
                Text = "text"
            };

            var result = Validate(message);

            Assert.Empty(result);
        }

        [Fact]
        public void TextIsNull_IsInvalid()
        {
            var message = new Message
            {
                Id = 1,
                Date = new DateTime(2017, 1, 1),
                Text = null
            };

            var result = Validate(message);

            Assert.Collection(result, r => r.MemberNames.Contains("Text"));
        }

        [Fact]
        public void TextIsEmpty_IsInvalid()
        {
            var message = new Message
            {
                Id = 1,
                Date = new DateTime(2017, 1, 1),
                Text = string.Empty
            };

            var result = Validate(message);

            Assert.Collection(result, r => r.MemberNames.Contains("Text"));
        }

        [Fact]
        public void TextIsLength256_IsInvalid()
        {
            var message = new Message
            {
                Id = 1,
                Date = new DateTime(2017, 1, 1),
                Text = new string('x', 256)
            };

            var result = Validate(message);

            Assert.Collection(result, r => r.MemberNames.Contains("Text"));
        }

        [Fact]
        public void TextIsLength1_IsValid()
        {
            var message = new Message
            {
                Id = 1,
                Date = new DateTime(2017, 1, 1),
                Text = "1"
            };

            var result = Validate(message);

            Assert.Empty(result);
        }

        [Fact]
        public void TextIsLength255_IsValid()
        {
            var message = new Message
            {
                Id = 1,
                Date = new DateTime(2017, 1, 1),
                Text = new string('x', 255)
            };

            var result = Validate(message);

            Assert.Empty(result);
        }

        private static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject)
            {
                (model as IValidatableObject).Validate(validationContext);
            }

            return results;
        }
    }
}
