using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLy_QuanBanhISHAR.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 70;
        public static int TableHeight = 70;
        private TableDAO()
        {

        }

        public void SwitchTable(int id1, int id2)
        {
            DAO.DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[]{id1, id2});
        }
        public List<DTO.Table> LoadTableList()
        {
            List<DTO.Table> tableList = new List<DTO.Table>();
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery("USP_GetTableList");

             foreach(DataRow item in data.Rows)
             {
                 DTO.Table table = new DTO.Table(item);
                 tableList.Add(table);
             }
            return tableList;
        }
    }
}
