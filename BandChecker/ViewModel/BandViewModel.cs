using BandChecker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker.ViewModel
{
    class BandViewModel: BaseViewModel
    {
        private ObservableCollection<Band> Bands;

        public ObservableCollection<Band> bands
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

        public BandViewModel()
        {
            BandDataService ds = new BandDataService();
            
        }
    }
}
