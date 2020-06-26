using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите корректное название продукта.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(nUpDownPrice.Value.ToString()))
            {
                MessageBox.Show("Пожалуйста, введите корректную цену продукта.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(string.IsNullOrWhiteSpace(nUpDownCount.Value.ToString()))
            {
                MessageBox.Show("Пожалуйста, введите корректное количество продукта.\n" +
                    "Поле не может быть пустым или состоять только из пробелов.", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product = new Product() 
            { 
                Name = name.Trim(), 
                Price = nUpDownPrice.Value, 
                Count = Convert.ToInt32(nUpDownCount.Value)
            };

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
