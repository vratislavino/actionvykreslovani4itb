namespace ActionVykreslovani
{
    partial class Command
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            this.colorPctbx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorPctbx)).BeginInit();
            this.SuspendLayout();
            // 
            // colorPctbx
            // 
            this.colorPctbx.BackColor = System.Drawing.Color.Red;
            this.colorPctbx.Location = new System.Drawing.Point(3, 4);
            this.colorPctbx.Name = "colorPctbx";
            this.colorPctbx.Size = new System.Drawing.Size(38, 33);
            this.colorPctbx.TabIndex = 1;
            this.colorPctbx.TabStop = false;
            // 
            // Command
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.colorPctbx);
            this.Name = "Command";
            this.Size = new System.Drawing.Size(498, 41);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Command_Paint);
            this.DoubleClick += new System.EventHandler(this.Command_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Command_MouseUp);
            this.Move += new System.EventHandler(this.Command_Move);
            ((System.ComponentModel.ISupportInitialize)(this.colorPctbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox colorPctbx;
    }
}
