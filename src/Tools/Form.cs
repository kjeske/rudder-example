using System;
using System.Collections.Generic;
using System.Linq;

namespace RudderExample.Tools
{
    public abstract class Form
    {
        private readonly List<Func<bool>> _rules = new List<Func<bool>>();

        public bool IsValid { get; private set; }

        public static string NotEmpty(string value) => string.IsNullOrWhiteSpace(value) ? "Field cannot be empty" : null;

        public static string CorrectEmail(string value) => !value.Contains("@") ? "Please enter a correct e-mail address" : null;

        public bool Validate()
        {
            IsValid = _rules.Aggregate(true, (lastValid, validator) => validator() && lastValid);
            return IsValid;
        }

        protected Field<T> Field<T>(T defaultValue, params Func<T, string>[] validators)
        {
            var field = new Field<T>
            {
                Value = defaultValue
            };

            _rules.Add(() =>
            {
                field.Error = GetFirstError(field.Value, validators);
                return field.Error == null;
            });

            return field;
        }

        private static string GetFirstError<T>(T value, Func<T, string>[] validators)
        {
            foreach (var validator in validators)
            {
                var error = validator(value);

                if (error != null)
                {
                    return error;
                }
            }

            return null;
        }
    }
}
