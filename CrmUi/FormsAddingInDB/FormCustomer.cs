using System;
using System.Windows.Forms;

using CrmBL.Model;

namespace CrmUi.FormsAddingInDB
{
    public partial class FormCustomer : Form
    {
        public Customer Customer { get; set; }

        public FormCustomer()
        {
            InitializeComponent();
        }

        public FormCustomer(Customer customer) : this()
        {
            Customer = customer;
            tbName.Text = customer.Name;

            this.buttonAdd.Text = "Изменить";
            this.Text = "Форма изменения данных о покупателе";
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите корректное имя покупателя.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer = Customer ?? new Customer();
            Customer.Name = name.Trim();

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
