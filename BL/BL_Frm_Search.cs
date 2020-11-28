using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using System.Data;
using System.Data.SqlClient;
namespace BL
{
    public class BL_Frm_Search:DataAccess
    {
        public string TextCommand;
        public int reng;
        public string ISBN;

        public DataTable Select()
        {
            base.Link();
            string Query = "select ISBN as [کد کتاب],title as [عنوان],SubjectName as [موضوع],wirter as [نویسنده],publishers as [انتشارات],Year_Date as [سال نشر],NumPage as [تعداد صفحه],Price as [قیمت] from TB_Book,Tb_Subject where TB_Book.[Subject]=Tb_Subject.[Subject]";
            DataTable Output_Q = base.SelectData(Query);
            base.UnLink();
            return Output_Q;
        }

        public DataTable Select_Search()
        {
            base.Link();
            string Query="";

            if (reng==0)
            {
                Query = "select ISBN as [کد کتاب],title as [عنوان],SubjectName as [موضوع],wirter as [نویسنده],publishers as [انتشارات],Year_Date as [سال نشر],NumPage as [تعداد صفحه],Price as [قیمت] from TB_Book,Tb_Subject where TB_Book.[Subject]=Tb_Subject.[Subject] and ISBN Like '{0}%'";
            }
            else if(reng == 1)
            {
                Query = "select ISBN as [کد کتاب],title as [عنوان],SubjectName as [موضوع],wirter as [نویسنده],publishers as [انتشارات],Year_Date as [سال نشر],NumPage as [تعداد صفحه],Price as [قیمت] from TB_Book,Tb_Subject where TB_Book.[Subject]=Tb_Subject.[Subject] and title Like '{0}%'";
            }
            else if (reng == 2)
            {
                Query = "select ISBN as [کد کتاب],title as [عنوان],SubjectName as [موضوع],wirter as [نویسنده],publishers as [انتشارات],Year_Date as [سال نشر],NumPage as [تعداد صفحه],Price as [قیمت] from TB_Book,Tb_Subject where TB_Book.[Subject]=Tb_Subject.[Subject] and wirter Like '{0}%'";
            }
            else if (reng == 3)
            {
                Query = "select ISBN as [کد کتاب],title as [عنوان],SubjectName as [موضوع],wirter as [نویسنده],publishers as [انتشارات],Year_Date as [سال نشر],NumPage as [تعداد صفحه],Price as [قیمت] from TB_Book,Tb_Subject where TB_Book.[Subject]=Tb_Subject.[Subject] and publishers Like '{0}%'";
            }
            else if (reng == 4)
            {
                Query = "select ISBN as [کد کتاب],title as [عنوان],SubjectName as [موضوع],wirter as [نویسنده],publishers as [انتشارات],Year_Date as [سال نشر],NumPage as [تعداد صفحه],Price as [قیمت] from TB_Book,Tb_Subject where TB_Book.[Subject]=Tb_Subject.[Subject] and Year_Date Like '{0}%'";
            }

            Query = string.Format(Query, TextCommand);

            DataTable Qutput_Q = base.SelectData(Query);
            base.UnLink();
            return Qutput_Q;
        }

        public void Delete()
        {
            base.Link();
            string Query = "Delete From TB_Book where ISBN= N'{0}'";
            Query = string.Format(Query, ISBN);
            base.CommandText(Query);
            base.UnLink();
        }
    }
}
