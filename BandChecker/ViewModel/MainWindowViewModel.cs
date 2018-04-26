using BandChecker.Extensions;
using BandChecker.Messages;
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
            Messenger.Default.Register<GoToLiedjePageMessage>(this, OnMessageReceived);

        }

        public void OnMessageReceived(GoToLiedjePageMessage message)
        {
            FrameSource = "LiedjeView.xaml";
        }
    }


}
