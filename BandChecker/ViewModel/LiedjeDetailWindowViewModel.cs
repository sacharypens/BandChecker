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
    class LiedjeDetailWindowViewModel : BaseViewModel
    {

        private Liedje selectedLiedje;
        public Liedje SelectedLiedje
        {
            get { return selectedLiedje; }
            set {
                selectedLiedje = value;
                NotifyPropertyChanged();
            }


        }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public LiedjeDetailWindowViewModel()
        {
            Messenger.Default.Register<Liedje>(this, OnLiedjeReceived);

            UpdateCommand = new BaseCommand(UpdateLiedje);
            DeleteCommand = new BaseCommand(DeleteLiedje);
        }

        private void UpdateLiedje()
        {
            LiedjeDataService ds = new LiedjeDataService();

            if(SelectedLiedje.Id == 0)
            {
                ds.InsertLiedje(SelectedLiedje);
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));
            } else
            {
                ds.UpdateLiedje(SelectedLiedje);
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));

            }
        }

        private void DeleteLiedje()
        {
            LiedjeDataService ds = new LiedjeDataService();
            ds.DeleteLiedje(SelectedLiedje);
            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
        }

        private void OnLiedjeReceived(Liedje liedje)
        {
            SelectedLiedje = liedje;
        }
    }
}
