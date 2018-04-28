using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker.Model
{
    class Liedje : BaseModel
    {
        private int id;
        private string naam;
        private string duurtijd;
        private int bandId;

        public Liedje() { }

        public Liedje(int bandId)
        {
            this.bandId = bandId;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }

            set
            {
                naam = value;
                NotifyPropertyChanged();
            }
        }

        public string Duurtijd
        {
            get
            {
                return duurtijd;
            }

            set
            {
                duurtijd = value;
                NotifyPropertyChanged();
            }
        }

        public int BandId
        {
            get
            {
                return bandId;
            }

            set
            {
                bandId = value;
                NotifyPropertyChanged();
            }
        }
    }
}
