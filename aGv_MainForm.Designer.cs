namespace WindowsFormsApplication1
{
    partial class aGv_MainForm
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
            this.gridBtn = new System.Windows.Forms.Button();
            this.grid_status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_status_updater = new System.Windows.Forms.Timer(this.components);
            this.add_agv = new System.Windows.Forms.Button();
            this.Point_array = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gridBtn
            // 
            this.gridBtn.Location = new System.Drawing.Point(44, 12);
            this.gridBtn.Name = "gridBtn";
            this.gridBtn.Size = new System.Drawing.Size(93, 29);
            this.gridBtn.TabIndex = 0;
            this.gridBtn.Text = "Draw Grid";
            this.gridBtn.UseVisualStyleBackColor = true;
            this.gridBtn.Click += new System.EventHandler(this.gridBtn_Click);
            // 
            // grid_status
            // 
            this.grid_status.Location = new System.Drawing.Point(12, 110);
            this.grid_status.Multiline = true;
            this.grid_status.Name = "grid_status";
            this.grid_status.Size = new System.Drawing.Size(156, 139);
            this.grid_status.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grid\'s Status";
            // 
            // grid_status_updater
            // 
            this.grid_status_updater.Tick += new System.EventHandler(this.grid_status_updater_Tick);
            // 
            // add_agv
            // 
            this.add_agv.Location = new System.Drawing.Point(44, 48);
            this.add_agv.Name = "add_agv";
            this.add_agv.Size = new System.Drawing.Size(93, 32);
            this.add_agv.TabIndex = 4;
            this.add_agv.Text = "Add AGV";
            this.add_agv.UseVisualStyleBackColor = true;
            // 
            // Point_array
            // 
            this.Point_array.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Point_array.Location = new System.Drawing.Point(526, 12);
            this.Point_array.Multiline = true;
            this.Point_array.Name = "Point_array";
            this.Point_array.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Point_array.Size = new System.Drawing.Size(468, 283);
            this.Point_array.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Press me madafaka";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "create agv";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // aGv_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 336);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Point_array);
            this.Controls.Add(this.add_agv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid_status);
            this.Controls.Add(this.gridBtn);
            this.Name = "aGv_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "aGv_MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gridBtn;
        private System.Windows.Forms.TextBox grid_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer grid_status_updater;
        private System.Windows.Forms.Button add_agv;
        private System.Windows.Forms.TextBox Point_array;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

