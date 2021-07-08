using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Common
{
    internal class DbHelper
    {
        private DbHelper()
        {
            
        }
       
        internal static int CheckDbNullInt(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return 0;
            else
                return (int)obj;
        }
        internal static string CheckDbNullString(object obj)
        {
            if (obj == DBNull.Value || obj == null)
                return string.Empty;
            else
                return (string)obj;
        }
      
    }
}
