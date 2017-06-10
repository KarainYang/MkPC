using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using System.Data;

namespace YK.Model
{
    //public enum Join { like,in,or,(,) }
    /// <summary>
    /// ���ʽ
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public Expression()
        { 
        
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="fieldName">�ֶ���</param>
        /// <param name="condition">����</param>
        /// <param name="value">ֵ</param>
        public Expression(string fieldName,string condition,object value)
        {
            FieldName = fieldName;
            Condition = condition;
            Value = value.ToString();
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="join">���ӷ�: (��)��and �� or</param>
        /// <param name="value">ֵ</param>
        public Expression(string join)
        {
            Join = join;
        }

        /// <summary>
        /// �ֶ�����
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// ֵ
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ���ӷ�: (��)��and �� or
        /// </summary>
        public string Join { get; set; }
    }
}
