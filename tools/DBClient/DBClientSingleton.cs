using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tools.DBClient
{
    public class DBClientSingleton
    {
        private   static DBClient uniqueInstance; 
         public static DBClient getDBInstance() {    
    if(uniqueInstance == null) {  
          if(uniqueInstance == null)   
        uniqueInstance = new DBClient();   
    }   
         return uniqueInstance;   
    }   
    }
}
