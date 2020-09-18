namespace FM0._3
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Data = new System.Windows.Forms.TextBox();
            this.txt_ReturnCode = new System.Windows.Forms.TextBox();
            this.lbl_RetrunCode = new System.Windows.Forms.Label();
            this.lbl_Data = new System.Windows.Forms.Label();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_ReadDeviceBlock2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Data
            // 
            this.txt_Data.AcceptsReturn = true;
            this.txt_Data.Location = new System.Drawing.Point(22, 299);
            this.txt_Data.Multiline = true;
            this.txt_Data.Name = "txt_Data";
            this.txt_Data.ReadOnly = true;
            this.txt_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Data.Size = new System.Drawing.Size(753, 125);
            this.txt_Data.TabIndex = 51;
            this.txt_Data.TabStop = false;
            // 
            // txt_ReturnCode
            // 
            this.txt_ReturnCode.Location = new System.Drawing.Point(104, 251);
            this.txt_ReturnCode.Name = "txt_ReturnCode";
            this.txt_ReturnCode.ReadOnly = true;
            this.txt_ReturnCode.Size = new System.Drawing.Size(671, 21);
            this.txt_ReturnCode.TabIndex = 52;
            this.txt_ReturnCode.TabStop = false;
            // 
            // lbl_RetrunCode
            // 
            this.lbl_RetrunCode.Location = new System.Drawing.Point(24, 251);
            this.lbl_RetrunCode.Name = "lbl_RetrunCode";
            this.lbl_RetrunCode.Size = new System.Drawing.Size(72, 16);
            this.lbl_RetrunCode.TabIndex = 53;
            this.lbl_RetrunCode.Text = "Return Code:";
            // 
            // lbl_Data
            // 
            this.lbl_Data.Location = new System.Drawing.Point(24, 275);
            this.lbl_Data.Name = "lbl_Data";
            this.lbl_Data.Size = new System.Drawing.Size(72, 16);
            this.lbl_Data.TabIndex = 54;
            this.lbl_Data.Text = "Data:";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(628, 22);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(128, 32);
            this.btn_Open.TabIndex = 80;
            this.btn_Open.Text = "Open";
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(628, 70);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(128, 32);
            this.btn_Close.TabIndex = 81;
            this.btn_Close.Text = "Close";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_ReadDeviceBlock2
            // 
            this.btn_ReadDeviceBlock2.Location = new System.Drawing.Point(628, 122);
            this.btn_ReadDeviceBlock2.Name = "btn_ReadDeviceBlock2";
            this.btn_ReadDeviceBlock2.Size = new System.Drawing.Size(128, 32);
            this.btn_ReadDeviceBlock2.TabIndex = 82;
            this.btn_ReadDeviceBlock2.Text = "ReadDeviceBlock2";
            this.btn_ReadDeviceBlock2.Click += new System.EventHandler(this.btn_ReadDeviceBlock2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ReadDeviceBlock2);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.txt_ReturnCode);
            this.Controls.Add(this.lbl_RetrunCode);
            this.Controls.Add(this.lbl_Data);
            this.Controls.Add(this.txt_Data);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Data;
        internal System.Windows.Forms.TextBox txt_ReturnCode;
        internal System.Windows.Forms.Label lbl_RetrunCode;
        internal System.Windows.Forms.Label lbl_Data;
        internal System.Windows.Forms.Button btn_Open;
        internal System.Windows.Forms.Button btn_Close;
        internal System.Windows.Forms.Button btn_ReadDeviceBlock2;
    }
}

