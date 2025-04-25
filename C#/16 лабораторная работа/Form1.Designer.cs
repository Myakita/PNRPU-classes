namespace _16_лабораторная_работа
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
            Console = new RichTextBox();
            OptionBox = new ComboBox();
            SaveButton = new Button();
            LoadButton = new Button();
            label1 = new Label();
            GenerationBox = new TextBox();
            MeasureButton = new Button();
            LogButton = new Button();
            Linq1 = new Button();
            Linq2 = new Button();
            Linq3 = new Button();
            button1 = new Button();
            DeleteBox = new TextBox();
            SearchBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // Console
            // 
            Console.Location = new Point(12, 20);
            Console.Name = "Console";
            Console.Size = new Size(392, 284);
            Console.TabIndex = 0;
            Console.Text = "";
            // 
            // OptionBox
            // 
            OptionBox.FormattingEnabled = true;
            OptionBox.Items.AddRange(new object[] { "JSON", "XML", "Binary" });
            OptionBox.Location = new Point(12, 310);
            OptionBox.Name = "OptionBox";
            OptionBox.Size = new Size(211, 29);
            OptionBox.TabIndex = 1;
            OptionBox.Text = "JSON";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(12, 360);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += button1_Click;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(129, 360);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(94, 29);
            LoadButton.TabIndex = 3;
            LoadButton.Text = "Загрузить";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(448, 9);
            label1.Name = "label1";
            label1.Size = new Size(308, 21);
            label1.TabIndex = 4;
            label1.Text = "Введите кол-во элементов для генерации";
            // 
            // GenerationBox
            // 
            GenerationBox.Location = new Point(448, 44);
            GenerationBox.Name = "GenerationBox";
            GenerationBox.Size = new Size(308, 29);
            GenerationBox.TabIndex = 5;
            GenerationBox.KeyUp += textBox1_KeyUp;
            // 
            // MeasureButton
            // 
            MeasureButton.Location = new Point(12, 409);
            MeasureButton.Name = "MeasureButton";
            MeasureButton.Size = new Size(211, 29);
            MeasureButton.TabIndex = 6;
            MeasureButton.Text = "Замер  времени";
            MeasureButton.UseVisualStyleBackColor = true;
            MeasureButton.Click += button3_Click;
            // 
            // LogButton
            // 
            LogButton.Location = new Point(258, 310);
            LogButton.Name = "LogButton";
            LogButton.Size = new Size(94, 29);
            LogButton.TabIndex = 7;
            LogButton.Text = "Логи";
            LogButton.UseVisualStyleBackColor = true;
            LogButton.Click += button4_Click;
            // 
            // Linq1
            // 
            Linq1.Location = new Point(448, 256);
            Linq1.Name = "Linq1";
            Linq1.Size = new Size(308, 29);
            Linq1.TabIndex = 8;
            Linq1.Text = "Корабли с водоизмещением > 7500";
            Linq1.UseVisualStyleBackColor = true;
            Linq1.Click += button5_Click;
            // 
            // Linq2
            // 
            Linq2.Location = new Point(448, 309);
            Linq2.Name = "Linq2";
            Linq2.Size = new Size(308, 29);
            Linq2.TabIndex = 9;
            Linq2.Text = "Корабли с мощностью > 1500 лс";
            Linq2.UseVisualStyleBackColor = true;
            Linq2.Click += button6_Click;
            // 
            // Linq3
            // 
            Linq3.Location = new Point(448, 360);
            Linq3.Name = "Linq3";
            Linq3.Size = new Size(308, 29);
            Linq3.TabIndex = 10;
            Linq3.Text = "Корабли с командой > 250 человек";
            Linq3.UseVisualStyleBackColor = true;
            Linq3.Click += button7_Click;
            // 
            // button1
            // 
            button1.Location = new Point(448, 88);
            button1.Name = "button1";
            button1.Size = new Size(308, 54);
            button1.TabIndex = 11;
            button1.Text = "Вывести коллекцию";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // DeleteBox
            // 
            DeleteBox.Location = new Point(448, 159);
            DeleteBox.Name = "DeleteBox";
            DeleteBox.Size = new Size(125, 29);
            DeleteBox.TabIndex = 12;
            DeleteBox.KeyUp += DeleteBox_KeyUp;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(448, 207);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(125, 29);
            SearchBox.TabIndex = 13;
            SearchBox.KeyUp += SearchBox_KeyUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(588, 162);
            label2.Name = "label2";
            label2.Size = new Size(144, 21);
            label2.TabIndex = 14;
            label2.Text = "Удалить(название)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(588, 210);
            label3.Name = "label3";
            label3.Size = new Size(130, 21);
            label3.TabIndex = 15;
            label3.Text = "Поиск(название)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(SearchBox);
            Controls.Add(DeleteBox);
            Controls.Add(button1);
            Controls.Add(Linq3);
            Controls.Add(Linq2);
            Controls.Add(Linq1);
            Controls.Add(LogButton);
            Controls.Add(MeasureButton);
            Controls.Add(GenerationBox);
            Controls.Add(label1);
            Controls.Add(LoadButton);
            Controls.Add(SaveButton);
            Controls.Add(OptionBox);
            Controls.Add(Console);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "16 лаба";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox Console;
        private ComboBox OptionBox;
        private Button SaveButton;
        private Button LoadButton;
        private Label label1;
        private TextBox GenerationBox;
        private Button MeasureButton;
        private Button LogButton;
        private Button Linq1;
        private Button Linq2;
        private Button Linq3;
        private Button button1;
        private TextBox DeleteBox;
        private TextBox SearchBox;
        private Label label2;
        private Label label3;
    }
}
