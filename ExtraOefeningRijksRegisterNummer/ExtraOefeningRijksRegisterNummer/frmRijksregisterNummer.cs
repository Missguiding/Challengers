using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraOefeningRijksRegisterNummer
{
    public partial class frmRijksregisterNummer : Form
    {
        public frmRijksregisterNummer()
        {
            InitializeComponent();
        }

        private void txtRijksregisternummer_Validating(object sender, CancelEventArgs e)
        {
            if (txtRijksregisternummer.Text == "")
            {
                epRijksregisternummer.SetError(txtRijksregisternummer, "Enter something");
            }

        }

        private void txtRijksregisternummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only certain characters can be entered in the textbox
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '\u002D' && e.KeyChar != '\u002E')
            {
                // If the key is not a digit, Backspace, or Delete, suppress the key event (prevent the character from being entered).
                e.Handled = true;
            }

            //the textbox can only contain a certain amount of characters
            if(txtRijksregisternummer.Text.Length > 15)
            {
                e.Handled = true;
            }

        }

    }

}
