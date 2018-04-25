using BandChecker.Extensions;
using BandChecker.Messages;
using BandChecker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BandChecker.ViewModel
{
    class BandViewModel: BaseViewModel
    {
        private DialogService dialogService;

        private ObservableCollection<Band> bands;

        public ObservableCollection<Band> Bands
        {
            get { return bands; }
            set
            {
                bands = value;
                NotifyPropertyChanged();
            }
        }

        private Band selectedBand;
        public Band SelectedBand
        {
            get { return selectedBand; }
            set
            {
                selectedBand = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand wijzigCommand;
        public ICommand WijzigCommand
        {
            get
            {
                return wijzigCommand;
            }
            set
            {
                wijzigCommand = value;
            }
        }

        public BandViewModel()
        {
            BandDataService ds = new BandDataService();
            Bands = ds.getBands();

            dialogService = new DialogService();

            WijzigCommand = new BaseCommand(WijzigenBand);

            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            dialogService.CloseDetailDialog();
        }

        private void WijzigenBand()
        {
            if(SelectedBand != null)
            {
                Messenger.Default.Send<Band>(SelectedBand);

                dialogService.ShowDetailDialog();
            }
        }
    }
}
