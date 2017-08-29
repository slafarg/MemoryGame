using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameImproved
{
    public partial class CreateLoginMenu : Form
    {
        public CreateLoginMenu()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCreateLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(DatabaseManagement.Queries.InsertLogin(txtPlayerID.Text, txtPassword.Text))
                {
                    MessageBox.Show(txtPlayerID.Text + " successfully added.");
                    this.Close();
                }
                else
                {
                    txtPlayerID.Clear();
                    txtPassword.Clear();
                    txtPlayerID.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
