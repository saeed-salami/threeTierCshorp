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
  public  class BL_Mom:DataAccess
    {
        public string ISBN;
        public DataTable Select()
        {
            base.Link();
            string Query = "select * from TB_Book where ISBN = '{0}'";
            Query = string.Format(Query, ISBN);
            DataTable Output_Q = base.SelectData(Query);
            base.UnLink();
            return Output_Q;
        }
    }
}
