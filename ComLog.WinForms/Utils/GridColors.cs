using System.Drawing;
using System.Windows.Forms;
using ComLog.Dto.Ext;

namespace ComLog.WinForms.Utils
{
    public static class GridColors
    {
        private static readonly Color UsdColor = Color.FromArgb(204, 255, 204);
        private static readonly Color EurColor = Color.FromArgb(204, 255, 255);
        private static readonly Color GbpColor = Color.FromArgb(255, 204, 153);
        private static readonly Color ChfColor = Color.FromArgb(255, 255, 153);

        public static void SetRowColors(DataGridView dgv)
        {
            if (dgv == null) return;
            var column = dgv.Columns[nameof(TransactionExtDto.CurrencyId)];
            var idxCurrencyId = column?.Index ?? -1;
            column = dgv.Columns[nameof(TransactionExtDto.Debits)];
            var idxDebits = column?.Index ?? -1;
            column = dgv.Columns[nameof(TransactionExtDto.Charges)];
            var idxCharges = column?.Index ?? -1;
            column = dgv.Columns[nameof(AccountExtDto.DeltaBalance)];
            var idxDeltaBalance = column?.Index ?? -1;
            var boldStyle =
                new DataGridViewCellStyle {Font = new Font(dgv.Font, FontStyle.Bold), ForeColor = Color.OrangeRed};

            if (idxCurrencyId < 0) return;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var currencyId = row.Cells[idxCurrencyId].Value.ToString();

                switch (currencyId)
                {
                    case "USD":
                        row.DefaultCellStyle.BackColor = UsdColor;
                        break;
                    case "EUR":
                        row.DefaultCellStyle.BackColor = EurColor;
                        break;
                    case "GBP":
                        row.DefaultCellStyle.BackColor = GbpColor;
                        break;
                    case "CHF":
                        row.DefaultCellStyle.BackColor = ChfColor;
                        break;
                }
                if (idxDebits > -1 && idxCharges > -1)
                {
                    var debits = row.Cells[idxDebits].Value.ToString();
                    var charges = row.Cells[idxCharges].Value.ToString();
                    if (!string.IsNullOrEmpty(debits)) row.Cells[idxDebits].Style.ForeColor = Color.Red;
                    if (!string.IsNullOrEmpty(charges)) row.Cells[idxCharges].Style.ForeColor = Color.Red;
                }
                if (idxDeltaBalance > -1)
                {
                    var deltaBalance = (decimal) row.Cells[idxDeltaBalance].Value;
                    if (deltaBalance != 0)
                        row.Cells[idxDeltaBalance].Style = boldStyle;
                }
            }
        }
    }
}