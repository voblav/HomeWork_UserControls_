namespace MyLibUserControls
{
    partial class Indicator
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
            this.timerIndicator = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerIndicator
            // 
            this.timerIndicator.Enabled = true;
            this.timerIndicator.Interval = 1000;
            this.timerIndicator.Tick += new System.EventHandler(this.timerIndicator_Tick);
            // 
            // Indicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Indicator";
            this.Size = new System.Drawing.Size(498, 229);
            this.Load += new System.EventHandler(this.Indicator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Indicator_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerIndicator;
    }
}
