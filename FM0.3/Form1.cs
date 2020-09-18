using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FM0._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region "Additional initialization (including Form_Load processing)"
        /*The declaration of instance value for ACT controls************************/
        // When you use Dot controls by 'References', you should program as follows;
        private ActUtlTypeLib.ActUtlTypeClass lpcom_ReferencesUtlType;

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Create instance for ACT Controls*************************************/
            lpcom_ReferencesUtlType = new ActUtlTypeLib.ActUtlTypeClass();

            /* Set EventHandler for ACT Controls************************************/
            // Create EventHandler(ActUtlType)
            lpcom_ReferencesUtlType.OnDeviceStatus +=
                new ActUtlTypeLib._IActUtlTypeEvents_OnDeviceStatusEventHandler(ActUtlType1_OnDeviceStatus);
            /**************************************************************************/

        }
        #endregion

        #region  ""Processing of Open button"
        private void btn_Open_Click(object sender, EventArgs e)
        {
            int iReturnCode;				//Return code
            int iLogicalStationNumber=0;		//LogicalStationNumber for ActUtlType

            //Displayed output data is cleared.
            ClearDisplay();

            //
            //Processing of Open method
            //
            try
            {

                //When ActUtlType is selected by the radio button,

                //Set the value of 'LogicalStationNumber' to the property.
                lpcom_ReferencesUtlType.ActLogicalStationNumber = iLogicalStationNumber;

                //Set the value of 'Password'.
                lpcom_ReferencesUtlType.ActPassword = "";

                //The Open method is executed.
                iReturnCode = lpcom_ReferencesUtlType.Open();

            }
            //Exception processing
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                                  Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //The return code of the method is displayed by the hexadecimal.
            txt_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode) + DateTime.Now.ToString();
        }
        #endregion

        #region  "Processing of Close button"
        private void btn_Close_Click(object sender, EventArgs e)
        {
            int iReturnCode;	//Return code

            //Displayed output data is cleared.
            ClearDisplay();

            //
            //Processing of Close method
            //
            try
            {
                //When ActUtlType is selected by the radio button,

                //The Close method is executed.
                iReturnCode = lpcom_ReferencesUtlType.Close();

            }

            //Exception processing
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                                  Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //The return code of the method is displayed by the hexadecimal.
            txt_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)+DateTime.Now.ToString();

        }
        #endregion

        #region "Processing of OnDeviceStatus for ActUtlType Controle"
        private void ActUtlType1_OnDeviceStatus(String szDevice, int iData, int iReturnCode)
        {
            System.String[] arrData;	        //Array for 'Data'
            //Assign the array for the read data.
            arrData = new System.String[txt_Data.Lines.Length + 1];

            //Copy the read data to the 'arrData'.
            Array.Copy(txt_Data.Lines, arrData, txt_Data.Lines.Length);

            //Add the content of new event to arrData.
            arrData[txt_Data.Lines.Length]
            = String.Format("OnDeviceStatus event by ActUtlType [{0}={1}]", szDevice, iData);

            //The new 'Data' is displayed.
            txt_Data.Lines = arrData;

            //The return code of the method is displayed by the hexadecimal.
            txt_ReturnCode.Text = String.Format("0x{0:x8}", iReturnCode) + DateTime.Now.ToString();

        }
        #endregion

        #region " Processing of clear displayed output data"
        private void ClearDisplay()
        {
            //Clear TextBox of 'ReturnCode','Data'
            txt_ReturnCode.Text = "";
            txt_Data.Text = "";
        }
        #endregion

        #region "Processing of ReadDeviceBlock2 button"
        private void btn_ReadDeviceBlock2_Click(object sender, EventArgs e)
        {
            int iReturnCode;				//Return code
            String szDeviceName = "";		//List data for 'DeviceName'
            int iNumberOfData = 0;			//Data for 'DeviceSize'
            short[] arrDeviceValue;		    //Data for 'DeviceValue'

            //Displayed output data is cleared.
            ClearDisplay();

            //Get the list of 'DeviceName'.
            //  Join each line(StringType array) of 'DeviceName' by the separator '\n',
            //  and create a joined string data.
            szDeviceName ="F0";

            iNumberOfData = 188;

            //Assign the array for 'DeviceValue'.
            arrDeviceValue = new short[iNumberOfData];

            //
            //Processing of ReadDeviceBlock2 method
            //
            try
            {

                //When ActUtlType is selected by the radio button,

                //The ReadDeviceBlock2 method is executed.
                iReturnCode = lpcom_ReferencesUtlType.ReadDeviceBlock2(szDeviceName,
                                                                iNumberOfData,
                                                                out arrDeviceValue[0]);
            }

            //Exception processing			
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Name,
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //The return code of the method is displayed by the hexadecimal.
            txt_ReturnCode.Text = String.Format("0x{0:x8}", iReturnCode);

            //
            //Display the read data
            //
            //When the ReadDeviceRandom2 method is succeeded, display the read data.
            if (iReturnCode == 0)
            {
                //对获得的F报警进行处理
                //当总数和不为0时，说明有报错发生

                //对数组求和
                int sum = 0;
                for (int i = 0; i < arrDeviceValue.Length; i++)
                {
                    sum += arrDeviceValue[i];
                }

                //判断数组和是否为0
                if (sum==0)
                {
                    //数据和为0，证明F0~F3007没有ON，未发生报警
                    Console.WriteLine("未发生报错");
                }
                else
                {
                    //调用函数获取报警数据数组
                    List<int> F_Alarm_Code = GetF_Alarm(arrDeviceValue);

                }
            }
        }
        #endregion

        #region 将获得报警字符串转换成正确顺序的数组

        //输入  从PLC读取到的short 数组
        //输出  报警的代码 list<int>
        private List<int> GetF_Alarm(short[] arrDeviceValue)
        { 
            //对数组数据进行解析
            //将10进制数变换成16位2进制
            string strResult = string.Empty;
            string strTemp;
            string strTemp_True;
            Char[] chArr_true;
            List<int> F_Alarm_Code;
            for (int i = 0; i < arrDeviceValue.Length; i++)
            {
                //将10进制转换成16位2进制
                strTemp = System.Convert.ToString(arrDeviceValue[i], 2);
                strTemp = strTemp.Insert(0, new string('0', 16 - strTemp.Length));

                //将数据前后互换得到正确顺序的字符串
                Char[] chArr = strTemp.ToCharArray();
                chArr_true = new Char[16];
                for (int m = 0; m < chArr.Length; m++)
                {
                    chArr_true[m] = chArr[15 - m];
                }
                strTemp_True = new String(chArr_true); ;
                strResult += strTemp_True;
            }

            //将字符串转换成Char
            char[] F_报警集合 = strResult.ToArray();

            //初始化报警代码列表
            F_Alarm_Code = new List<int>();

            //将报警代码添加到报警代码列表中
            for (int i = 0; i < F_报警集合.Length; i++)
            {
                if (F_报警集合[i]=='1')
                {
                    F_Alarm_Code.Add(i);
                }
            }

            return F_Alarm_Code;
        }

        #endregion

    }
}
