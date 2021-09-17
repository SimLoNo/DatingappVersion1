using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatingappVersion1
{
    class SqlReaderConversion
    {
        public int SelectCount(SqlDataReader output)
        {
            int returnCountFromDatabase = 0;
            while (output.Read())
            {
                returnCountFromDatabase = output.GetInt32(0);
            }
            return returnCountFromDatabase;
        }
    }
}
