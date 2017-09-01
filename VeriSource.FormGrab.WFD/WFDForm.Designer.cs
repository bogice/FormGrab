namespace WFD
{
    partial class WFDForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pgbProgess = new System.Windows.Forms.ProgressBar();
            this.bgwProcess = new System.ComponentModel.BackgroundWorker();
            this.tmrRetrieval = new System.Windows.Forms.Timer(this.components);
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblCycle = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(30, 44);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(48, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "File Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(97, 41);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(402, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(399, 117);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 25);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start\r\n";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.Button_Click);
            // 
            // pgbProgess
            // 
            this.pgbProgess.Location = new System.Drawing.Point(97, 73);
            this.pgbProgess.Name = "pgbProgess";
            this.pgbProgess.Size = new System.Drawing.Size(259, 23);
            this.pgbProgess.Step = 1;
            this.pgbProgess.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbProgess.TabIndex = 3;
            // 
            // bgwProcess
            // 
            this.bgwProcess.WorkerReportsProgress = true;
            this.bgwProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcess_DoWork);
            this.bgwProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwProcess_ProgressChanged);
            this.bgwProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcess_RunWorkerCompleted);
            // 
            // tmrRetrieval
            // 
            this.tmrRetrieval.Interval = 30000;
            this.tmrRetrieval.Tick += new System.EventHandler(this.tmrRetrieval_Tick);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(375, 83);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 4;
            // 
            // lblCycle
            // 
            this.lblCycle.AutoSize = true;
            this.lblCycle.Location = new System.Drawing.Point(100, 123);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(0, 13);
            this.lblCycle.TabIndex = 6;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(30, 9);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(0, 13);
            this.lblStart.TabIndex = 7;
            // 
            // WFDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 162);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pgbProgess);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Name = "WFDForm";
            this.Text = "Web Form Dowloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pgbProgess;
        private System.ComponentModel.BackgroundWorker bgwProcess;
        private System.Windows.Forms.Timer tmrRetrieval;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblCycle;
        private System.Windows.Forms.Label lblStart;
    }
}

