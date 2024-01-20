namespace gdi_PointAndClick
{
    partial class FrmMain
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
            SuspendLayout();
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 341);
            Cursor = Cursors.Cross;
            Margin = new Padding(2, 1, 2, 1);
            Name = "FrmMain";
            Text = "Point and Click";
            Load += FrmMain_Load;
            DragDrop += FrmMain_DragDrop;
            Paint += FrmMain_Paint;
            KeyDown += FrmMain_KeyDown;
            MouseClick += FrmMain_MouseClick;
            MouseDown += FrmMain_MouseDown;
            MouseMove += FrmMain_MouseMove;
            MouseUp += FrmMain_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}