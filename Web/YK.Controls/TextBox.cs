using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;

namespace YK.Controls
{
    /// <summary>
    /// 文本框
    /// </summary>
    public class TextBox:System.Web.UI.WebControls.TextBox
    {
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute("GroupName", GroupName);
            writer.AddAttribute("LabelID", LabelID);
            writer.AddAttribute("Validator", Validator.ToString());
        }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 提示标签编号
        /// </summary>
        public string LabelID { get; set; }

        /// <summary>
        /// 验证类型
        /// </summary>
        public Validator Validator { get; set; }
    }
}
