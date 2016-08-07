using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    /// <summary>
    /// Customized Exception class
    /// </summary>
    public sealed class ISTException : Exception
    {

        public ISTException(string Message )
        {
            this.Message = Message;
        }
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// IST Exception Type
        /// </summary>
        public string ExceptionType { get { return "Project Name"; } }
    }
}
