using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraScript
{
  public partial class FormVisualizar : Form
  {
    string script = String.Empty;
    public FormVisualizar()
    {
      
    }

    public FormVisualizar(StringBuilder stringBuilder)
    {
      InitializeComponent();
            
      txtVisualizaScript.Text = stringBuilder.ToString();
    }

    private void btnSair_Click(object sender, EventArgs e)
    {
      this.Dispose();
    }

  }
}
