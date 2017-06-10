using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace YK.Controls
{
    /// <summary>
    /// 上传控件
    /// </summary>
    public class FileUpload : System.Web.UI.WebControls.FileUpload
    {
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute("GroupName", GroupName);
            writer.AddAttribute("LabelID", LabelID);
        }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 提示标签编号
        /// </summary>
        public string LabelID { get; set; }
    }
}
