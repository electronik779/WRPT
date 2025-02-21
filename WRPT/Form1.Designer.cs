namespace WRPT
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            SaveButton = new ToolStripButton();
            OpenButton = new ToolStripButton();
            ExecuteButton = new ToolStripButton();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { SaveButton, OpenButton, ExecuteButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // SaveButton
            // 
            SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SaveButton.Image = Properties.Resources.save;
            SaveButton.ImageTransparentColor = Color.Magenta;
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(23, 22);
            SaveButton.Text = "Сохранить данные";
            // 
            // OpenButton
            // 
            OpenButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            OpenButton.Image = Properties.Resources.open;
            OpenButton.ImageTransparentColor = Color.Magenta;
            OpenButton.Name = "OpenButton";
            OpenButton.Size = new Size(23, 22);
            OpenButton.Text = "Загрузить данные";
            // 
            // ExecuteButton
            // 
            ExecuteButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ExecuteButton.Image = Properties.Resources.execute;
            ExecuteButton.ImageTransparentColor = Color.Magenta;
            ExecuteButton.Name = "ExecuteButton";
            ExecuteButton.Size = new Size(23, 22);
            ExecuteButton.Text = "Выполнить расчет";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 410);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 382);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Общие данные";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 382);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Параметры вдхр.";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(768, 382);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Батиграфия НБ";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Многолетнее регулирование";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton SaveButton;
        private ToolStripButton OpenButton;
        private ToolStripButton ExecuteButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}
