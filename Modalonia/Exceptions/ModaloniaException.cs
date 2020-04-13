using System;

namespace Modalonia.Exceptions
{
    /// <summary>
    /// Represent modalonia exception.
    /// </summary>
    public class ModaloniaException : Exception
    {
        /// <summary>
        /// Throws new modalonia exception with empty exception message.
        /// </summary>
        public ModaloniaException()
        {
        }

        /// <summary>
        /// Throws new <see cref="ModaloniaException"/> with specified exception message.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ModaloniaException(string message) : base(message)
        {
        }
    }
}
