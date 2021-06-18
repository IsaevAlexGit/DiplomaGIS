using System;
using System.Drawing;
using System.Windows.Forms;

namespace OptimumPharmacy
{
    public partial class SettingOptions : Form
    {
        private MapModel _mapModel;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="mapModel">Объект MapModel</param>
        public SettingOptions(MapModel mapModel)
        {
            _mapModel = mapModel;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
        }

        // Отрисовка границ groupbox
        private PaintGroupBoxBorder PaintGroupBoxBorder = new PaintGroupBoxBorder();

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void SettingOptions_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(855, 293);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Отрисовка границ groupbox
            foreach (Control groupbox in Controls)
            {
                GroupBox everyGroupBox = groupbox as GroupBox;
                if (everyGroupBox != null)
                    everyGroupBox.Paint += PaintGroupBoxBorder.groupBox_Paint;
            }

            // Заполнение текстовых полей значениями по умолчанию
            textBoxMaxPharma.Text = _mapModel.maxPharmacy.ToString();
            textBoxColorPharma.Text = _mapModel.numberOfShadesPharmacy.ToString();
            textBoxMaxResidents.Text = _mapModel.maxResidents.ToString();
            textBoxColorResidents.Text = _mapModel.numberOfShadesResidents.ToString();
            textBoxMaxRetired.Text = _mapModel.maxRetired.ToString();
            textBoxColorRetired.Text = _mapModel.numberOfShadesRetired.ToString();
        }

        private bool _flagSaveChanges = false;
        /// <summary>
        /// Подтвердить изменения для всех полей
        /// </summary>
        private void SaveAllParamВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если все поля введены
            if (!string.IsNullOrEmpty(textBoxMaxPharma.Text) && !string.IsNullOrWhiteSpace(textBoxMaxPharma.Text) &&
                !string.IsNullOrEmpty(textBoxColorPharma.Text) && !string.IsNullOrWhiteSpace(textBoxColorPharma.Text) &&
                !string.IsNullOrEmpty(textBoxMaxResidents.Text) && !string.IsNullOrWhiteSpace(textBoxMaxResidents.Text) &&
                !string.IsNullOrEmpty(textBoxColorResidents.Text) && !string.IsNullOrWhiteSpace(textBoxColorResidents.Text) &&
                !string.IsNullOrEmpty(textBoxMaxRetired.Text) && !string.IsNullOrWhiteSpace(textBoxMaxRetired.Text) &&
                !string.IsNullOrEmpty(textBoxColorRetired.Text) && !string.IsNullOrWhiteSpace(textBoxColorRetired.Text))
            {
                bool testForMaxPharma = int.TryParse(textBoxMaxPharma.Text, out int value);
                bool testForColorPharma = int.TryParse(textBoxColorPharma.Text, out value);
                bool testForMaxResidents = int.TryParse(textBoxMaxResidents.Text, out value);
                bool testForColorResidents = int.TryParse(textBoxColorResidents.Text, out value);
                bool testForMaxRetired = int.TryParse(textBoxMaxRetired.Text, out value);
                bool testForColorRetired = int.TryParse(textBoxColorRetired.Text, out value);

                // Если все поля являются числами
                if (testForMaxPharma == true && testForColorPharma == true && testForMaxResidents == true && testForColorResidents == true
                    && testForMaxRetired == true && testForColorRetired == true)
                {
                    int maxPharma = Convert.ToInt32(textBoxMaxPharma.Text);
                    int colorPharma = Convert.ToInt32(textBoxColorPharma.Text);
                    int maxResidents = Convert.ToInt32(textBoxMaxResidents.Text);
                    int colorResidents = Convert.ToInt32(textBoxColorResidents.Text);
                    int maxRetired = Convert.ToInt32(textBoxMaxRetired.Text);
                    int colorRetired = Convert.ToInt32(textBoxColorRetired.Text);

                    if (colorPharma >= 2 && colorPharma <= 10 && colorResidents >= 2 && colorResidents <= 10 && colorRetired >= 2 && colorRetired <= 10)
                    {
                        // Если аптек не больше 50
                        if (maxPharma >= 2 && maxPharma <= 50)
                        {
                            // Если жителей не больше 10 000
                            if (maxResidents >= 1 && maxResidents <= 10000)
                            {
                                // Если пенсионеров не больше 3000
                                if (maxRetired >= 1 && maxRetired <= 3000)
                                {
                                    _mapModel.maxPharmacy = maxPharma;
                                    _mapModel.numberOfShadesPharmacy = colorPharma;
                                    _mapModel.maxResidents = maxResidents;
                                    _mapModel.numberOfShadesResidents = colorResidents;
                                    _mapModel.maxRetired = maxRetired;
                                    _mapModel.numberOfShadesRetired = colorRetired;
                                    // Флажок, что пользователь сохранил данные
                                    _flagSaveChanges = true;
                                    MessageBox.Show("Настройки для раскраски успешно сохранены", "Уведомление",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Close();
                                }
                                else
                                    MessageBox.Show("Максимум для пенсионеров должен быть в пределах от 1 до 3000", "Предупреждение",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                                MessageBox.Show("Максимум для жителей должен быть в пределах от 1 до 10 000", "Предупреждение",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Максимум для аптек должен быть в пределах от 2 до 50", "Предупреждение",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Количество оттенков во всех полях должно быть в пределах от 2 до 10", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Все поля должны быть целыми положительными числами", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void SettingOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если пользователь сохранил параметры для раскраски
            if (_flagSaveChanges == true)
                e.Cancel = false;
            else
            {
                if (MessageBox.Show("Вы не сохранили настройки для раскраски. Выйти?", "Предупреждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Закрыть форму через ESC
        /// </summary>
        private void SettingOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}