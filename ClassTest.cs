using MySql.Data.MySqlClient;
using System;
using System.Data;
using NUnit.Framework;

namespace WpfApp1
{
    public class ClassTest
    {
        public static string ConnectionString = "server=localhost;userid=root;password=root;database=lu_tale";

        public static void main()
        {
            DatabaseHelper dbHelper = new DatabaseHelper(ConnectionString);
            string query = "SELECT * FROM t_users WHERE username = @username";
            MySqlParameter parameter = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = "admin" };

            try
            {
                DataTable result = dbHelper.ExecuteQuery(query, CommandType.Text, parameter);
                if (result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        // 假设你知道列名，比如 "id", "username", "email" 等  
                        // 使用这些列名来访问对应的字段数据  
                        int userId = Convert.ToInt32(row["uid"]); // 假设id列是整数类型  
                        string userName = row["username"].ToString();
                        string userEmail = row["email"].ToString();
                        Console.WriteLine($"ID: {userId}, Username: {userName}, Email: {userEmail}");
                    }
                }

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