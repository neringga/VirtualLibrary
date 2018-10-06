using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrary.Helpers
{
    public static class Exceptions
    {
        public static void MessageBoxResponse(this Exception ex, string message)
        {
            MessageBox.Show(message);
        }
    }
}
