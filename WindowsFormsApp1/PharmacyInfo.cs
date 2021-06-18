using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace OptimumPharmacy
{
    public partial class PharmacyInfo : Form
    {
        private Pharmacy _infoPharmacy = new Pharmacy();

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="place">Аптека, по которой кликнули</param>
        public PharmacyInfo(Pharmacy pharmacy)
        {
            _infoPharmacy = pharmacy;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
        }

        // Отрисовка границ groupbox
        private PaintGroupBoxBorder _paintGroupBoxBorder = new PaintGroupBoxBorder();

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void PharmacyInfo_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(710, 300);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            foreach (Control groupbox in Controls)
            {
                GroupBox everyGroupBox = groupbox as GroupBox;
                if (everyGroupBox != null)
                    everyGroupBox.Paint += _paintGroupBoxBorder.groupBox_Paint;
            }

            // Вывод данных об аптеке в label
            label_CityPharmacy.Text = _infoPharmacy.city;
            label_NamePharmacy.Text = _infoPharmacy.namePharmacy;
            label_AddressPharmacy.Text = _infoPharmacy.address;
            label_PhonePharmacy.Text = _infoPharmacy.phone;

            if (_infoPharmacy.site.Length <= 50)
                label_SitePharmacy.AutoSize = true;
            else
                label_SitePharmacy.AutoSize = false;
            label_SitePharmacy.Text = _infoPharmacy.site;

            // Время открытия и закрытия аптеки
            double Open = _infoPharmacy.timeOpening;
            double Close = _infoPharmacy.timeClosing;

            // Если неизвестно время работы
            if (Open == -1.0 && Close == -1.0)
                label_TimePharmacy.Text = "неизвестно";
            // Если аптека работает круглосуточно
            else if (Open == 0.0 && Close == 25.0)
                label_TimePharmacy.Text = "круглосуточно";
            // Если есть время
            else
            {
                double OpenInt = Open * 10;
                double CloseInt = Close * 10;
                // Последние цифры времени (часы и минуты)
                int EndOpen = Convert.ToInt32(OpenInt) % 10;
                int EndClose = Convert.ToInt32(CloseInt) % 10;

                // 07:00-20:00
                if (EndOpen == 0 && EndClose == 0)
                {
                    if (Open <= 9)
                        label_TimePharmacy.Text = "0" + Open + ":00-" + Close + ":00";
                    else
                        label_TimePharmacy.Text = Open + ":00-" + Close + ":00";
                }
                // 07:00-21:30
                else if (EndOpen == 0 && EndClose == 5)
                {
                    Close = Close - 0.5;
                    if (Open <= 9)
                        label_TimePharmacy.Text = "0" + Open + ":00-" + Close + ":30";
                    else
                        label_TimePharmacy.Text = Open + ":00-" + Close + ":30";
                }
                // 07:30-21:00
                else if (EndOpen == 5 && EndClose == 0)
                {
                    Open = Open - 0.5;
                    if (Open <= 9)
                        label_TimePharmacy.Text = "0" + Open + ":30-" + Close + ":00";
                    else
                        label_TimePharmacy.Text = Open + ":30-" + Close + ":00";
                }
                // 07:30-21:30
                else if (EndOpen == 5 && EndClose == 5)
                {
                    Open = Open - 0.5;
                    Close = Close - 0.5;
                    if (Open <= 9)
                        label_TimePharmacy.Text = "0" + Open + ":30-" + Close + ":30";
                    else
                        label_TimePharmacy.Text = Open + ":30-" + Close + ":30";
                }
                // Неизвестно (в случае некорректных данных пользователя)
                else
                    label_TimePharmacy.Text = "неизвестно";
            }
        }

        /// <summary>
        /// Обработка щелчка по сайту
        /// </summary>
        private void labelSite_DoubleClick(object sender, EventArgs e)
        {
            // Если у пользователя в загруженных данных нельзя перейти по ссылке
            try
            {
                string SiteOfPharmacy = label_SitePharmacy.Text;
                // Попытка открыть браузер и перейти на сайт аптеки
                if (SiteOfPharmacy == "отсутствует")
                    MessageBox.Show("Информации о сайте аптеки нет", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Process.Start(SiteOfPharmacy);
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке сайта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Закрыть форму через ESC
        /// </summary>
        private void PharmacyInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}