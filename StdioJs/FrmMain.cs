using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.JScript;
using System.Reflection;

namespace StdioJs
{
    public partial class FrmMain : Form
    {
        private StJS stJS = new StJS();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            object obj = this.stJS.RunByJSCodeProvider(this.rtbContent.Text);
            this.MsgBox(obj.ToString());
        }
    }
}
