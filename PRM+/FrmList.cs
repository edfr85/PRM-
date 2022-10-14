
using PRM_.DATA;
using PRM_.UTIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRM_
{
    #region delegate 선언
    public delegate void AddKillProcessOkEvent(string data);
    #endregion

    public partial class FrmList : Form
    {
        #region 선언부
        int nProcessCnt = 0;
        string sProcessName = "";
        
        #endregion

        public FrmList()
        {
           
            InitializeComponent();
        }

        #region 폼로딩
        private void FrmList_Load(object sender, EventArgs e)
        {

            CLog.LOG(LOG_TYPE.SCREEN, "FrmList Load");
            FrmList_Load_Process();
            CLog.LOG(LOG_TYPE.SCREEN, "FrmList Success");
        }

        public void FrmList_Load_Process()
        {
            CLog.LOG(LOG_TYPE.SCREEN, "FrmList Process List Load");
            AddKListChBox.Items.Clear();
            nProcessCnt = 0;
                Process[] processes = Process.GetProcesses(); // 모든 프로세스 추출

            foreach (Process process in processes)
            { // foreach 루프 수행
                AddKListChBox.Items.Add(process.ProcessName);
                nProcessCnt++;
            }

        }
        #endregion

        

        #region 버튼 클릭
        private void AddKBtn_Click(object sender, EventArgs e) // 추가버튼 클릭
        {
            CLog.LOG(LOG_TYPE.SCREEN, "FrmList 추가 Click");

            int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sKillListPath); //카운트
            int nColnum = nCnt;
            bool bAdd = true;
            

            foreach (string obj in AddKListChBox.CheckedItems)
            {

                for (int i = 0; i <= nCnt; i++)
                {
                    sProcessName = CIni.Load("PROCESS", (i).ToString(), "", CData.sKillListPath);

                    if (sProcessName == obj.ToString())
                    {
                        bAdd = false;
                        if (CData.ucLog != null)
                            CData.ucLog.Lsv_Show("이미 존재하는 Process Name=" + obj.ToString());
                        CLog.LOG(LOG_TYPE.SCREEN, "이미 존재하는 Process Name=" + obj.ToString());

                    }

                }

                if (bAdd)
                {
                    CIni.Save("PROCESS", "CNT", (nColnum + 1).ToString(), CData.sKillListPath);
                    CIni.Save("PROCESS", (nColnum).ToString(), obj.ToString(), CData.sKillListPath);

                    if (CData.ucLog != null)
                    {
                        CData.ucLog.Lsv_Show("Kill Process Add=" + obj.ToString());
                        CData.ucLog.Lsv_Show("Kill Process Cnt=" + (nColnum+1).ToString());
                    }
                        
                    CLog.LOG(LOG_TYPE.PROC, "Kill Process Add=" + obj.ToString());
                    CLog.LOG(LOG_TYPE.PROC, "Kill Process Cnt=" + (nColnum + 1).ToString());
                }
            }

            for (int i = 0; i < nProcessCnt; i++)
            {
                AddKListChBox.SetItemChecked(i, false);
            }

        }

        private void CancelKBtn_Click(object sender, EventArgs e) //취소 버튼 클릭
        {
            CLog.LOG(LOG_TYPE.SCREEN, "FrmList 취소 Click");
            Close();
        }
        #endregion
    }
}
