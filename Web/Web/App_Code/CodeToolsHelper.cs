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
        /// �����ַ���
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

       //����Ӱ�������
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

       //�������Ĵ洢����
       public static int ExecuteNonQueryPro(string cmdText,List<SqlParameter> spr)
       {
           return ExecuteNonQuery(CommandType.StoredProcedure, cmdText, spr);
       }

       //���������Ĵ洢����
       public static int ExecuteNonQueryPro(string cmdText)
       {
           return ExecuteNonQueryPro(cmdText, null);
       }

       //�������Ĳ������
       public static int ExecuteNonQuery(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteNonQuery(CommandType.Text, cmdText, spr);
       }

       //���������Ĳ������
       public static int ExecuteNonQuery(string cmdText)
       {
           return ExecuteNonQuery(cmdText, null);
       }

       //��ȡ����
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

       //�������Ĵ洢����
       public static DataSet GetDataSetPro(string cmdText, List<SqlParameter> spr)
       {
          return  GetDataSet(CommandType.StoredProcedure,cmdText,spr);
       }
       
       //���������Ĵ洢����
       public static DataSet GetDataSetPro(string cmdText)
       {
          return  GetDataSetPro(cmdText,null);
       }

       //���������ı���ѯ
       public static DataSet GetDataSet(string cmdText, List<SqlParameter> spr)
       {
          return GetDataSet(CommandType.Text, cmdText, spr);
       }

       //�����������ı���ѯ
       public static DataSet GetDataSet(string cmdText)
       {
           return GetDataSet(CommandType.Text, cmdText, null);
       }

       //�����Ķ���
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

       //�������Ĵ洢����
       public static SqlDataReader ExecuteReaderPro(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteReader(CommandType.StoredProcedure, cmdText, spr);
       }

       //�����������Ĵ洢����
       public static SqlDataReader ExecuteReaderPro(string cmdText)
       {
           return ExecuteReaderPro(cmdText,null);
       }


       //���������ı�
       public static SqlDataReader ExecuteReader(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteReader(CommandType.Text, cmdText, spr);
       }

       //�����������ı�
       public static SqlDataReader ExecuteReader(string cmdText)
       {
           return ExecuteReader(cmdText, null);
       }
       
       //���ص�һ�е�һ�е�ֵ
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

       //�������Ĵ洢����
       public static string ExecuteScalarPro(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteScalar(CommandType.StoredProcedure, cmdText, spr);
       }

       //���������Ĵ洢����
       public static string ExecuteScalarPro(string cmdText)
       {
           return ExecuteScalarPro(cmdText, null);
       }

       //���������ı�
       public static string ExecuteScalar(string cmdText, List<SqlParameter> spr)
       {
           return ExecuteScalar(CommandType.Text, cmdText, spr);
       }

       //�����������ı�
       public static string ExecuteScalar(string cmdText)
       {
           return ExecuteScalar(cmdText, null);
       }
    }
