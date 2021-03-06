﻿using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VeriSource.FormGrab.WFD.Scheduler;

namespace VeriSource.FormGrab.WFD
{
    public partial class WFDForm : Form
    {
        private int _count = 0, _totalFiles, cycle = 0;
        private string _sourceDir, _destinationDir, _frequency, _fileFormat, _postProcess, _processPath, _machineName;
        private IScheduler _scheduler;

        public WFDForm(IScheduler scheduler)
        {
            InitializeComponent();
            _scheduler = scheduler;
            _scheduler.Run += tmrRetrieval_Tick;
            _sourceDir = ConfigurationManager.AppSettings["SourceDirectory"];
            _destinationDir = ConfigurationManager.AppSettings["DestinationDirectory"];
            _frequency = ConfigurationManager.AppSettings["Frequency"];
            _postProcess = ConfigurationManager.AppSettings["PostProcess"];
            _processPath = ConfigurationManager.AppSettings["ProcessPath"];
            _machineName = ConfigurationManager.AppSettings["MachineName"];
            _fileFormat = ConfigurationManager.AppSettings["FileFormat"];
            tmrRetrieval.Interval = Int32.Parse(_frequency);
            Run();

        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Stop")
            {
                btnStart.Text = "Start";
                lblStart.Text = "Program stoped at: " + DateTime.Now.ToString(@"MM/dd/yyyy HH:mm:ss");
                tmrRetrieval.Stop();
            }
            else
            {
                Run();
            }
        }

        private void Run()
        {
            btnStart.Text = "Stop";
            lblStart.Text = "Program started at: " + DateTime.Now.ToString(@"MM/dd/yyyy HH:mm:ss");

            tmrRetrieval.Start();

            if (!bgwProcess.IsBusy && !PrepareCopy())
            {
                bgwProcess.RunWorkerAsync();
            }
        }

        public void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs, BackgroundWorker worker)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            FileInfo[] files;

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            // Get the files in the directory and copy them to the new location.
            files = dir.GetFiles(_fileFormat);

            foreach (FileInfo file in files)
            {
                _count++;
                string temppath = Path.Combine(destDir, file.Name);
                file.CopyTo(temppath, true);
                worker.ReportProgress((int)((_count / _totalFiles) * 100), new object[] { Path.Combine(sourceDir, file.Name), _count });
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs, worker);
                }
            }
        }

        private void bgwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            DirectoryCopy(_sourceDir, _destinationDir, true, worker);
        }

        private void bgwProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object[] report = (object[])e.UserState;
            lblProgress.Text = report[1].ToString() + " files downloaded.";
            lblProgress.ForeColor = System.Drawing.Color.DarkCyan;
            txtPath.Text = report[0].ToString();
            pgbProgess.PerformStep();
        }

        private void bgwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                Kill(_sourceDir);
                lblProgress.Text = "Total " + _count + " file(s) downloaded!";
                lblProgress.ForeColor = System.Drawing.Color.Green;

                Process[] pname = Process.GetProcessesByName(_postProcess, _machineName);
                if (pname.Length == 0)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = _processPath;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                }
            }
            txtPath.Text = "";
            _count = 0;
        }

        public bool PrepareCopy()
        {
            var ready = false;
            if (DateTime.Now.TimeOfDay > new TimeSpan(3, 00, 0) && DateTime.Now.TimeOfDay < new TimeSpan(23, 30, 0))
            {
                _totalFiles = Directory.GetFiles(_sourceDir, _fileFormat, SearchOption.AllDirectories).Length;
                if (_totalFiles == 0)
                {
                    lblProgress.ForeColor = System.Drawing.Color.Blue;
                    lblProgress.Text = "Nothing to copy.";
                    txtPath.Text = "";
                    ready = true;
                }
                cycle = (cycle > 32000) ? 1 : (cycle + 1);
                lblCycle.Text = "Cycle # " + cycle;
                pgbProgess.Maximum = _totalFiles;
                pgbProgess.Value = 0;
            }
            else
            {
                ready = true;
                lblProgress.Text = "Back up hours";
                lblProgress.ForeColor = System.Drawing.Color.Red;
            }

            return ready;
        }

        private void tmrRetrieval_Tick(object sender, EventArgs e)
        {
            if (!bgwProcess.IsBusy && !PrepareCopy())
            {
                bgwProcess.RunWorkerAsync();
            }
        }

        private void Kill(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}