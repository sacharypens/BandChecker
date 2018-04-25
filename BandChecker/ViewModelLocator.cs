using BandChecker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker
{
    class ViewModelLocator
    {
        private static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        private static BandViewModel bandViewModel = new BandViewModel();

        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return mainWindowViewModel;
            }
        }

        public static BandViewModel BandViewModel
        {
            get
            {
                return bandViewModel;
            }
        }
    }
}
