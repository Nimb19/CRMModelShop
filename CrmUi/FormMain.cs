using System;
using System.Windows.Forms;

using CrmBL.Model;
using CrmUi.FormsAddingInDB;

namespace CrmUi
{
    public partial class FormMain : Form
    {
        CRMContext db;

        public FormMain()
        {
            InitializeComponent();
            db = new CRMContext();
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
    }
}
