using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace tools.DBClient
{
    internal delegate T Execute<T>();
    class DBClient : IDisposable
    {



        #region 私有属性
        /// <summary>
        /// 数据库连接池
        /// </summary>
      //  private DBClient dbClient = DBClientSingleton.getDBInstance();

        
        /// <summary>
        /// 数据库连接池
        /// </summary>
        private DbProviderFactory objFactory = null;

        /// <summary>
        /// 指向Config文件中连接字符串的键
        /// </summary>
        private static  string  ConfigKey = "Default";

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private DbConnection con;

        /// <summary>
        /// 数据库操作对象
        /// </summary>
        private DbCommand cmd;

        /// <summary>
        /// 是否打开事物
        /// </summary>
        private bool isOpenTran = false;
        #endregion
        #region 共有属性
        /// <summary>
        /// 处理异常的类
        /// </summary>
       
        #endregion
        #region 共有属性
        /// <summary>
        /// 控制方法
        /// </summary>

        #endregion
        public void setTransaction(bool t){
            isOpenTran = t;
        }
        #region 共有属性
        /// <summary>
        /// 设置数据库
        /// </summary>

        #endregion
        public void setConfigString(string  s)
        {
            ConfigKey =s;
        }
        #region 共有属性
        /// <summary>
        /// 得到连接
        /// </summary>

        #endregion
        public DbConnection getDbConnection()
        {
            return con;
        }
        #region 共有属性
        /// <summary>
        /// 得到CMD
        /// </summary>

        #endregion
        public DbCommand getDbCommand()
        {
            return cmd;
        }
        public DBClient(string conString, Providers provider)
		{
			//Exception = new DboException();
            switch (provider)
			{
				case Providers.SqlServer: objFactory = SqlClientFactory.Instance; break;
				case Providers.ODBC: objFactory = OdbcFactory.Instance; break;
				case Providers.OleDb: objFactory = OleDbFactory.Instance; break;
				case Providers.Oracle: objFactory = OracleClientFactory.Instance; break;
			}
			if (objFactory == null) return;
			this.con = objFactory.CreateConnection();
			this.con.ConnectionString = conString;
			this.cmd = objFactory.CreateCommand();
			this.cmd.Connection = con;
		}
     public DBClient()
		{
			 
			switch (System.Configuration.ConfigurationManager.ConnectionStrings[ConfigKey].ConnectionString)
			{
				case "System.Data.SqlClient": objFactory = SqlClientFactory.Instance;
					break;
				case "System.Data.OleDb": objFactory = OleDbFactory.Instance;
					break;
				case "System.Data.OracleClient": objFactory = OracleClientFactory.Instance;
					break;
				case "System.Data.Odbc": objFactory = OdbcFactory.Instance;
					break;
			}
			if (objFactory == null) return;
			this.con = objFactory.CreateConnection();
			this.con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[ConfigKey].ConnectionString;
			this.cmd = objFactory.CreateCommand();
			this.cmd.Connection = con;
		}
 
     #region 添加参数
     /// <summary>
     /// 添加该参数。
     /// </summary>
     /// <param name="name">名字。</param>
     /// <param name="value">值。</param>
     /// <returns></returns>
     public DbParameter AddParameter(string name, object value)
     {
         DbParameter p = objFactory.CreateParameter();
         p.ParameterName = name;
         p.Value = value;
         cmd.Parameters.Add(p);
         return p;
     }
     /// <summary>
     /// 添加参数
     /// </summary>
     /// <param name="p">参数</param>
     /// <returns></returns>
     public DbParameter AddParameter(DbParameter p)
     {
         cmd.Parameters.Add(p);
         return p;
     }
     /// <summary>
     /// 添加输入参数
     /// </summary>
     /// <param name="name">名字</param>
     /// <param name="type">类型</param>
     /// <returns></returns>
     public DbParameter AddParameter(string name, DbType type)
     {
         DbParameter p = objFactory.CreateParameter();
         p.ParameterName = name;
         p.DbType = type;
         p.Direction = ParameterDirection.Output;
         cmd.Parameters.Add(p);
         return p;
     }
     /// <summary>
     /// 添加参数
     /// </summary>
     /// <param name="name">名字</param>
     /// <param name="type">类型</param>
     /// <param name="pd">是 输出还是 输入参数</param>
     /// <returns></returns>
     public DbParameter AddParameter(string name, DbType type, ParameterDirection pd)
     {
         DbParameter p = objFactory.CreateParameter();
         p.ParameterName = name;
         p.DbType = type;
         p.Direction = pd;
         cmd.Parameters.Add(p);
         return p;
     }
     /// <summary>
     /// 添加输出参数
     /// </summary>
     /// <param name="name">名字</param>
     /// <param name="type">类型</param>
     /// <param name="size">大小</param>
     /// <returns></returns>
     public DbParameter AddParameter(string name, DbType type, int size)
     {
         DbParameter p = objFactory.CreateParameter();
         p.ParameterName = name;
         p.DbType = type;
         p.Size = size;
         p.Direction = ParameterDirection.Output;
         cmd.Parameters.Add(p);
         return p;
     }
     /// <summary>
     /// 添加参数
     /// </summary>
     /// <param name="name">名字</param>
     /// <param name="type">类型</param>
     /// <param name="size">大小</param>
     /// <param name="pd">是 输出还是 输入参数</param>
     /// <returns></returns>
     public DbParameter AddParameter(string name, DbType type, int size, ParameterDirection pd)
     {
         DbParameter p = objFactory.CreateParameter();
         p.ParameterName = name;
         p.DbType = type;
         p.Size = size;
         p.Direction = pd;
         cmd.Parameters.Add(p);
         return p;
     }

   
     /// <summary>
     /// 添加参数
     /// </summary>
     /// <param name="name">名字</param>
     /// <param name="vaule">值</param>
     /// <param name="size">大小</param>
     /// <param name="pd">是 输出还是 输入参数</param>
     /// <returns></returns>
     public DbParameter AddParameter(string name, object value, int size, ParameterDirection pd)
     {
         DbParameter p = objFactory.CreateParameter();
         p.ParameterName = name;
         p.Value = value;
         p.Size = size;
         p.Direction = pd;
         cmd.Parameters.Add(p);
         return p;
     }
     /// <summary>
     /// 添加返回参数
     /// 名字为 @ReturnValue
     /// </summary>
     /// <returns></returns>
     public DbParameter AddParameter()
     {
         DbParameter p = objFactory.CreateParameter();
         p.ParameterName = "@ReturnValue";
         p.Direction = ParameterDirection.ReturnValue;
         cmd.Parameters.Add(p);
         return p;
     }
     public void ClearParamenter()
     {
         cmd.Parameters.Clear();
     }
     #endregion
     #region 执行方法
     #region 执行Sqlreader





     #endregion




     #endregion
     #region 控制方法
     /// <summary>
     /// 开始事务。
     /// </summary>
     public void BeginTransaction()
     {
         if (con.State == System.Data.ConnectionState.Closed)
         {
             con.Open();
         }
         cmd.Transaction = con.BeginTransaction();
         isOpenTran = true;
     }
     /// <summary>
     /// 提交事务。
     /// </summary>
     public void CommitTransaction()
     {
         if (isOpenTran)
         {
             cmd.Transaction.Commit();
             Close();
         }
         isOpenTran = false;
     }
     /// <summary>
     /// 回滚事务。
     /// </summary>
     public void RollbackTransaction()
     {
         cmd.Transaction.Rollback();
         Close();
         isOpenTran = false;
     }
     #endregion

     /// <summary>
     /// 当连接是打开的时候关闭连接
     /// </summary>
     public void Close()
     {
         if (con.State == ConnectionState.Open)
         {
             con.Close();
         }
     }
     #region IDisposable 成员
     public void Dispose()
     {
         cmd.Dispose();
         con.Dispose();
     }

     #endregion
    }
}
