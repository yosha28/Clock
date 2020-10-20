namespace MyClock
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.clock1 = new ClockControlLibrary.Clock();
            this.SuspendLayout();
            // 
            // clock1
            // 
            this.clock1.ArrowColorSecond = System.Drawing.Color.Navy;
            this.clock1.AutoSize = true;
            this.clock1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.clock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clock1.Font = new System.Drawing.Font("Algerian", 10F);
            this.clock1.Location = new System.Drawing.Point(0, 0);
            this.clock1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clock1.MinimumSize = new System.Drawing.Size(50, 70);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(284, 260);
            this.clock1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 260);
            this.Controls.Add(this.clock1);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(100, 150);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion      
        private ClockControlLibrary.Clock clock1;
    }
}

