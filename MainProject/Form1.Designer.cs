namespace MainProject
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DiemDi = new System.Windows.Forms.TextBox();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.txt_DiemDen = new System.Windows.Forms.TextBox();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_TimToaDo = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(688, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoảng Cách";
            // 
            // txt_DiemDi
            // 
            this.txt_DiemDi.Location = new System.Drawing.Point(12, 12);
            this.txt_DiemDi.Name = "txt_DiemDi";
            this.txt_DiemDi.Size = new System.Drawing.Size(401, 20);
            this.txt_DiemDi.TabIndex = 1;
            // 
            // btn_Tim
            // 
            this.btn_Tim.Location = new System.Drawing.Point(419, 12);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(75, 46);
            this.btn_Tim.TabIndex = 2;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // txt_DiemDen
            // 
            this.txt_DiemDen.Location = new System.Drawing.Point(12, 38);
            this.txt_DiemDen.Name = "txt_DiemDen";
            this.txt_DiemDen.Size = new System.Drawing.Size(401, 20);
            this.txt_DiemDen.TabIndex = 3;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(12, 85);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1074, 526);
            this.gMapControl1.TabIndex = 4;
            this.gMapControl1.Zoom = 0D;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(500, 12);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(88, 46);
            this.btn_Refresh.TabIndex = 5;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(594, 12);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(88, 46);
            this.btn_Thoat.TabIndex = 6;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_TimToaDo
            // 
            this.btn_TimToaDo.Location = new System.Drawing.Point(688, 12);
            this.btn_TimToaDo.Name = "btn_TimToaDo";
            this.btn_TimToaDo.Size = new System.Drawing.Size(122, 42);
            this.btn_TimToaDo.TabIndex = 7;
            this.btn_TimToaDo.Text = "Tìm Toạ Độ";
            this.btn_TimToaDo.UseVisualStyleBackColor = true;
            this.btn_TimToaDo.Click += new System.EventHandler(this.btn_TimToaDo_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(919, 34);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonCalculate.Size = new System.Drawing.Size(176, 45);
            this.buttonCalculate.TabIndex = 8;
            this.buttonCalculate.Text = "Tính Toán";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 623);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.btn_TimToaDo);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.txt_DiemDen);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_DiemDi);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DiemDi;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.TextBox txt_DiemDen;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_TimToaDo;
        private System.Windows.Forms.Button buttonCalculate;
    }
}

