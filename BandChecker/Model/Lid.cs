using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker.Model
{
    class Lid : BaseModel, IDataErrorInfo
    {
        private int id;
        private string naam;
        private string voornaam;
        private DateTime geboortedatum;
        private string instrument;
        private int bandId;

        public Lid() { }

        public Lid(int bandId)
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

        public string Voornaam
        {
            get
            {
                return voornaam;
            }

            set
            {
                voornaam = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Geboortedatum
        {
            get
            {
                return geboortedatum;
            }

            set
            {
                geboortedatum = value;
                NotifyPropertyChanged();
            }
        }

        public string Instrument
        {
            get
            {
                return instrument;
            }

            set
            {
                instrument = value;
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

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "Naam": if (string.IsNullOrEmpty(Naam)) result = "Naam moet ingevuld zijn!"; break;
                    case "Voornaam": if (string.IsNullOrEmpty(Naam)) result = "Voornaam moet ingevuld zijn!"; break;
                };
                return result;
            }
        }
    }
}
