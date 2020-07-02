using System;
using System.Windows.Forms;
using CrmBL.Model;

namespace CrmBL
{
    public class CashDescCase
    {
        public CashDesk CashDesk { get; set; }
        public Label LabelCashDesc { get; set; } = new Label();
        public Label LabelCashDescNumber { get; set; } = new Label();
        public Label LabelProfit { get; set; } = new Label();
        public ProgressBar ProgressBarQueues { get; set; } = new ProgressBar();
        public Label LabelCustomers { get; set; } = new Label();
        public Label LabelCustomersNumber { get; set; } = new Label();
        public Label LabelCustomersExit { get; set; } = new Label();
        public Label LabelCustomersExitNumber { get; set; } = new Label();

        public CashDescCase(CashDesk cashDesk, int number, int x, int y)
        {
            this.CashDesk = cashDesk;

            LabelCashDesc.AutoSize = true;
            LabelCashDesc.Location = new System.Drawing.Point(x, y);
            LabelCashDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelCashDesc.Name = "labelProfit" + number;
            LabelCashDesc.Size = new System.Drawing.Size(69, 18);
            LabelCashDesc.TabIndex = number;
            LabelCashDesc.Text = "Касса №";
            
            LabelCashDescNumber.AutoSize = true;
            LabelCashDescNumber.Location = new System.Drawing.Point(x + 77, y);
            LabelCashDescNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelCashDescNumber.Name = "labelCashDescNumber" + number;
            LabelCashDescNumber.Size = new System.Drawing.Size(29, 18);
            LabelCashDescNumber.TabIndex = number;
            LabelCashDescNumber.Text = number.ToString();

            LabelProfit.AutoSize = true;
            LabelProfit.Location = new System.Drawing.Point(x + 131, y);
            LabelProfit.Name = "labelProfit" + number;
            LabelProfit.Size = new System.Drawing.Size(63, 18);
            LabelProfit.TabIndex = number;
            LabelProfit.Text = cashDesk.CountProfit.ToString();

            ProgressBarQueues.Location = new System.Drawing.Point(x + 238, y);
            ProgressBarQueues.Name = "progressBarQueues" + number;
            ProgressBarQueues.Size = new System.Drawing.Size(139, 23);
            ProgressBarQueues.TabIndex = number;
            ProgressBarQueues.Value = 0;
            ProgressBarQueues.Minimum = 0;
            ProgressBarQueues.Maximum = cashDesk.MaxQueueCount;

            LabelCustomers.AutoSize = true;
            LabelCustomers.Location = new System.Drawing.Point(x + 397, y);
            LabelCustomers.Name = "labelCustomers" + number;
            LabelCustomers.Size = new System.Drawing.Size(103, 18);
            LabelCustomers.TabIndex = number;
            LabelCustomers.Text = "Всего клиентов:";

            LabelCustomersNumber.AutoSize = true;
            LabelCustomersNumber.Location = new System.Drawing.Point(x + 520, y);
            LabelCustomersNumber.Name = "labelCustomersNumber" + number;
            LabelCustomersNumber.Size = new System.Drawing.Size(104, 18);
            LabelCustomersNumber.TabIndex = number;
            LabelCustomersNumber.Text = "0";

            LabelCustomersExit.AutoSize = true;
            LabelCustomersExit.Location = new System.Drawing.Point(x + 615, y);
            LabelCustomersExit.Name = "labelCustomersExit" + number;
            LabelCustomersExit.Size = new System.Drawing.Size(121, 18);
            LabelCustomersExit.TabIndex = number;
            LabelCustomersExit.Text = "Число ушедших:";

            LabelCustomersExitNumber.AutoSize = true;
            LabelCustomersExitNumber.Location = new System.Drawing.Point(x + 740, y);
            LabelCustomersExitNumber.Name = "labelCustomersExitNumber" + number;
            LabelCustomersExitNumber.Size = new System.Drawing.Size(94, 18);
            LabelCustomersExitNumber.TabIndex = number;
            LabelCustomersExitNumber.Text = cashDesk.ExitCustomers.ToString();

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            try
            {
                LabelProfit.Invoke((Action)delegate
                {
                    if (sender is CashDesk cashDesk)
                    {
                        LabelProfit.Text = cashDesk.CountProfit.ToString();
                        ProgressBarQueues.Value = cashDesk.Count;
                        LabelCustomersNumber.Text = cashDesk.CountCustomers.ToString();
                        LabelCustomersExitNumber.Text = cashDesk.ExitCustomers.ToString();
                    }
                });
            }
            catch { }
        }
    }
}
