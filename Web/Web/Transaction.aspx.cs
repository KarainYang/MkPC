using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YK.Model;
using YK.Service;
using System.Transactions;

public partial class Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (TransactionScope trans = new TransactionScope())
        {
            SampleEnlistment1 myEnlistment1 = new SampleEnlistment1();
            System.Transactions.Transaction.Current.EnlistVolatile(myEnlistment1, EnlistmentOptions.None);


            try
            {
                TB_Info_News news = new TB_Info_News();
                news.Title = "事物测试01";
                news.AddDate = DateTime.Now;

                TB_Info_News news2 = new TB_Info_News();
                news2.Title = "事物测试01";
                news2.CategoryCode = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
                news2.AddDate = DateTime.Now;

                YK.Service.InfoService.NewsService.Insert(news);
                YK.Service.InfoService.NewsService.Insert(news2);
                
                trans.Complete();
            }
            catch
            {

            }
        }
    }
}

class SampleEnlistment1 : IEnlistmentNotification
{

 void IEnlistmentNotification.Commit(Enlistment enlistment)
 {
 enlistment.Done();
 }

 void IEnlistmentNotification.InDoubt(Enlistment enlistment)
 {
 throw new Exception("The method or operation is not implemented.");
 }

 void IEnlistmentNotification.Prepare(PreparingEnlistment preparingEnlistment)
 {
 preparingEnlistment.Prepared();
 }

 void IEnlistmentNotification.Rollback(Enlistment enlistment)
 {
 enlistment.Done();
 }
}
