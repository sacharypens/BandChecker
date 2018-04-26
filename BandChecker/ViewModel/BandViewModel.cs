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

        private ICommand verwijderenCommand;
        public ICommand VerwijderenCommand
        {
            get
            {
                return verwijderenCommand;
            }
            set
            {
                verwijderenCommand = value;
                
            }
        }

        private ICommand toevoegenCommand;
        public ICommand ToevoegenCommand
        {
            get
            {
                return toevoegenCommand;
            }
            set
            {
                toevoegenCommand = value;
               
            }
        }
        public BandViewModel()
        {
            LeesBands();

            dialogService = new DialogService();

            WijzigCommand = new BaseCommand(WijzigenBand);
            ToevoegenCommand = new BaseCommand(ToevoegenBand);

            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            dialogService.CloseDetailDialog();
        }

        private void LeesBands()
        {
            BandDataService ds = new BandDataService();
            Bands = ds.getBands();
        }

        private void WijzigenBand()
        {
            if(SelectedBand != null)
            {
                Messenger.Default.Send<Band>(SelectedBand);

                dialogService.ShowDetailDialog();
            }
            LeesBands();
        }

        private void ToevoegenBand()
        {
            SelectedBand = new Band();
            Messenger.Default.Send<Band>(SelectedBand);
            dialogService.ShowDetailDialog();
            LeesBands();
        }
    }
}
