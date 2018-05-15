namespace MyLibUserControls
{
    partial class AnalogClock
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerClock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimerClock
            // 
            this.TimerClock.Enabled = true;
            this.TimerClock.Interval = 1000;
            this.TimerClock.Tick += new System.EventHandler(this.TimerClock_Tick);
            // 
            // AnalogClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "AnalogClock";
            this.Size = new System.Drawing.Size(308, 226);
            this.Load += new System.EventHandler(this.AnalogClock_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogClock_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerClock;
    }
}
