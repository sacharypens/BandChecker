using BandChecker.Extensions;
using BandChecker.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            FrameSource = "LiedjePage.xaml";
            LiedjesCommand = new BaseCommand(GoToLiedjePage);
        }

        private ICommand liedjesCommand;
        public ICommand LiedjesCommand
        {
            get
            {
                return liedjesCommand;
            }
            set
            {
                liedjesCommand = value;
            }
        }

        public void GoToLiedjePage()
        {
            frameSource = "LiedjePage.xaml";
        }
    }


}
