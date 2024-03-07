using MySql.Data.MySqlClient;
using System;
using System.Data;
using NUnit.Framework;

namespace WpfApp1
{
    [TestFixture]
    public class ClassSql
    {
        private const string ConnectionString = "server=localhost;userid=root;password=root;database=lu_tale";
        private DatabaseHelper _dbHelper;

        [Test]
        public void TestExecuteQuery()
        {
            // 执行查询测试  
            _dbHelper = new DatabaseHelper(ConnectionString);
            DatabaseHelper dbHelper = new DatabaseHelper(ConnectionString);
            string query = "SELECT COUNT(*) FROM t_users WHERE username = @username";
            MySqlParameter parameter = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = "admin" };

            try
            {
                DataTable result = dbHelper.ExecuteQuery(query, CommandType.Text, parameter);
                // 处理查询结果（比如打印到控制台）  
                Console.WriteLine(result.Rows[0][0]); // 假设查询结果至少有一行一列  
            }
            catch (Exception ex)
            {
                // 处理异常（比如打印错误信息到控制台）  
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}