using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PRM_.DATA;
using PRM_.UTIL;

namespace PRM_
{
    public partial class FrmMain : Form
    {
        
        CProc pProc = null;

        #region 사용자 컨트롤 선언
        
        #endregion

        bool bExitApp = false;

        int nRunCnt = 0;
        int nKillCnt = 0;
        int nNowRunCnt = 0;
        int nNowKillCnt = 0;

        Timer pTimer = new Timer();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CLog.LOG(LOG_TYPE.SCREEN, "PRM+ Start & Load");
            Base_Set();
            List_Set();
            Proc_Set();
            CLog.LOG(LOG_TYPE.SCREEN, "PRM+ Load Success");
        }

        private void Base_Set()
        {
            CFunc.CheckDir(CData.sSetDir);

            if (!File.Exists(CData.sKillListPath)) //킬리스트 파일 존재하지 않음면
            {

            }

            if (!File.Exists(CData.sRunListPath)) // 런리스트 파일 존재하지 않으면
            {

            }

            CData.ucLog = new UC_Log();

            groupBox1.Controls.Add(CData.ucLog);

            pTimer.Interval = 1000;
            pTimer.Tick += Timer_Event_InMain;

            pTimer.Start();

            CLog.LOG(LOG_TYPE.SCREEN, "Base Set Success");

        }
        
        private void Timer_Event_InMain(object sender, EventArgs e)
        {
            List_Set();
        }

        private void List_Set()
        {
            Run_Lst_Set();
            Kill_Lst_Set();
        }

        private void Run_Lst_Set()
        {
            
            int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sRunListPath); //카운트 
            string sProcessNm = "";

            if (nNowRunCnt != nCnt) //run 리스트 출력
            {
                lsvRun.Items.Clear();
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {
                    sProcessNm = CIni.Load("PROCESS", (i).ToString(), "", CData.sRunListPath);
                    lsvRun.Items.Add(sProcessNm.Substring(sProcessNm.LastIndexOf("\\") + 1));
                    
                }
            }

            nNowRunCnt = nCnt;
        }

        private void Kill_Lst_Set()
        {
            

            int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sKillListPath); //카운트 
            string sProcessNm = "";

            if (nNowKillCnt != nCnt) //리스트 출력 
            {
                lsvKill.Items.Clear();
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {
                    sProcessNm = CIni.Load("PROCESS", (i).ToString(), "", CData.sKillListPath);
                    lsvKill.Items.Add(sProcessNm);

                }

            }

            nNowKillCnt = nCnt;
        }

        private void Proc_Set()
        {
            if (pProc != null)
                pProc = null;

            pProc = new CProc();

            CLog.LOG(LOG_TYPE.SCREEN, "Proc Set Success");
        }

        private void KillTitmerBtn_Click(object sender, EventArgs e)
        {
            Timer_Control();
        }

        public void Timer_Control() // 프로그램 중지 와 시작 버튼
        {

            if (KillTitmerBtn.Text == "중지")
            {
                if (pProc != null)
                    pProc.Timer_Start();
                KillTitmerBtn.Text = "시작";
                중지ToolStripMenuItem.Text = "시작";
                CData.ucLog.Lsv_Show("Timer Start");
                CLog.LOG(LOG_TYPE.SCREEN, "Timer Start");
                

            }
            else
            {
                if (pProc != null)
                    pProc.Timer_Stop();
                KillTitmerBtn.Text = "중지";
                중지ToolStripMenuItem.Text = "중지";
                CData.ucLog.Lsv_Show("Timer Stop");
                CLog.LOG(LOG_TYPE.SCREEN, "Timer Stop");
            }
        }


        #region 트레이 아이콘
        private void activate(bool bActive) //트레이 연계
        {
            if (bActive)
            {
                this.Visible = true; //창을 보이지 않게 한다.
                this.ShowIcon = true; //작업표시줄에서 제거.
                nIPRM.Visible = false; //트레이 아이콘을 표시한다.
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Visible = false; //창을 보이지 않게 한다.
                this.ShowIcon = false; //작업표시줄에서 제거.
                nIPRM.Visible = true; //트레이 아이콘을 표시한다.
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void frmMain_Resize(object sender, EventArgs e) //폼 최소화 클릭 시 트레이
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                activate(false);
            }
        }


        private void PrmIcon_MouseDoubleClick(object sender, MouseEventArgs e) //이 밑으로 트레이 <- 여기는 아이콘 클릭시 보이는 폼 액티브
        {
            activate(true);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) //폼 닫을때 끄지말고 아이콘 비활성
        {
            if (!bExitApp)
            {
                e.Cancel = true;
                activate(false);
            }
        }

        private void PrmIcon_MouseClick(object sender, MouseEventArgs e) //일단 제외
        {
            //activate(true);
            //PrmContextMenu.Show(Control.MousePosition);
        }


        private void PrmIconOpen_Click(object sender, EventArgs e) //트레이에서 열기 클릭
        {
            activate(true);
        }

        private void PrmIconClose_Click(object sender, EventArgs e) // 트레이에서 종료 클릭
        {
            try
            {


                pProc.Timer_Stop();
                bExitApp = true;
                nIPRM.Visible = false;
                CLog.LOG(LOG_TYPE.SCREEN, "PRM+ Close");
                Application.Exit();
            }
            catch (Exception ex)
            {
                CLog.LOG(LOG_TYPE.ERR, "TrayClose Click Err=" + ex.ToString());
            }
        }

        private void StopStripMenu_Click(object sender, EventArgs e) //트레이에서 중지 클릭
        {
            Timer_Control();
        }
        #endregion

        private void AddKillListBtn_Click(object sender, EventArgs e)
        {
            FrmList frmSet = new FrmList();
            frmSet.ShowDialog();
            return;
        }

        private void DelKillListBtn_Click(object sender, EventArgs e) // 킬 리스트 삭제 버튼
        {
            int nCnum = 0;
            
            int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sKillListPath); //카운트 
            if (nCnt == 0)
                return;

            string sProcessNm = "";
            try
            {


                for (int i = 0; i < nCnt; i++)
                {
                    
                    sProcessNm = CIni.Load("PROCESS", i.ToString(), "0", CData.sKillListPath); //번호 출력 -> 비교

                    if (lsvKill.SelectedItems[0].Text == sProcessNm)
                    {
                        nCnum = i;
                        CIni.Save("PROCESS", "CNT", (nCnt - 1).ToString(), CData.sKillListPath);
                        CIni.Save("PROCESS", (i).ToString(), null, CData.sKillListPath);

                    }
                }

                for (int a = nCnum; a <= nCnt-1; a++)
                {
                    if (a != (nCnt-1))
                    {
                        CIni.Save("PROCESS", (a).ToString(), CIni.Load("PROCESS", (a + 1).ToString(), "", CData.sKillListPath), CData.sKillListPath);

                    }
                    else
                    {
                        CIni.Save("PROCESS", (a).ToString(), null, CData.sKillListPath);
                    }
                }

                if (CData.ucLog != null)
                {
                    CData.ucLog.Lsv_Show("Kill Process Del=" + sProcessNm);
                    CData.ucLog.Lsv_Show("Kill Process Cnt=" + (nCnt - 1).ToString());
                }

                CLog.LOG(LOG_TYPE.PROC, "Kill Process Del=" + sProcessNm);
                CLog.LOG(LOG_TYPE.PROC, "Kill Process Cnt=" + (nCnt - 1).ToString());

            }
            catch(Exception)
            {

            }
            


        }

        private void lsvKill_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception)
            {

            }
        }

        private void AddRunListBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string sNowdata = "";
                int nDnum = 0;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "파일 오픈";
                ofd.FileName = "File";
                ofd.Filter = "모든 파일 (*.*) | *.*";

                //파일 오픈창 로드
                DialogResult dr = ofd.ShowDialog();

                //OK버튼 클릭시
                if (dr == DialogResult.OK)
                {
                    //파일
                    string sFileName = ofd.SafeFileName;

                    //File명을 모두 가지고 온다.
                    string sFileFullName = ofd.FileName;

                    //File경로만 가지고 온다.
                    string sFilePath = sFileFullName.Replace(sFileName, "");

                    string sPrcoessCheck = sFileName.Substring(sFileName.LastIndexOf(".") + 1);

                    int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sRunListPath); //카운트 
                    if (sPrcoessCheck != null) // 파일 존재 시 추가
                    {

                            int i = 0;
                            string sProcess = "";
                            for (int a = 0; a < nCnt; ++a) //카운트 수만큼 반복
                            {
                                sNowdata = CIni.Load("PROCESS", a .ToString(), "", CData.sRunListPath);
                                i = a;
                                if (sFileName == sNowdata.Substring(sNowdata.LastIndexOf("\\") + 1)) //프로그램을 리스트에 중복 추가하는걸 방지
                                {
                                    nDnum = 1;
                                    continue;
                                }
                            }
                            if (nDnum == 0)
                            {
                                CIni.Save("PROCESS", "CNT", (nCnt+1).ToString(), CData.sRunListPath);
                                //sProcess = CIni.Load("PROCESS", (nCnt).ToString(), "", CData.sRunListPath);
                                CIni.Save("PROCESS", (nCnt).ToString(), sFileFullName, CData.sRunListPath); //프로세스명 출력

                            if (CData.ucLog != null)
                            {
                                CData.ucLog.Lsv_Show("Run Process Add=" + sFileName.Substring(sFileName.LastIndexOf("\\") + 1));
                                CData.ucLog.Lsv_Show("Run Process Cnt=" + (nCnt + 1).ToString());
                            }

                            CLog.LOG(LOG_TYPE.PROC, "Run Process Add=" + sFileName.Substring(sFileName.LastIndexOf("\\") + 1));
                            CLog.LOG(LOG_TYPE.PROC, "Run Process Cnt=" + (nCnt + 1).ToString());
                        }

                    }

                }
                //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
                else if (dr == DialogResult.Cancel)
                {
                }
            }
            catch(Exception)
            {

            }
        }

        private void DelRunListBtn_Click(object sender, EventArgs e)
        {
            int nCnum = 0;

            int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sRunListPath); //카운트 
            if (nCnt == 0)
                return;

            string sProcessNm = "";
            try
            {


                for (int i = 0; i < nCnt; i++)
                {

                    sProcessNm = CIni.Load("PROCESS", i.ToString(), "0", CData.sRunListPath); //번호 출력 -> 비교

                    if (sProcessNm.IndexOf(lsvRun.SelectedItems[0].Text) != -1)
                    {
                        nCnum = i;
                        CIni.Save("PROCESS", "CNT", (nCnt - 1).ToString(), CData.sRunListPath);
                        CIni.Save("PROCESS", (i).ToString(), null, CData.sRunListPath);

                    }
                }

                for (int a = nCnum; a <= nCnt - 1; a++)
                {
                    if (a != (nCnt - 1))
                    {
                        CIni.Save("PROCESS", (a).ToString(), CIni.Load("PROCESS", (a + 1).ToString(), "", CData.sRunListPath), CData.sRunListPath);

                    }
                    else
                    {
                        CIni.Save("PROCESS", (a).ToString(), null, CData.sRunListPath);
                    }
                }

                if (CData.ucLog != null)
                {
                    CData.ucLog.Lsv_Show("Run Process Del=" + sProcessNm.Substring(sProcessNm.LastIndexOf("\\") + 1));
                    CData.ucLog.Lsv_Show("Run Process Cnt=" + (nCnt - 1).ToString());
                }

                CLog.LOG(LOG_TYPE.PROC, "Run Process Del=" + sProcessNm.Substring(sProcessNm.LastIndexOf("\\") + 1));
                CLog.LOG(LOG_TYPE.PROC, "Run Process Cnt=" + (nCnt - 1).ToString());

            }
            catch (Exception)
            {

            }

        }
    }
}
