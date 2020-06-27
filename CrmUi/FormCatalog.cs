using System;
using System.Data.Entity;
using System.Windows.Forms;

using CrmBL.Model;
using CrmUi.FormsAddingInDB;

namespace CrmUi
{
    public partial class FormCatalog<T> : Form
        where T : class
    {
        CRMContext db;
        DbSet<T> dbSet;

        public FormCatalog(DbSet<T> dbSet, CRMContext db)
        {
            InitializeComponent();

            this.db = db;
            this.dbSet = dbSet;

            dbSet.Load();
            dataGridView.DataSource = dbSet.Local.ToBindingList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {

        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            var id = (int)dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = dbSet.Find(id) as Product;
                FormProduct formProduct = new FormProduct(product);
                if (formProduct.ShowDialog() == DialogResult.OK)
                {
                    product = formProduct.Product;
                    db.SaveChanges();
                    dataGridView.Refresh();
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = dbSet.Find(id) as Seller;
                FormSeller formSeller = new FormSeller(seller);
                if (formSeller.ShowDialog() == DialogResult.OK)
                {
                    seller = formSeller.Seller;
                    db.SaveChanges();
                    dataGridView.Refresh();
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = dbSet.Find(id) as Customer;
                FormCustomer formCustomer = new FormCustomer(customer);
                if (formCustomer.ShowDialog() == DialogResult.OK)
                {
                    customer = formCustomer.Customer;
                    db.SaveChanges();
                    dataGridView.Refresh();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
