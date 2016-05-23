using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, содержащий форму плагина.
    /// </summary>
    public partial class Form : System.Windows.Forms.Form
    {
        private Manager _manager = new Manager();

        public Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод получения данных о типе клавиатуры из формы.
        /// </summary>
        /// <returns></returns>
        private KeyboardType CheckKeyType()
        {
            if (radioKeyTypeSynth.Checked)
            {
                return KeyboardType.Synth;
            }
            else
            {
                return KeyboardType.Piano;
            }
        }

        /// <summary>
        /// Метод получения данных о количестве клавиш из формы.
        /// </summary>
        /// <returns></returns>
        private KeysAmountMode CheckKeyAmount()
        {
            if (radioKeyAmount61.Checked)
            {
                return KeysAmountMode.Low;
            }
            else if (radioKeyAmount76.Checked)
            {
                return KeysAmountMode.Middle;
            }
            else
            {
                return KeysAmountMode.High;
            }
        }

        /// <summary>
        /// Метод обработки события нажатия кнопки "Построить".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (TextValid(textBodyLength,
                textBodyHeight,
                textBodyDepth,
                textCommutationXLRSockets,
                textCommutationTRSSockets,
                textCommutationMIDISockets))
            {
                // Запись введенных данных.
                try
                {
                    _manager.KeyboardData.Record(Convert.ToDouble(textBodyLength.Text),
                        Convert.ToDouble(textBodyHeight.Text),
                        Convert.ToDouble(textBodyDepth.Text),
                        checkPanelDisplay.Checked,
                        checkPanelButtons.Checked,
                        checkPanelKnobs.Checked,
                        checkPanelWheel.Checked,
                        Convert.ToInt32(textCommutationXLRSockets.Text),
                        Convert.ToInt32(textCommutationTRSSockets.Text),
                        Convert.ToInt32(textCommutationMIDISockets.Text),
                        CheckKeyType(), CheckKeyAmount());
                    _manager.KeyboardKompas.CreateDocument();
                    _manager.ModelBuild();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Неверно задан параметр.");
                }
                
            }
        }

        /// <summary>
        /// Метод проверки формы на корректность форматирования введенных
        /// пользователем данных.
        /// </summary>
        /// <param name="tbLength">Длина корпуса.</param>
        /// <param name="tbHeight">Высота корпуса.</param>
        /// <param name="tbDepth">Глубина корпуса.</param>
        /// <param name="tbXLR">Количество разъемов XLR.</param>
        /// <param name="tbTRS">Количество разъемов TRS.</param>
        /// <param name="tbMIDI">Количество разъемов MIDI.</param>
        /// <returns></returns>
        private bool TextValid(TextBox tbLength, TextBox tbHeight,
            TextBox tbDepth, TextBox tbXLR, TextBox tbTRS, TextBox tbMIDI)
        {
            if (!TextValidRegularExpression(tbLength.Text))
            {
                MessageBox.Show("Текстовое поле \"Длина корпуса\" заполнено некорректно.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!TextValidRegularExpression(tbHeight.Text))
            {
                MessageBox.Show("Текстовое поле \"Высота корпуса\" заполнено некорректно.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!TextValidRegularExpression(tbDepth.Text))
            {
                MessageBox.Show("Текстовое поле \"Высота корпуса\" заполнено некорректно.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!TextValidRegularExpression(tbXLR.Text))
            {
                MessageBox.Show("Текстовое поле \"Количество разъемов XLR\" заполнено некорректно.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!TextValidRegularExpression(tbTRS.Text))
            {
                MessageBox.Show("Текстовое поле \"Количество разъемов TRS\" заполнено некорректно.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!TextValidRegularExpression(tbMIDI.Text))
            {
                MessageBox.Show("Текстовое поле \"Количество разъемов MIDI\" заполнено некорректно.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Метод обработки события нажатия кнопки "Запустить KOMPAS-3D".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenKompas_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.OpenKompas();
            }
            catch (Exception)
            {
                _manager.KsObjectSetNull();
                _manager.OpenKompas();
            }
        }

        /// <summary>
        /// Метод проверки соответствия введенной строки регулярному выражению.
        /// </summary>
        /// <param name="text">Входная строка</param>
        /// <returns></returns>
        private bool TextValidRegularExpression(string text)
        {
            Regex sample = new Regex(@"\-?\d+(\.\d{0,})?");
            if (sample.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
