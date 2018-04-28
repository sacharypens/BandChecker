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
    class LidViewModel : BaseViewModel
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
                FilterLeden();
            }
        }

        private ObservableCollection<Lid> leden;
        public ObservableCollection<Lid> Leden {
            get { return leden; }
            set
            {
                leden = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<String> formatedLeden = new ObservableCollection<string>();
        public ObservableCollection<String> FormatedLeden
        {
            get { return formatedLeden; }
            set
            {
                formatedLeden = value;
                NotifyPropertyChanged();
            }
        }
        private Lid selectedLid;
        public Lid SelectedLid
        {
            get { return selectedLid; }
            set
            {
                selectedLid = value;
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

        public LidViewModel()
        {
            LeesBand();
            
            dialogService = new DialogService();

            WijzigCommand = new BaseCommand(WijzigLid);
            ToevoegenCommand = new BaseCommand(ToevoegenLid);

            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);
            Messenger.Default.Register<BandUpdatedMessage>(this, OnBandUpdatedMessageReceived);
        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            dialogService.CloseLidDetailDialog();
            if(message.Type == UpdateFinishedMessage.MessageType.Deleted
                || message.Type == UpdateFinishedMessage.MessageType.Inserted)
            {
                FilterLeden();
            }
        }
        
        private void OnBandUpdatedMessageReceived(BandUpdatedMessage message)
        {
            LeesBand();
        }

        public void LeesBand()
        {
            BandDataService ds = new BandDataService();
            Bands = ds.getBands();
        }

        private void FilterLeden()
        {
            if(SelectedBand == null)
            {
                SelectedBand = new Band();
            }
            LidDataService ds = new LidDataService();
            Leden = ds.GetLedenByBand(SelectedBand);
            FormatedLeden.Clear();
            foreach (var lid in Leden)
            {
                string text = lid.Voornaam + " " + lid.Naam + " - geboren op " + lid.Geboortedatum.ToShortDateString() + " - speelt de volgende instrumenten: " + lid.Instrument;
                FormatedLeden.Add(text);
            }
        }

        private void WijzigLid()
        {
            if(SelectedLid != null)
            {
                Messenger.Default.Send<Lid>(SelectedLid);
                dialogService.ShowLidDetailDialog();
            }
        }

        private void ToevoegenLid()
        {
            SelectedLid = new Lid(selectedBand.Id);
            SelectedLid.Geboortedatum = DateTime.Today;
            Messenger.Default.Send<Lid>(SelectedLid);
            dialogService.ShowLidDetailDialog();
        }
    }
}
