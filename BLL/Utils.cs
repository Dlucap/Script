using System;
using System.Windows.Forms;

namespace BLL
{
  public class Utils
  {
    public bool VerificaGridView(DataGridView dgv)
    {
      if (dgv.CurrentRow == null)
      {
        return true;
      }
      return false;
    }

    public string VerificaStringVazia(string palavra)
    {
      if (!String.IsNullOrWhiteSpace(palavra))
      {
        return palavra;
      }
      else
      {
        return "NULL";
      }
    }
    
  }
}
