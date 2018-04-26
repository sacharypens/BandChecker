using BandChecker.Extensions;
using BandChecker.Messages;
using BandChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BandChecker.ViewModel
{
    class BandDetailWindowViewModel : BaseViewModel
    {
        private Band selectedBand;
        public Band SelectedBand
        {
            get
            {
                return selectedBand;
            }
            set
            {
                selectedBand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public BandDetailWindowViewModel()
        {
            Messenger.Default.Register<Band>(this, OnBandReceived);
            

            UpdateCommand = new BaseCommand(UpdateBand);
            DeleteCommand = new BaseCommand(DeleteBand);
        }

        
        private void UpdateBand()
        {
            BandDataService ds = new BandDataService();
            
            if(SelectedBand.Id == 0)
            {
                ds.InsertBand(selectedBand);
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));

            }
            else
            {
                ds.UpdateBand(SelectedBand);
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));
            }

            
        }

        private void DeleteBand()
        {
            BandDataService ds = new BandDataService();
            ds.DeleteBand(SelectedBand);
            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
        }

        private void OnBandReceived(Band band)
        {
            SelectedBand = band;
        }
    }
}
