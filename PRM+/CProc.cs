using PRM_.DATA;
using PRM_.UTIL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PRM_
{
    class CProc
    {
        private Timer pTimer_Proc = new Timer();

        public delegate void DF_WriteLsv();
        public DF_WriteLsv dF_WriteLsv;


        public CProc()
        {
            pTimer_Proc.Interval = 1000;
            pTimer_Proc.Elapsed += Timer_Event_Proc;
            pTimer_Proc.Start();
        }

        private void Timer_Event_Proc(object sender, EventArgs e)
        {
            Kill_Proc_Event();
            Run_Proc_Event();
        }

        private void Event_Proc()
        {
            Kill_Proc_Event();
            Run_Proc_Event();
        }

        public void Timer_Stop()
        {
            pTimer_Proc.Stop();
        }

        public void Timer_Start()
        {
            pTimer_Proc.Start();
        }

        private void Kill_Proc_Event()
        {

            int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sKillListPath); //카운트 
            if (nCnt > 0)
            {
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {
                    string sProcessName = "";
                    sProcessName = CIni.Load("PROCESS", (i + 1).ToString(), "", CData.sKillListPath); //프로세스명 출력
                    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(sProcessName);

                    foreach (System.Diagnostics.Process p in process)
                    {
                        if (!string.IsNullOrEmpty(p.ProcessName))
                        {
                            try
                            {
                                p.Kill();
                                if (CData.ucLog != null)
                                    CData.ucLog.Lsv_Show("Process Kill=" + p.ProcessName);

                                CLog.LOG(LOG_TYPE.PROC, "Process Kill=" + p.ProcessName);
                                
                            }
                            catch (Exception e)
                            {
                                CLog.LOG(LOG_TYPE.ERR, "Process Kill Err=" + e.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void Run_Proc_Event()
        {
            int nCnt = CIni.Load("PROCESS", "CNT", 0, CData.sRunListPath); //카운트 

            if (nCnt > 0)
            {
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {
                    string sProcessName = "";
                    string sShortNm = "";
                    ProcessStartInfo psi = new ProcessStartInfo();
                    Process Process_ = new Process();

                    sProcessName = CIni.Load("PROCESS", i.ToString(), "", CData.sRunListPath);
                    string[] sName = sProcessName.Split('\\');
                    sShortNm = sName[sName.Length].Substring(0, sName[sName.Length].LastIndexOf("."));
                    int nCheckEv = 0;

                    string shortname = sProcessName.Substring(sProcessName.LastIndexOf("\\") + 1);
                    string foldername = sProcessName.Substring(0, (sProcessName.LastIndexOf("\\") + 1));

                    psi.WorkingDirectory = foldername;
                    psi.FileName = sProcessName;

                    Process_.StartInfo = psi;

                    Process[] is_run = Process.GetProcessesByName(shortname.Substring(0, shortname.LastIndexOf(".")));
                    Process[] is_Proc = Process.GetProcesses();

                    IntPtr handle = IntPtr.Zero;
                    FileInfo fi = new FileInfo(sProcessName);
                    
                    if (fi.Exists == true)
                    {

                        if (is_run.Length == 0)
                        {
                            try
                            {

                                if (shortname.IndexOf("VCat") != -1)
                                {
                                    nCheckEv = 0;

                                    foreach (Process process in is_Proc)
                                    {
                                        if (process.ProcessName.IndexOf("VCat") != -1)
                                        {
                                            nCheckEv = 1;
                                        }
                                    }

                                }

                                if (nCheckEv == 0)
                                {
                                    Process_.Start();
                                    if (CData.ucLog != null)
                                        CData.ucLog.Lsv_Show("Process Run=" + sProcessName);
                                    CLog.LOG(LOG_TYPE.PROC, "Process Run=" + sProcessName);
                                }



                            }
                            catch (Exception ex)
                            {
                                CLog.LOG(LOG_TYPE.ERR, ex.ToString());
                            }

                            try
                            {
                                handle = Process_.Handle;
                            }
                            catch (Exception ex)
                            {
                                CLog.LOG(LOG_TYPE.ERR, ex.ToString());
                            }

                        }
                        else
                        {
                            //실행중인 프로세스 화면 최상위로 올릴시 추가
                        }

                    }
                }
            }
        }

    }
    

}
