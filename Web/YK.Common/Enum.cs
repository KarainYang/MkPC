using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.ComponentModel;

using YK.Model;

namespace YK.Common
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType { 用户操作, 商品操作, 新闻操作, 订单操作, 评论操作 }

    /// <summary>
    /// 表达式条件
    /// </summary>
    public enum Condition
    {
        [Description("=")]
        等于,
        [Description(">")]
        大于,
        [Description("<")]
        小于,
        [Description(">=")]
        大于或等于,
        [Description("<=")]
        小于或等于
    }
}
