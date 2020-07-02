using System;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class RegisterForm : Form
    {
        public string CustomerLogin { get; set; }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var name = tbName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите корректный логин.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CustomerLogin = name;

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
