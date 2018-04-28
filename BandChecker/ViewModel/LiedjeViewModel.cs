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
    class LiedjeViewModel : BaseViewModel
    {
        private DialogService dialogService;

        private ObservableCollection<Liedje> liedjes;
        public ObservableCollection<Liedje> Liedjes
        {
            get { return liedjes; }
            set
            {
                liedjes = value;
                NotifyPropertyChanged();
            }
        }

        private Liedje selectedLiedje;
        public Liedje SelectedLiedje
        {
            get
            { return selectedLiedje; }

            set
            {
                selectedLiedje = value;
                NotifyPropertyChanged();
            }
        }

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
                FilterLiedjes();
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
        public LiedjeViewModel()
        {
            LeesBands();

            dialogService = new DialogService();

            WijzigCommand = new BaseCommand(WijzigLiedje);
            ToevoegenCommand = new BaseCommand(ToevoegenLiedje);

            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            dialogService.CloseLiedjeDetailDialog();
            
        }

        public void LeesBands()
        {
            BandDataService ds = new BandDataService();
            bands = ds.getBands();
        }

        private void FilterLiedjes()
        {
            LiedjeDataService ds = new LiedjeDataService();
            Liedjes = ds.GetLiedjesByBand(SelectedBand);
            
        }

        private void WijzigLiedje()
        {
            if (SelectedLiedje != null)
            {
                Messenger.Default.Send<Liedje>(SelectedLiedje);
                dialogService.ShowLiedjeDetailDialog();
                FilterLiedjes();
            }
        }

        private void ToevoegenLiedje()
        {
            SelectedLiedje = new Liedje(SelectedBand.Id);
            Messenger.Default.Send<Liedje>(SelectedLiedje);
            dialogService.ShowLiedjeDetailDialog();
            FilterLiedjes();
        }
    }
}
