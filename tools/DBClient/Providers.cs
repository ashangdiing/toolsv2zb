using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tools.DBClient
{
    
        public enum Providers
        {
            /// <summary>
            /// SqlServer 数据库
            /// </summary>
            SqlServer,
            /// <summary>
            /// OleDb数据库
            /// </summary>
            OleDb,
            /// <summary>
            /// Oracle 数据库
            /// </summary>
            Oracle,
            /// <summary>
            /// ODBC 数据源
            /// </summary>
            ODBC
        }
    
}
