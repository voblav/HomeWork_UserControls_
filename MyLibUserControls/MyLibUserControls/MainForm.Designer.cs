namespace MyLibUserControls
{
    partial class MainForm
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
            this.analogClock1 = new MyLibUserControls.AnalogClock();
            this.indicator1 = new MyLibUserControls.Indicator();
            this.SuspendLayout();
            // 
            // analogClock1
            // 
            this.analogClock1.Location = new System.Drawing.Point(20, 19);
            this.analogClock1.Name = "analogClock1";
            this.analogClock1.Size = new System.Drawing.Size(254, 226);
            this.analogClock1.TabIndex = 0;
            // 
            // indicator1
            // 
            this.indicator1.ColorArrow = System.Drawing.Color.Empty;
            this.indicator1.ColorScale = System.Drawing.Color.Empty;
            this.indicator1.IndicatorMode = MyLibUserControls.Indicator.ArrIndicatorMode.Full;
            this.indicator1.Location = new System.Drawing.Point(280, 12);
            this.indicator1.MaxValue = 100;
            this.indicator1.MinValue = 0;
            this.indicator1.Name = "indicator1";
            this.indicator1.Size = new System.Drawing.Size(498, 229);
            this.indicator1.TabIndex = 1;
            this.indicator1.Value = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 261);
            this.Controls.Add(this.indicator1);
            this.Controls.Add(this.analogClock1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AnalogClock analogClock1;
        private Indicator indicator1;
    }
}

