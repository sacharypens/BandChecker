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

        private ICommand terugCommand;
        public ICommand TerugCommand
        {
            get
            {
                return terugCommand;
            }
            set
            {
                terugCommand = value;
            }
        }

        private ICommand verderCommand;
        public ICommand VerderCommand
        {
            get
            {
                return verderCommand;
            }
            set
            {
                verderCommand = value;
            }
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

        private ICommand bandsCommand;
        public ICommand BandsCommand
        {
            get
            {
                return bandsCommand;
            }
            set
            {
                bandsCommand = value;
            }
        }

        private ICommand ledenCommand;
        public ICommand LedenCommand
        {
            get
            {
                return ledenCommand;
            }
            set
            {
                ledenCommand = value;
            }
        }
        public MainWindowViewModel()
        {
            FrameSource = "LiedjePage.xaml";
            BandsCommand = new BaseCommand(GoToBandsView);
            LiedjesCommand = new BaseCommand(GoToLiedjePage);
            LedenCommand = new BaseCommand(GoToLidView);
        }

        public void GoToLiedjePage()
        {
            FrameSource = "LiedjePage.xaml";
        }

        public void GoToBandsView()
        {
            
            FrameSource = "BandView.xaml";
        }

        public void GoToLidView()
        {
            FrameSource = "LidView.xaml";
        }
    }


}
