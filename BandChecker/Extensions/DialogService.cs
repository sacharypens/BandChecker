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

        Window liedjeDetailWindowView = null;

        Window lidDetailWindowView;

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

        public void ShowLiedjeDetailDialog()
        {
            liedjeDetailWindowView = new LiedjeDetailWindow();
            liedjeDetailWindowView.Show();
        }

        public void CloseLiedjeDetailDialog()
        {
            if (liedjeDetailWindowView != null)
            {
                liedjeDetailWindowView.Close();
            }
        }

        public void ShowLidDetailDialog()
        {
            lidDetailWindowView = new LidDetailWindow();
            lidDetailWindowView.Show();
        }

        public void CloseLidDetailDialog()
        {
            if(lidDetailWindowView != null)
            {
                lidDetailWindowView.Close();
            }
        }
    }
}
