using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data .SqlClient;

    public static class CodeToolsHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
       public static string ConnStr = "";

       public static  SqlConnection OpenCn()
       {
           SqlConnection conn = new SqlConnection();
           if(conn.State==ConnectionState.Open||conn.State==ConnectionState.Broken)
           {               
               conn.Close();
           }
           return new SqlConnection(ConnStr);
       }

       //返回影响的行数
       public static int ExecuteNonQuery(CommandType commandType,string cmdText,List<SqlParameter> spr)
       {
           int i = 0;
           using (SqlConnection conn = OpenCn())
           {
               try
               {
                   conn.Open();
                   SqlCommand cmd = new SqlCommand(cmdText,conn);
                   cmd.Parameters.Clear();
                   cmd.CommandType = commandType;
                   if(spr!=null)
                   {
                       foreach (SqlParameter s in spr)
                       {
                           cmd.Parameters.Add(s);
                       };
                   }
                   i=cmd.ExecuteNonQuery(); 
                   conn.Close();
                   cmd.Parameters.Clear();
               }
               catch
               {
                   conn.Close();
               }              
               return i;    
           }                
       }

       //带参数的存储过程
       public static int ExecuteNonQueryPro(string cmdText,List<SqlParameter> spr)
       {
           return ExecuteNonQuery(CommandType.StoredProcedure, cmdText, spr);
       }

       //不带参数的存储过程
       public static int ExecuteNonQueryPro(string cmdText)
       {
           return ExecuteNonQueryPro(cmdText, null);
       }

       //带参数的操作语句
       public static int ExecuteNonQuery(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteNonQuery(CommandType.Text, cmdText, spr);
       }

       //不带参数的操作语句
       public static int ExecuteNonQuery(string cmdText)
       {
           return ExecuteNonQuery(cmdText, null);
       }

       //获取数据
       public static DataSet GetDataSet(CommandType cmdType,string cmdText,List<SqlParameter> spr)
       {
           DataSet ds = new DataSet();
           using (SqlConnection conn = OpenCn())
           {
               try
               {
                   SqlDataAdapter oda = new SqlDataAdapter(cmdText,conn);
                   oda.SelectCommand.CommandType = cmdType;
                   if(spr!=null)
                   {
                       foreach(SqlParameter s in spr)
                       {
                           oda.SelectCommand.Parameters.Add(s);
                       }                       
                   }                   
                   oda.Fill(ds);
                   oda.SelectCommand.Parameters.Clear();
                   conn.Close();
               }
               catch
               {
                   conn.Close();
               }
               return ds;
           } 
       }

       //带参数的存储过程
       public static DataSet GetDataSetPro(string cmdText, List<SqlParameter> spr)
       {
          return  GetDataSet(CommandType.StoredProcedure,cmdText,spr);
       }
       
       //不带参数的存储过程
       public static DataSet GetDataSetPro(string cmdText)
       {
          return  GetDataSetPro(cmdText,null);
       }

       //带参数的文本查询
       public static DataSet GetDataSet(string cmdText, List<SqlParameter> spr)
       {
          return GetDataSet(CommandType.Text, cmdText, spr);
       }

       //不带参数的文本查询
       public static DataSet GetDataSet(string cmdText)
       {
           return GetDataSet(CommandType.Text, cmdText, null);
       }

       //数据阅读器
       public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, List<SqlParameter> spr)
       {
           SqlConnection conn = OpenCn();
           conn.Open();
           SqlCommand cmd = new SqlCommand(cmdText,conn);
           if(spr!=null)
           {
               foreach (SqlParameter s in spr)
               {
                   cmd.Parameters.Add(s);
               } 
           }
           SqlDataReader dr=cmd.ExecuteReader(CommandBehavior.CloseConnection);
           cmd.Parameters.Clear();
           return dr;
       }

       //带参数的存储过程
       public static SqlDataReader ExecuteReaderPro(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteReader(CommandType.StoredProcedure, cmdText, spr);
       }

       //不带带参数的存储过程
       public static SqlDataReader ExecuteReaderPro(string cmdText)
       {
           return ExecuteReaderPro(cmdText,null);
       }


       //带参数的文本
       public static SqlDataReader ExecuteReader(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteReader(CommandType.Text, cmdText, spr);
       }

       //不带参数的文本
       public static SqlDataReader ExecuteReader(string cmdText)
       {
           return ExecuteReader(cmdText, null);
       }
       
       //返回第一行第一列的值
       public static string ExecuteScalar(CommandType cmdType, string cmdText, List<SqlParameter> spr)
       {
           string strS="";
           using (SqlConnection conn = OpenCn())
           {
               try
               {  
                   conn.Open();
                   SqlCommand cmd = new SqlCommand(cmdText, conn);
                   if (spr != null)
                   {
                       foreach (SqlParameter s in spr)
                       {
                           cmd.Parameters.Add(s);
                       } 
                   }                   
                   if (cmd.ExecuteScalar()!=null)
                   {
                       strS = cmd.ExecuteScalar().ToString();
                   }
                   conn.Close();
                   cmd.Parameters.Clear();
               }
               catch
               {
                   conn.Close();
               } 
               return strS;
           }
       }

       //带参数的存储过程
       public static string ExecuteScalarPro(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteScalar(CommandType.StoredProcedure, cmdText, spr);
       }

       //不带参数的存储过程
       public static string ExecuteScalarPro(string cmdText)
       {
           return ExecuteScalarPro(cmdText, null);
       }

       //带参数的文本
       public static string ExecuteScalar(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteScalar(CommandType.Text, cmdText, spr);
       }

       //不带参数的文本
       public static string ExecuteScalar(string cmdText)
       {
           return ExecuteScalar(cmdText, null);
       }
    }
