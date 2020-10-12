namespace ActionVykreslovani
{
    partial class Form1
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

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.canvas1 = new ActionVykreslovani.Canvas();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(538, 10);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(538, 511);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Location = new System.Drawing.Point(538, 526);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(320, 53);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Přidat";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.Color.White;
            this.canvas1.Location = new System.Drawing.Point(12, 10);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(521, 566);
            this.canvas1.TabIndex = 2;
            this.canvas1.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas1_Paint);
            this.canvas1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 588);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addButton;
        private Canvas canvas1;
    }
}

