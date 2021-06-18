using System;
using System.Drawing;
using System.Windows.Forms;

namespace OptimumPharmacy
{
    public partial class SettingRadius : Form
    {
        private MapModel _mapModel;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="mapModel">Объект MapModel</param>
        public SettingRadius(MapModel mapModel)
        {
            _mapModel = mapModel;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void SettingRadius_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(455, 275);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            // Отображение текущего значения радиуса
            textBoxRadius.Text = _mapModel.radiusBufferZone.ToString();
        }

        private bool _flagSaveRadius = false;
        /// <summary>
        /// Установка радиуса буферной зоны и возврат на главное окно
        /// </summary>
        private void InputRadiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если поле не пустое
            if (!string.IsNullOrEmpty(textBoxRadius.Text) && !string.IsNullOrWhiteSpace(textBoxRadius.Text))
            {
                int value;
                bool isInt = int.TryParse(textBoxRadius.Text, out value);
                // Если ввели число
                if (isInt == true)
                {
                    int radiusCircle = Convert.ToInt32(textBoxRadius.Text);
                    // Если длина радиуса входит в диапазон от 300м до 1500м
                    if (radiusCircle >= 300 && radiusCircle <= 1500)
                    {
                        _flagSaveRadius = true;
                        _mapModel.radiusBufferZone = radiusCircle;
                        MessageBox.Show("Радиус поиска успешно сохранен", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                        MessageBox.Show("Радиус должен быть в пределах от 300 до 1500 метров", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Радиус должен быть целым положительным числом", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Задайте радиус окружности", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void SettingRadius_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если пользователь сохранил радиус
            if (_flagSaveRadius == true)
                e.Cancel = false;
            else
            {
                if (MessageBox.Show("Вы не сохранили радиус поиска. Выйти?", "Предупреждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Закрыть форму через ESC
        /// </summary>
        private void SettingRadius_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}