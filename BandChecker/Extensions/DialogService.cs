using BandChecker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BandChecker.Extensions
{
    class DialogService
    {
        Window bandDetailWindowView = null;

        public DialogService() { }

        public void ShowDetailDialog()
        {
            bandDetailWindowView = new BandDetailWindow();
            bandDetailWindowView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if(bandDetailWindowView != null)
            {
                bandDetailWindowView.Close();
            }
        }
    }
}
