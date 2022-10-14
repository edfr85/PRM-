using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRM_
{
    public partial class UC_Log : UserControl
    {
        public UC_Log()
        {
            InitializeComponent();
        }

        public void Lsv_Clear()
        {
            lsvLog.Items.Clear();
        }

        public void Lsv_Show(string sLog)
        {
            string sDttm = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ");
            string[] sLsvItem = new string[] { sDttm + sLog };
            ListViewItem lviAdd = new ListViewItem(sLsvItem);
            
            //lsvLog.Sorting = SortOrder.Descending;

            lsvLog.Items.Add(lviAdd);

            if(lsvLog.Columns.Count >= 100)
            {
                lsvLog.Items.RemoveAt(100);
            }
        }
    }
}
