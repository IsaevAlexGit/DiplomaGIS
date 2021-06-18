using System;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;

namespace OptimumPharmacy
{
    public partial class StartForm : Form
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void StartForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(810, 428);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Установка картинки
            pictureBox.Image = Properties.Resources.iconApplication;
            // Выравнивание картинки по центру
            pictureBox.Left = (this.ClientSize.Width - pictureBox.Width) / 2;
            // Визуализация кнопки "Продолжить"
            buttonPDF.FlatAppearance.BorderSize = 0;
            buttonPDF.FlatStyle = FlatStyle.Flat;
            // Визуализация кнопки "Руководство пользователя"
            buttonProceed.FlatAppearance.BorderSize = 0;
            buttonProceed.FlatStyle = FlatStyle.Flat;
            // Настройка выпадающего списка
            comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLanguage.SelectedItem = "Русский";
        }

        private LanguageType _languageOfMap;
        private string _selectedMapLanguage;
        /// <summary>
        /// Переход на главный экран
        /// </summary>
        private void buttonProceed_Click(object sender, EventArgs e)
        {
            _selectedMapLanguage = comboBoxLanguage.Text;
            if (_selectedMapLanguage == "Русский")
            {
                _languageOfMap = LanguageType.Russian;
                Hide();
                MainMap mainForm = new MainMap(_languageOfMap);
                mainForm.ShowDialog();
                Close();
            }
            else
            {
                _languageOfMap = LanguageType.English;
                Hide();
                MainMap mainForm = new MainMap(_languageOfMap);
                mainForm.ShowDialog();
                Close();
            }
        }
        /// <summary>
        /// Открытие руководства пользователя
        /// </summary>
        private void buttonPDF_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\Data\UserManual.pdf");
            }
            catch
            {
                MessageBox.Show("Файл не найден", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Закрыть форму через ESC
        /// </summary>
        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}