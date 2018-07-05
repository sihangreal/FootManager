using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Core;

namespace ClockRoomManager.UI
{
    public partial class PayOrderForm : DevExpress.XtraEditors.XtraForm
    {
        private List<TempOrderVo> tempOrderList;//单
        public List<TempOrderVo> TempOrderList { set { tempOrderList = value; } }
        private int iType;//轮钟0，点钟1， 加钟2
        public int IType { set { iType = value; } }

        public PayOrderForm()
        {
            InitializeComponent();
            InitEvents();
        }
        private void InitEvents()
        {
            this.Load += PayOrderForm_Load;
            this.comboType.SelectedValueChanged += ComboType_SelectedValueChanged;
            this.btnReadCard.Click += BtnReadCard_Click;
        }

        private void FillComType()
        {
            this.comboType.Properties.Items.AddRange(new string[] { "现金", "Visa卡" });
            List<CardVo> cardList = new List<CardVo>();
            SelectDao.SelectData<CardVo>(ref cardList);
            foreach (CardVo vo in cardList)
            {
                if (vo.DisCount > 0)
                    this.comboType.Properties.Items.Add(vo.CardName);
            }
            this.comboType.SelectedIndex = 0;
        }
       
        #region events
        private void PayOrderForm_Load(object sender, EventArgs e)
        {
            FillComType();
        }
        private void ComboType_SelectedValueChanged(object sender, EventArgs e)
        {
            double serverPrice=0;
            double gstPrice = 0;
            double totalPrice = 0;
            string priceType = this.comboType.Text;
            foreach(TempOrderVo vo in tempOrderList)
            {
                serverPrice +=SelectDao.GetSkillPriceDetail(vo.SkillName,iType,priceType);
            }
            if(priceType.Equals("现金")||priceType.Equals("Visa卡"))
            {
                gstPrice=(serverPrice * 6) / 106;
            }
            gstPrice = Math.Round(gstPrice, 2,MidpointRounding.AwayFromZero);
            totalPrice = serverPrice + gstPrice;
            this.textPrice.Text = serverPrice.ToString();
            this.textGst.Text = gstPrice.ToString();
            this.textTotal.Text = totalPrice.ToString();
        }
        private void BtnReadCard_Click(object sender, EventArgs e)
        {
            int icdev = -1;
            if ((icdev = D3Core.dc_init(100, 115200)) <= 0)
            {
                XtraMessageBox.Show("读卡失败1！");
                return;
            }

            if (D3Core.dc_beep(icdev, 10u) != 0)
            {
                XtraMessageBox.Show("读卡失败2！");
                return;
            }
            ulong num = 0uL;
            char mode = '\0';
            uint sec = 0u;
            int num2 = (int)D3Core.dc_reset(icdev, sec);
            num2 = (int)D3Core.dc_card(icdev, mode, ref num);
            if (num != 0uL)
            {
                byte[] nkey = new byte[] { 255, 255, 255, 255, 255, 255 };
                num2 = (int)D3Core.dc_load_key(icdev, 0, 0, nkey);
                int num3 = 0;
                if (D3Core.dc_authentication(icdev, 0, num3) == 0)
                {
                    byte[] expr_179 = new byte[] { 106, 194, 146, 250, 161, 49, 91, 77, 106, 194, 146, 250, 161, 49, 91, 77 };
                    string text = "".PadLeft(32, ' ');
                    int adr = num3 * 4 + 2;

                    StringBuilder stringBuilder = new StringBuilder(64);
                    StringBuilder stringBuilder2 = new StringBuilder(64);
                    if (D3Core.dc_read(icdev, adr, stringBuilder2) == 0)
                    {
                        this.textMemberId.Text = stringBuilder2.ToString();
                    }
                    else
                    {
                        try
                        {
                            if (D3Core.dc_read_hex(icdev, adr, stringBuilder) == 0)
                            {
                                this.textMemberId.Text = stringBuilder.ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("读卡失败3！");
                        }
                    }
                }
            }
        }
        #endregion
    }
}