using System;
using System.Drawing;
using System.Windows.Forms;

namespace OptimumPharmacy
{
    public partial class SettingTime : Form
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public SettingTime()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void SettingTime_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(417, 228);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
        }

        public bool exitForm = false;
        public double workTimePharmacy = -100;
        private bool _flagSaveTimeWork = false;
        /// <summary>
        /// Сохранение времени работы аптеки и возврат на главное окно
        /// </summary>
        private void InputTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Введенное время
                string LoadTime = maskedTextBoxTime.Text;
                string[] Time = LoadTime.Split(new char[] { ':' });
                // Получение часов и минут
                double hours = Convert.ToDouble(Time[0]);
                double min = Convert.ToDouble(Time[1]);
                // Проверка валидности введенного времени
                if (hours >= 0 && hours <= 23 && min >= 0 && min <= 59)
                {
                    exitForm = true;
                    _flagSaveTimeWork = true;
                    workTimePharmacy = hours + (min / 100);
                    MessageBox.Show("Время успешно сохранено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                    MessageBox.Show("Такого времени не существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Задайте время работы аптеки", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void SettingTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если пользователь сохранил время
            if (_flagSaveTimeWork == true)
                e.Cancel = false;
            else
            {
                if (MessageBox.Show("Вы не сохранили время работы. Выйти?", "Предупреждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Закрыть форму через ESC
        /// </summary>
        private void SettingTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}