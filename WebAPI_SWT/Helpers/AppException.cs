using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SWT.Helpers
{
    public class AppException : Exception
    {
        public AppException (): base(){}
        public AppException(string message) : base() { }

        public AppException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }


    }
}
