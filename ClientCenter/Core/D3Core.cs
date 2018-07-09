using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
    public class D3Core
    {
        #region  D3接口函数定义
        [DllImport("dcrf32.dll")]
        public static extern int dc_init(Int16 port, long baud);  //初试化
        [DllImport("dcrf32.dll")]
        public static extern int dc_exit(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern int dc_reset(int icdev, uint sec);
        [DllImport("dcrf32.dll")]
        public static extern int dc_request(int icdev, char _Mode, ref uint TagType);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card(int icdev, char _Mode, ref ulong Snr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card(int icdev, char _Mode, [MarshalAs(UnmanagedType.LPStr)] StringBuilder Snr);  //从卡中读数据(转换为16进制)
        [DllImport("dcrf32.dll")]
        public static extern int dc_halt(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern int dc_anticoll(int icdev, char _Bcnt, ref ulong IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern int dc_beep(int icdev, uint _Msec);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication(int icdev, int _Mode, int _SecNr);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_passaddr(int icdev, int _Mode, int _SecNr, [In] string sdata);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_passaddr_hex(int icdev, int _Mode, int _SecNr, [In] string sdata);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass(int icdev, int _Mode, int _SecNr, [In] string sdata);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass_hex(int icdev, int _Mode, int _SecNr, [In] string sdata);
        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key(int icdev, int mode, int secnr, [In] byte[] nkey);  //密码装载到读写模块中
        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key_hex(int icdev, int mode, int secnr, string nkey);  //密码装载到读写模块中
        [DllImport("dcrf32.dll")]
        public static extern int dc_write(int icdev, int adr, [In] string sdata);  //向卡中写入数据
        [DllImport("dcrf32.dll")]
        public static extern int dc_write_hex(int icdev, int adr, [In] string sdata);  //向卡中写入数据(转换为16进制)
        [DllImport("dcrf32.dll")]
        public static extern int dc_read(int icdev, int adr, [Out] byte[] sdata);  //从卡中读数据
        [DllImport("dcrf32.dll")]
        public static extern short dc_read(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  //从卡中读数据
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, ref byte sdata);  //从卡中读数据(转换为16进制)
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  //从卡中读数据(转换为16进制)
        [DllImport("dcrf32.dll")]
        public static extern void hex_a(ref string oldValue, ref string newValue, int len);  //十六进制字符转换成普通字符
        [DllImport("dcrf32.dll")]
        public static extern short dc_initval(int icdev, int _Bcnt, [In] uint IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readval(int icdev, int _Bcnt, ref uint IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_increment(int icdev, int _Bcnt, [In] uint IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_decrement(int icdev, int _Bcnt, [In] uint IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_dispinfo_T8(int icdev, short sline, short offset, [In] string infodata);
        #endregion

        public static string ReadMemberCard(out string errorStr)
        {
            int icdev = -1;
            if ((icdev = D3Core.dc_init(100, 115200)) <= 0)
            {
                errorStr = "读卡失败1！";
                return null;
            }

            if (D3Core.dc_beep(icdev, 10u) != 0)
            {
                errorStr = "读卡失败2！";
                return null;
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
                        errorStr = "";
                        return stringBuilder2.ToString();
                    }
                    else
                    {
                        try
                        {
                            if (D3Core.dc_read_hex(icdev, adr, stringBuilder) == 0)
                            {
                                errorStr = "";
                                return stringBuilder.ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            errorStr = ex.ToString();
                            return null;
                        }
                    }

                }
            }
            errorStr = "读卡失败!";
            return null;
        }


    }
}
