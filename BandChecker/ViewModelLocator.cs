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
        private static BandDetailWindowViewModel bandDetailWindowViewModel = new BandDetailWindowViewModel();
        private static LiedjeViewModel liedjeViewModel = new LiedjeViewModel();
        private static LiedjeDetailWindowViewModel liedjeDetailWindowViewModel = new LiedjeDetailWindowViewModel();
        private static LidViewModel lidViewModel = new LidViewModel();

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

        public static BandDetailWindowViewModel BandDetailWindowViewModel
        {
            get
            {
                return bandDetailWindowViewModel;
            }
        }

        public static LiedjeViewModel LiedjeViewModel
        {
            get
            {
                return liedjeViewModel;
            }
        }

        public static LiedjeDetailWindowViewModel LiedjeDetailWindowViewModel
        {
            get
            {
                return liedjeDetailWindowViewModel;
            }
        }

        public static LidViewModel LidViewModel
        {
            get
            {
                return lidViewModel;
            }
        }
    }
}
