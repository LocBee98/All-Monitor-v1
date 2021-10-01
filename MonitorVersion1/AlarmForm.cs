using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMonitor
{
    public partial class AlarmForm : Form
    {
        public static string userEmail1, userEmail2, userEmail3; 
        public static bool enable1, enable2, enable3;

        

        public AlarmForm()
        {
            InitializeComponent();
            getSetting();

        }

        #region Button Setting
        private void btnConfirm_MouseMove(object sender, MouseEventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(230, 79, 54);
        }

        private void btnConfirm_MouseLeave(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.FromArgb(10, 184, 212);

        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(230, 79, 54);
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(10, 184, 212);
        }


        #endregion
        

        private void AlarmForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                getSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getSetting()
        {
            string[] preSetting = new string[12];
            ReadWriteTxt _getFile = new ReadWriteTxt();
            preSetting = _getFile.readFile(@"txtSetting\appSetting.txt");

            //Email
            txbEmail1.Texts = preSetting[1];
            txbEmail2.Texts = preSetting[2];
            txbEmail3.Texts = preSetting[3];

            //Enable

            btnEnable1.Checked = Convert.ToBoolean(preSetting[5]);
            btnEnable2.Checked = Convert.ToBoolean(preSetting[6]);
            btnEnable3.Checked = Convert.ToBoolean(preSetting[7]);

            //Freq
            txbFreq.Texts = preSetting[9];
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string[] contents = { "1. User email", txbEmail1.Texts, txbEmail2.Texts, txbEmail3.Texts, "2. Enable", btnEnable1.Checked.ToString(), btnEnable2.Checked.ToString(), btnEnable3.Checked.ToString(), "3. Freq", txbFreq.Texts };
                ReadWriteTxt _writeFile = new ReadWriteTxt();
                _writeFile.writeFile(@"txtSetting\appSetting.txt", contents);
                MessageBox.Show("Change Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            getSetting();
            MessageBox.Show("Change Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
