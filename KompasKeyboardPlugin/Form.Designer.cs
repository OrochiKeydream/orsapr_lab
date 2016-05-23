namespace KompasKeyboardPlugin
{
    partial class Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBodyDepth = new System.Windows.Forms.TextBox();
            this.textBodyHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBodyLength = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioKeyAmount61 = new System.Windows.Forms.RadioButton();
            this.radioKeyAmount76 = new System.Windows.Forms.RadioButton();
            this.radioKeyAmount88 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioKeyTypeSynth = new System.Windows.Forms.RadioButton();
            this.radioKeyTypePiano = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkPanelButtons = new System.Windows.Forms.CheckBox();
            this.checkPanelKnobs = new System.Windows.Forms.CheckBox();
            this.checkPanelDisplay = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textCommutationMIDISockets = new System.Windows.Forms.TextBox();
            this.textCommutationTRSSockets = new System.Windows.Forms.TextBox();
            this.textCommutationXLRSockets = new System.Windows.Forms.TextBox();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.buttonOpenKompas = new System.Windows.Forms.Button();
            this.checkPanelWheel = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBodyDepth);
            this.groupBox1.Controls.Add(this.textBodyHeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBodyLength);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры корпуса";
            // 
            // textBodyDepth
            // 
            this.textBodyDepth.Location = new System.Drawing.Point(118, 72);
            this.textBodyDepth.Name = "textBodyDepth";
            this.textBodyDepth.Size = new System.Drawing.Size(100, 20);
            this.textBodyDepth.TabIndex = 7;
            this.textBodyDepth.Text = "30";
            // 
            // textBodyHeight
            // 
            this.textBodyHeight.Location = new System.Drawing.Point(118, 46);
            this.textBodyHeight.Name = "textBodyHeight";
            this.textBodyHeight.Size = new System.Drawing.Size(100, 20);
            this.textBodyHeight.TabIndex = 5;
            this.textBodyHeight.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Глубина корпуса";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Высота корпуса";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Длина корпуса";
            // 
            // textBodyLength
            // 
            this.textBodyLength.Location = new System.Drawing.Point(118, 19);
            this.textBodyLength.Name = "textBodyLength";
            this.textBodyLength.Size = new System.Drawing.Size(100, 20);
            this.textBodyLength.TabIndex = 0;
            this.textBodyLength.Text = "130";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры  клавиатуры";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioKeyAmount61);
            this.groupBox6.Controls.Add(this.radioKeyAmount76);
            this.groupBox6.Controls.Add(this.radioKeyAmount88);
            this.groupBox6.Location = new System.Drawing.Point(6, 74);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(169, 48);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Количество клавиш";
            // 
            // radioKeyAmount61
            // 
            this.radioKeyAmount61.AutoSize = true;
            this.radioKeyAmount61.Location = new System.Drawing.Point(6, 19);
            this.radioKeyAmount61.Name = "radioKeyAmount61";
            this.radioKeyAmount61.Size = new System.Drawing.Size(37, 17);
            this.radioKeyAmount61.TabIndex = 4;
            this.radioKeyAmount61.Text = "61";
            this.radioKeyAmount61.UseVisualStyleBackColor = true;
            // 
            // radioKeyAmount76
            // 
            this.radioKeyAmount76.AutoSize = true;
            this.radioKeyAmount76.Location = new System.Drawing.Point(49, 19);
            this.radioKeyAmount76.Name = "radioKeyAmount76";
            this.radioKeyAmount76.Size = new System.Drawing.Size(37, 17);
            this.radioKeyAmount76.TabIndex = 5;
            this.radioKeyAmount76.Text = "76";
            this.radioKeyAmount76.UseVisualStyleBackColor = true;
            // 
            // radioKeyAmount88
            // 
            this.radioKeyAmount88.AutoSize = true;
            this.radioKeyAmount88.Checked = true;
            this.radioKeyAmount88.Location = new System.Drawing.Point(96, 19);
            this.radioKeyAmount88.Name = "radioKeyAmount88";
            this.radioKeyAmount88.Size = new System.Drawing.Size(37, 17);
            this.radioKeyAmount88.TabIndex = 6;
            this.radioKeyAmount88.TabStop = true;
            this.radioKeyAmount88.Text = "88";
            this.radioKeyAmount88.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioKeyTypeSynth);
            this.groupBox5.Controls.Add(this.radioKeyTypePiano);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(169, 49);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Тип клавиатуры";
            // 
            // radioKeyTypeSynth
            // 
            this.radioKeyTypeSynth.AutoSize = true;
            this.radioKeyTypeSynth.Location = new System.Drawing.Point(6, 19);
            this.radioKeyTypeSynth.Name = "radioKeyTypeSynth";
            this.radioKeyTypeSynth.Size = new System.Drawing.Size(84, 17);
            this.radioKeyTypeSynth.TabIndex = 0;
            this.radioKeyTypeSynth.Text = "Синтезатор";
            this.radioKeyTypeSynth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioKeyTypeSynth.UseVisualStyleBackColor = true;
            // 
            // radioKeyTypePiano
            // 
            this.radioKeyTypePiano.AutoSize = true;
            this.radioKeyTypePiano.Checked = true;
            this.radioKeyTypePiano.Location = new System.Drawing.Point(96, 19);
            this.radioKeyTypePiano.Name = "radioKeyTypePiano";
            this.radioKeyTypePiano.Size = new System.Drawing.Size(69, 17);
            this.radioKeyTypePiano.TabIndex = 2;
            this.radioKeyTypePiano.TabStop = true;
            this.radioKeyTypePiano.Text = "Пианино";
            this.radioKeyTypePiano.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkPanelWheel);
            this.groupBox3.Controls.Add(this.checkPanelButtons);
            this.groupBox3.Controls.Add(this.checkPanelKnobs);
            this.groupBox3.Controls.Add(this.checkPanelDisplay);
            this.groupBox3.Location = new System.Drawing.Point(12, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 71);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры панели управления";
            // 
            // checkPanelButtons
            // 
            this.checkPanelButtons.AutoSize = true;
            this.checkPanelButtons.Checked = true;
            this.checkPanelButtons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPanelButtons.Location = new System.Drawing.Point(144, 19);
            this.checkPanelButtons.Name = "checkPanelButtons";
            this.checkPanelButtons.Size = new System.Drawing.Size(63, 17);
            this.checkPanelButtons.TabIndex = 2;
            this.checkPanelButtons.Text = "Кнопки";
            this.checkPanelButtons.UseVisualStyleBackColor = true;
            // 
            // checkPanelKnobs
            // 
            this.checkPanelKnobs.AutoSize = true;
            this.checkPanelKnobs.Checked = true;
            this.checkPanelKnobs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPanelKnobs.Location = new System.Drawing.Point(83, 19);
            this.checkPanelKnobs.Name = "checkPanelKnobs";
            this.checkPanelKnobs.Size = new System.Drawing.Size(55, 17);
            this.checkPanelKnobs.TabIndex = 1;
            this.checkPanelKnobs.Text = "Ручки";
            this.checkPanelKnobs.UseVisualStyleBackColor = true;
            // 
            // checkPanelDisplay
            // 
            this.checkPanelDisplay.AutoSize = true;
            this.checkPanelDisplay.Checked = true;
            this.checkPanelDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPanelDisplay.Location = new System.Drawing.Point(6, 19);
            this.checkPanelDisplay.Name = "checkPanelDisplay";
            this.checkPanelDisplay.Size = new System.Drawing.Size(71, 17);
            this.checkPanelDisplay.TabIndex = 0;
            this.checkPanelDisplay.Text = "Дисплей";
            this.checkPanelDisplay.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textCommutationMIDISockets);
            this.groupBox4.Controls.Add(this.textCommutationTRSSockets);
            this.groupBox4.Controls.Add(this.textCommutationXLRSockets);
            this.groupBox4.Location = new System.Drawing.Point(12, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 102);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры коммутационной панели";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Количество разъемов MIDI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Количество разъемов TRS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Количество разъемов XLR";
            // 
            // textCommutationMIDISockets
            // 
            this.textCommutationMIDISockets.Location = new System.Drawing.Point(170, 71);
            this.textCommutationMIDISockets.Name = "textCommutationMIDISockets";
            this.textCommutationMIDISockets.Size = new System.Drawing.Size(100, 20);
            this.textCommutationMIDISockets.TabIndex = 2;
            this.textCommutationMIDISockets.Text = "3";
            // 
            // textCommutationTRSSockets
            // 
            this.textCommutationTRSSockets.Location = new System.Drawing.Point(170, 45);
            this.textCommutationTRSSockets.Name = "textCommutationTRSSockets";
            this.textCommutationTRSSockets.Size = new System.Drawing.Size(100, 20);
            this.textCommutationTRSSockets.TabIndex = 1;
            this.textCommutationTRSSockets.Text = "4";
            // 
            // textCommutationXLRSockets
            // 
            this.textCommutationXLRSockets.Location = new System.Drawing.Point(170, 19);
            this.textCommutationXLRSockets.Name = "textCommutationXLRSockets";
            this.textCommutationXLRSockets.Size = new System.Drawing.Size(100, 20);
            this.textCommutationXLRSockets.TabIndex = 0;
            this.textCommutationXLRSockets.Text = "2";
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(12, 441);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(75, 23);
            this.buttonBuild.TabIndex = 4;
            this.buttonBuild.Text = "Построить";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // buttonOpenKompas
            // 
            this.buttonOpenKompas.Location = new System.Drawing.Point(156, 441);
            this.buttonOpenKompas.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenKompas.Name = "buttonOpenKompas";
            this.buttonOpenKompas.Size = new System.Drawing.Size(136, 23);
            this.buttonOpenKompas.TabIndex = 5;
            this.buttonOpenKompas.Text = "Запустить KOMPAS 3D";
            this.buttonOpenKompas.UseVisualStyleBackColor = true;
            this.buttonOpenKompas.Click += new System.EventHandler(this.buttonOpenKompas_Click);
            // 
            // checkPanelWheel
            // 
            this.checkPanelWheel.AutoSize = true;
            this.checkPanelWheel.Checked = true;
            this.checkPanelWheel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPanelWheel.Location = new System.Drawing.Point(6, 43);
            this.checkPanelWheel.Name = "checkPanelWheel";
            this.checkPanelWheel.Size = new System.Drawing.Size(121, 17);
            this.checkPanelWheel.TabIndex = 3;
            this.checkPanelWheel.Text = "Колесо модуляции";
            this.checkPanelWheel.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 473);
            this.Controls.Add(this.buttonOpenKompas);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form";
            this.Text = "Kompas Keyboard Plugin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBodyLength;
        private System.Windows.Forms.TextBox textBodyHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBodyDepth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioKeyAmount88;
        private System.Windows.Forms.RadioButton radioKeyTypePiano;
        private System.Windows.Forms.RadioButton radioKeyTypeSynth;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkPanelButtons;
        private System.Windows.Forms.CheckBox checkPanelKnobs;
        private System.Windows.Forms.CheckBox checkPanelDisplay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCommutationMIDISockets;
        private System.Windows.Forms.TextBox textCommutationTRSSockets;
        private System.Windows.Forms.TextBox textCommutationXLRSockets;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioKeyAmount61;
        private System.Windows.Forms.RadioButton radioKeyAmount76;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Button buttonOpenKompas;
        private System.Windows.Forms.CheckBox checkPanelWheel;
    }
}

