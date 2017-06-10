using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

using YK.Model;
using YK.Service;
using YK.Common;

/// <summary>
/// 活动帮助类,满x元免运费,满x元送x积分,满x元打x折,满x元送优惠券,满x元减x元
/// </summary>
public class ActivityHelper
{
    /// <summary>
    /// 获取活动信息
    /// </summary>
    /// <returns></returns>
    public static IDictionary<string, object> GetActivity()
    {
        IDictionary<string, object> idic = new Dictionary<string, object>();

        decimal totalAmount = Cart.GetTotalAmount();

        //活动信息
        string activityInfo = "";

        //1.满x元免运费
        var response = GetActivityInfo(totalAmount, 1);
        if (response.Count > 0)
        {
            activityInfo += response.First().Value + ",";
        }

        //2.满x元送x积分,
        response = GetActivityInfo(totalAmount, 2);
        if (response.Count > 0)
        {
            activityInfo += response.First().Value + ",";
            int integral =response["value"].ToInt();
        }
        //3.满x元打x折，
        response = GetActivityInfo(totalAmount, 3);
        if (response.Count > 0)
        {
            activityInfo += response.First().Value + ",";
            decimal discount = response["value"].ToDecimal();
        }
        //4.满x元送优惠券
        response = GetActivityInfo(totalAmount, 4);
        if (response.Count > 0)
        {
            activityInfo += response.First().Value + ",";
            decimal deductibleAmount = response["value"].ToDecimal();
        }

        idic.Add("info", activityInfo.TrimEnd(',') );
        idic.Add("value", totalAmount );

        return idic;
    }

    /// <summary>
    /// 1.满x元免运费，2.满x元送x积分,3.满x元打x折，4.满x元送优惠券
    /// </summary>
    /// <param name="totalAmount"></param>
    /// <returns></returns>
    public static IDictionary<string,object> GetActivityInfo(decimal totalAmount,int type)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Type", "=", type.ToStr()));
        expression.Add(new Expression("IsSetDate", "=", "0"));
        expression.Add(new Expression("IsEnable", "=", "1"));
        expression.Add(new Expression("Amount", "<", totalAmount ));
        List<TB_Activity_Activity> list = new List<TB_Activity_Activity>();
        list = ActivityService.ActivitysService.Search(expression);

        List<Expression> expression2 = new List<Expression>();
        expression.Add(new Expression("Type", "=", type.ToStr()));
        expression2.Add(new Expression("IsSetDate", "=", "1"));
        expression.Add(new Expression("IsEnable", "=", "1"));
        expression2.Add(new Expression("StartDate", ">=", DateTime.Now.ToString()));
        expression2.Add(new Expression("EndDate", "<=", DateTime.Now.ToString()));
        expression2.Add(new Expression("Amount", "<", totalAmount));

        list.AddRange(ActivityService.ActivitysService.Search(expression2));

        IDictionary<string, object> idic = new Dictionary<string, object>();

        decimal Amount = 0;
        if(list.Count>0)
        {
            Amount = list.OrderByDescending(l => l.Amount).First().Amount;
        }

        switch (type)
        { 
            case 1:
                if(list.Count > 0)
                {
                    idic.Add("info", "满" + Amount + "元免运费");
                    idic.Add("value",true);
                }
                break;
            case 2:
                if (list.Count > 0)
                {
                    int Integral = list.OrderByDescending(l => l.Integral).First().Integral;

                    idic.Add("info", "满" + Amount + "元送" + Integral + "积分");
                    idic.Add("value", Integral);
                }
                break;
            case 3:
                if (list.Count > 0)
                {
                    decimal Discount = list.OrderByDescending(l => l.Discount).First().Discount;

                    idic.Add("info", "满" + Amount + "元打" + Discount + "折");
                    idic.Add("value", Discount);
                }
                break;
            case 4:
                if (list.Count > 0)
                {
                    decimal DeductibleAmount = list.OrderByDescending(l => l.DeductibleAmount).First().DeductibleAmount;

                    idic.Add("info", "满" + Amount + "元送" + DeductibleAmount + "元优惠券");
                    idic.Add("value", DeductibleAmount );
                }
                break;
        }

        return idic;
    }

}