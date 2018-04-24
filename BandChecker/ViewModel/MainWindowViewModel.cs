using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private string frameSource;
        public string FrameSource
        {
            get { return frameSource; }
            set { frameSource = value; NotifyPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            FrameSource = "BandView.xaml";
            
        }
    }


}
