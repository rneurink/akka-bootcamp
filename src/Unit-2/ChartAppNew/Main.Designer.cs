namespace ChartAppNew
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            sysChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            diskBtn = new System.Windows.Forms.Button();
            memBtn = new System.Windows.Forms.Button();
            cpuBtn = new System.Windows.Forms.Button();
            pauseResumeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)sysChart).BeginInit();
            SuspendLayout();
            // 
            // sysChart
            // 
            chartArea1.Name = "ChartArea1";
            sysChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            sysChart.Legends.Add(legend1);
            sysChart.Location = new System.Drawing.Point(0, 0);
            sysChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            sysChart.Name = "sysChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            sysChart.Series.Add(series1);
            sysChart.Size = new System.Drawing.Size(912, 686);
            sysChart.TabIndex = 0;
            sysChart.Text = "sysChart";
            // 
            // diskBtn
            // 
            diskBtn.Location = new System.Drawing.Point(766, 569);
            diskBtn.Name = "diskBtn";
            diskBtn.Size = new System.Drawing.Size(118, 51);
            diskBtn.TabIndex = 1;
            diskBtn.Text = "DISK (OFF)";
            diskBtn.UseVisualStyleBackColor = true;
            diskBtn.Click += diskBtn_Click;
            // 
            // memBtn
            // 
            memBtn.Location = new System.Drawing.Point(766, 512);
            memBtn.Name = "memBtn";
            memBtn.Size = new System.Drawing.Size(118, 51);
            memBtn.TabIndex = 2;
            memBtn.Text = "MEMORY (OFF)";
            memBtn.UseVisualStyleBackColor = true;
            memBtn.Click += memBtn_Click;
            // 
            // cpuBtn
            // 
            cpuBtn.Location = new System.Drawing.Point(766, 455);
            cpuBtn.Name = "cpuBtn";
            cpuBtn.Size = new System.Drawing.Size(118, 51);
            cpuBtn.TabIndex = 3;
            cpuBtn.Text = "CPU (ON)";
            cpuBtn.UseVisualStyleBackColor = true;
            cpuBtn.Click += cpuBtn_Click;
            // 
            // pauseResumeBtn
            // 
            pauseResumeBtn.Location = new System.Drawing.Point(766, 354);
            pauseResumeBtn.Name = "pauseResumeBtn";
            pauseResumeBtn.Size = new System.Drawing.Size(118, 51);
            pauseResumeBtn.TabIndex = 4;
            pauseResumeBtn.Text = "Pause ||";
            pauseResumeBtn.UseVisualStyleBackColor = true;
            pauseResumeBtn.Click += pauseResumeBtn_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(912, 686);
            Controls.Add(pauseResumeBtn);
            Controls.Add(cpuBtn);
            Controls.Add(memBtn);
            Controls.Add(diskBtn);
            Controls.Add(sysChart);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "Main";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "System Metrics";
            ((System.ComponentModel.ISupportInitialize)sysChart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart sysChart;
        private System.Windows.Forms.Button diskBtn;
        private System.Windows.Forms.Button memBtn;
        private System.Windows.Forms.Button cpuBtn;
        private System.Windows.Forms.Button pauseResumeBtn;
    }
}
