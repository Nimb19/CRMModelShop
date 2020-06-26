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

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Product> formCatalogProduct = new FormCatalog<Product>(db.Products);
            formCatalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Seller> formCatalogSeller = new FormCatalog<Seller>(db.Sellers);
            formCatalogSeller.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Customer> formCatalogCustomer = new FormCatalog<Customer>(db.Customers);
            formCatalogCustomer.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatalog<Check> formCatalogCheck = new FormCatalog<Check>(db.Checks);
            formCatalogCheck.Show();
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
