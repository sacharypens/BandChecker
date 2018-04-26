using BandChecker.Extensions;
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

        public LiedjeViewModel()
        {
            LeesBands();
            
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
    }
}
