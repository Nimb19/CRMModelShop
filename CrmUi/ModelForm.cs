using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CrmBL;
using CrmBL.Model;

namespace CrmUI
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model;
        private int _countCashDescks { get; set; }
        private bool isStart { get; set; } = false;

        public ModelForm(int countCashDescks = 3)
        {
            InitializeComponent();
            _countCashDescks = countCashDescks;
            model = new ShopComputerModel(_countCashDescks);
            this.Size = new System.Drawing.Size(875, (30 * (_countCashDescks + 1)) + 120);
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            List<CashDescCase> cashDescCases = new List<CashDescCase>();

            for (int i = 1; i <= model.CountCashDescks; i++)
            {
                var box = new CashDescCase(model.CashDesks[i - 1], i, 28, 30 * i);
                cashDescCases.Add(box);
                this.Controls.Add(box.LabelCashDesc);
                this.Controls.Add(box.LabelCashDescNumber);
                this.Controls.Add(box.LabelProfit);
                this.Controls.Add(box.ProgressBarQueues);
                this.Controls.Add(box.LabelCustomers);
                this.Controls.Add(box.LabelCustomersNumber);
                this.Controls.Add(box.LabelCustomersExit);
                this.Controls.Add(box.LabelCustomersExitNumber);
            }
        }

        private void BtStart_Click(object sender, EventArgs e)
        {
            if (!isStart)
            {
                model.Start();
                isStart = true;
            }
            else
            {
                MessageBox.Show("Процесс моделирования уже запущен.", 
                    "Повторное нажатие кнопки \"Начать\"", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                model.Stop();
                isStart = false;
            }
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStart)
            {
                model.Stop();
                isStart = false;
            }
        }
    }
}
