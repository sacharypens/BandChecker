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
    class LidDetailWindowViewModel : BaseViewModel
    {
        private Lid selectedLid;
        public Lid SelectedLid
        {
            get
            {
                return selectedLid;
            }
            set
            {
                selectedLid = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public LidDetailWindowViewModel()
        {
            Messenger.Default.Register<Lid>(this, OnLidReceived);

            UpdateCommand = new BaseCommand(UpdateLid);
            DeleteCommand = new BaseCommand(DeleteLid);
        } 

        private void UpdateLid()
        {
            LidDataService ds = new LidDataService();

            if(SelectedLid.Id == 0)
            {
                ds.InsertLid(SelectedLid);
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Inserted));
            } else
            {
                ds.UpdateLid(SelectedLid);
                Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Updated));
            }
        }

        private void DeleteLid()
        {
            LidDataService ds = new LidDataService();
            ds.DeleteLid(selectedLid);
            Messenger.Default.Send<UpdateFinishedMessage>(new UpdateFinishedMessage(UpdateFinishedMessage.MessageType.Deleted));
        }

        private void OnLidReceived(Lid lid)
        {
            SelectedLid = lid;
        }
    }
}
