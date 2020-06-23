using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class CustoomException: Exception
    {

        public CustoomException(string message) : base(message)
        {

        }

    }
}
