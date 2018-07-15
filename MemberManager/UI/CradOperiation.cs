using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClientCenter.Core;
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.Enity;

namespace MemberManager.UI
{
    public partial class CradOperiation : DevExpress.XtraEditors.XtraUserControl
    {
        CardInfoUI cardInfoUI;
        private int icdev = -1;

        public CradOperiation()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += MemberSetting_Load;
            this.btnWriteCard.Click += BtnWriteCard_Click;
        }

        private void BtnWriteCard_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.textEdit1.Text.Trim()))
            {
                XtraMessageBox.Show("请输入卡号！");
                return;
            }
            WriteCard(this.textEdit1.Text.Trim());
        }
        private bool InitIcDev()
        {
            if (icdev < 0)
            {
                icdev = D3Core.dc_init(100, 115200);//第一个参数100为USB口，0为串口一，1为串口二等等。
                if (icdev <= 0)
                {
                    this.listBoxControl1.Items.Add("初始化端口失败!");
                    return false;
                }
                this.listBoxControl1.Items.Add("初始化端口成功!");
            }
            return true;
        }
        private void WriteCard(string cardNo)
        {
            if ((icdev = D3Core.dc_init(100, 115200)) > 0)
            {
                this.listBoxControl1.Items.Add("初始化成功！");
                if (D3Core.dc_beep(icdev, 10u) == 0)
                {
                    this.listBoxControl1.Items.Add("蜂鸣成功！");
                    ulong num = 0uL;
                    char mode = '\0';
                    uint sec = 0u;
                    int num2 = (int)D3Core.dc_reset(icdev, sec);
                    num2 = (int)D3Core.dc_card(icdev, mode, ref num);
                    if (num != 0uL)
                    {
                        this.listBoxControl1.Items.Add("寻卡成功，卡内号为：" + num);
                        byte[] nkey = new byte[]{ 255,255,255,255,255,255};
                        num2 = (int)D3Core.dc_load_key(icdev, 0, 0, nkey);
                        int num3 = 0;
                        if (D3Core.dc_authentication(icdev, 0, num3) == 0)
                        {
                            this.listBoxControl1.Items.Add("验证密码成功！");
                            byte[] expr_179 = new byte[]{ 106,194, 146,250,161,49,91,77,106,194,146,250,161,49,91,77};
                            string text = "".PadLeft(32, ' ');
                            int adr = num3 * 4 + 2;
                            text = this.textEdit1.Text.Trim();
                            if (D3Core.dc_write(icdev, adr, text) == 0)
                            {
                                this.listBoxControl1.Items.Add("写卡成功，内容为：" + text);
                                StringBuilder stringBuilder = new StringBuilder(64);
                                StringBuilder stringBuilder2 = new StringBuilder(64);
                                byte[] array = new byte[256];
                                char[] array2 = new char[32];
                                string text2 = stringBuilder.ToString();
                                string empty = string.Empty;
                                if (D3Core.dc_read(icdev, adr, stringBuilder2) == 0)
                                {
                                    this.listBoxControl1.Items.Add("读卡成功，卡内容为：" + stringBuilder2);
                                }
                                else
                                {
                                    try
                                    {
                                        if (D3Core.dc_read_hex(icdev, adr, stringBuilder) == 0)
                                        {
                                            this.listBoxControl1.Items.Add("读卡成功，卡内容为：" + stringBuilder);
                                        }
                                        else
                                        {
                                            this.listBoxControl1.Items.Add("读卡失败！");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                            }
                            else
                            {
                                this.listBoxControl1.Items.Add("写卡失败！");
                            }
                        }
                        else
                        {
                            this.listBoxControl1.Items.Add("验证密码失败！");
                        }
                    }
                    else
                    {
                        this.listBoxControl1.Items.Add("寻卡失败！");
                    }
                }
                else
                {
                    this.listBoxControl1.Items.Add("蜂鸣失败！");
                }
            }
            else
            {
                this.listBoxControl1.Items.Add("初始化失败！");
            }
        }
        private void MemberSetting_Load(object sender, EventArgs e)
        {
            if (cardInfoUI == null)
                cardInfoUI = new CardInfoUI();
            cardInfoUI.Dock = DockStyle.Fill;
            xtraTabPage1.Controls.Add(cardInfoUI);
        }
    }
}
