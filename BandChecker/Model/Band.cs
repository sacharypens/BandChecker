using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker.Model
{
    class Band : BaseModel
    {
        private int id;
        private string naam;
        private string omschrijving;
        private int opgericht;
        private string genre;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string Naam
        {
            get { return naam; }
            set
            {
                naam = value;
                NotifyPropertyChanged();
            }
        }

        public string Omschrijving
        {
            get { return omschrijving; }
            set
            {
                omschrijving = value;
                NotifyPropertyChanged();
            }
        }

        public int Opgericht
        {
            get { return opgericht; }
            set
            {
                opgericht = value;
                NotifyPropertyChanged();
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                NotifyPropertyChanged();
            }
        }
    }
}
