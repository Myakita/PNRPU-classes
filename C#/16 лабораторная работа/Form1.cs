using System;
using System.Windows.Forms;
using System.IO;

namespace _16_лабораторная_работа
{
    public partial class Form1 : Form
    {
        private readonly Form1Logic logic = new Form1Logic();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logic.GenerateShips(GenerationBox.Text);
                ShowTable();
            }
        }

        private void ShowTable()
        {
            Console.Clear();
            foreach (var line in logic.GetTableLines())
                Console.AppendText(line);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Все файлы|*.*";
                sfd.AddExtension = true;
                sfd.DefaultExt = logic.GetExtension(OptionBox.Text).TrimStart('.');
                sfd.FileName = "ships" + logic.GetExtension(OptionBox.Text);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = Path.ChangeExtension(sfd.FileName, logic.GetExtension(OptionBox.Text));
                    logic.SaveToFile(filePath, OptionBox.Text);
                    MessageBox.Show("Коллекция сохранена.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = OptionBox.Text switch
                {
                    "XML" => "XML файлы|*.xml",
                    "Binary" => "Бинарные файлы|*.bin",
                    _ => "JSON файлы|*.json"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.LoadFromFile(ofd.FileName, OptionBox.Text);
                        ShowTable();
                        MessageBox.Show("Коллекция загружена.");
                    }
                    catch (Exception ex)
                    {
                        logic.LogJournal.Add($"Ошибка загрузки: {ex.Message}");
                        MessageBox.Show("Ошибка загрузки: " + ex.Message);
                    }
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (logic.TableCount == 0)
            {
                MessageBox.Show("Сначала сгенерируйте коллекцию.");
                return;
            }

            string filePath = Path.Combine(Path.GetTempPath(), "ships_test" + logic.GetExtension(OptionBox.Text));
            var lines = await logic.MeasureSerializationAsync(filePath, OptionBox.Text);

            foreach (var line in lines)
                Console.AppendText(line);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Clear();
            foreach (var line in logic.GetLogLines())
                Console.AppendText(line);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.Clear();
            foreach (var line in logic.GetLinqDisplacementLines())
                Console.AppendText(line);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.Clear();
            foreach (var line in logic.GetLinqEnginePowerLines())
                Console.AppendText(line);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.Clear();
            foreach (var line in logic.GetLinqCrewSizeLines())
                Console.AppendText(line);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowTable();
            logic.LogJournal.Add("Показана текущая коллекция.");
        }

        private void DeleteBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string key = DeleteBox.Text.Trim();
                if (string.IsNullOrEmpty(key))
                    return;

                foreach (var line in logic.RemoveShipAndGetLines(key))
                    Console.AppendText(line);

                ShowTable();
                DeleteBox.Clear();
            }
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string key = SearchBox.Text.Trim();
                if (string.IsNullOrEmpty(key))
                    return;

                Console.Clear();
                foreach (var line in logic.SearchShipLines(key))
                    Console.AppendText(line);

                SearchBox.Clear();
            }
        }
    }
}
