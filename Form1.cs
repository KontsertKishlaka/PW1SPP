using System.Management;

namespace PW1SPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                Double CPUtprt = 0;
                ManagementObjectSearcher MOS = new("root\\WMI",
                        "SELECT * FROM MSAcpi_ThermalZoneTemperature");
                foreach (ManagementObject Mo in MOS.Get().Cast<ManagementObject>())
                {
                    CPUtprt = Convert.ToDouble(Convert.ToDouble(Mo.GetPropertyValue("CurrentTemperature".ToString())) - 2732) / 10.0;
                    listBox1.Items.Add(" CPU: " + CPUtprt.ToString() + " ° C");
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("Ошибка получения данных " + ex.Message);
            }
        }
    }
}
