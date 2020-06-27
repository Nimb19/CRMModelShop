using System;
using System.Windows.Forms;

using CrmBL.Model;

namespace CrmUi.FormsAddingInDB
{
    public partial class FormProduct : Form
    {
        public Product Product { get; set; }

        public FormProduct()
        {
            InitializeComponent();
        }

        public FormProduct(Product product) : this()
        {
            Product = product;
            tbName.Text = product.Name;
            nUpDownPrice.Value = product.Price;
            nUpDownCount.Value = product.Count;

            this.buttonAdd.Text = "Изменить продукт";
            this.Text = "Форма изменения данных о продукте";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!CheckValidation())
            {
                return;
            }

            var p = Product ?? new Product();
            p.Name = tbName.Text.Trim();
            p.Price = nUpDownPrice.Value;
            p.Count = Convert.ToInt32(nUpDownCount.Value);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private bool CheckValidation()
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректное название продукта.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(nUpDownPrice.Value.ToString()))
            {
                MessageBox.Show("Пожалуйста, введите корректную цену продукта.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(nUpDownCount.Value.ToString()))
            {
                MessageBox.Show("Пожалуйста, введите корректное количество продукта.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
