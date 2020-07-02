using System;
using System.Linq;
using System.Windows.Forms;

using CrmBL.Model;
using CrmUi.FormsAddingInDB;
using CrmUI;

namespace CrmUi
{
    public partial class FormMain : Form
    {
        CRMContext db;
        Customer Customer;
        CashDesk cashDesk;
        Cart Cart;
        public FormMain()
        {
            InitializeComponent();
            db = new CRMContext();
            cashDesk = new CashDesk(1, db.Sellers.FirstOrDefault(), db, 10, false);
        }

        // Блок вывода таблиц из базы данных о продукте, продавце, покупателе и чеке
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Product> formCatalogProduct = new FormCatalog<Product>(db.Products, db);
            formCatalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Seller> formCatalogSeller = new FormCatalog<Seller>(db.Sellers, db);
            formCatalogSeller.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Customer> formCatalogCustomer = new FormCatalog<Customer>(db.Customers, db);
            formCatalogCustomer.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Check> formCatalogCheck = new FormCatalog<Check>(db.Checks, db);
            formCatalogCheck.Show();
        }

        // Блок вывода окон добавления в базу данные о продукте, продавце и покупателе
        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProduct = new FormProduct();
            if (formProduct.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(formProduct.Product);
                db.SaveChanges();
            }
        }

        private void SellerAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSeller = new FormSeller();
            if (formSeller.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(formSeller.Seller);
                db.SaveChanges();
            }
        }

        private void CustomerAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCustomer = new FormCustomer();
            if (formCustomer.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(formCustomer.Customer);
                db.SaveChanges();
            }
        }

        private void ComputerModetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelForm modelForm = new ModelForm(10);
            modelForm.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var listProducts = db.Products;
            foreach (var product in listProducts)
            {
                lbProducts.Items.Add(product);
            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            var listProducts = db.Products;
            lbProducts.Items.Clear();
            foreach (var product in listProducts)
            {
                lbProducts.Items.Add(product);
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                var customerLog = db.Customers.FirstOrDefault(n => n.Name == registerForm.CustomerLogin);
                if (customerLog != null)
                {
                    Customer = customerLog;
                }
                else
                {
                    Customer = new Customer()
                    {
                        Name = registerForm.CustomerLogin
                    };
                    db.Customers.Add(Customer);
                    db.SaveChanges();
                }

                linkLabel.Text = $"Здравствуйте, {Customer.Name}!";
            }
        }

        private void BPay_Click(object sender, EventArgs e)
        {
            if (Customer == null)
            {
                MessageBox.Show("Вы не авторизованы. Пожалуйста, авторизуйтесь.", 
                    "Ошибка идентификации пользователя", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cart = new Cart(Customer);
            foreach (Product product in lbCart.Items)
            {
                Cart.Add(product);
            }
            cashDesk.Enqueue(Cart);
            var check = cashDesk.Dequeue();

            string textCheck = $"CRMModel магазин!\n" +
                $"Дата покупки {check.DataCreated}\n" +
                $"Покупатель {check.Customer}\n" +
                $"Приобретённые товары: \n";

            foreach (var sell in check.Sells)
            {
                textCheck += "\t" + sell.Product.Name + "\tЦена: " + sell.Product.Price + "\n";
            }

            textCheck += 
                $"Итоговая цена: {check.Price}\n" +
                $"\n" +
                $"Спасибо а покупку!";

            lbCart.Items.Clear();

            MessageBox.Show(textCheck, "Чек", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lbProducts_DoubleClick(object sender, EventArgs e)
        {
            if (lbProducts.SelectedItem is Product product)
            {
                lbCart.Items.Add(product);

                decimal AllCosts = Convert.ToDecimal(labelCost.Text);
                AllCosts += product.Price;
                labelCost.Text = AllCosts.ToString();
            }
        }
    }
}
