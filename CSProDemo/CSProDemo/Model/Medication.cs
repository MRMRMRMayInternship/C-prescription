using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProDemo.Model
{
    interface IMedication
    {
        string Name { get; set; }
        string ID { get; set; }
        string DoseOfOnce { get; set; }
        string DoseOfOneDay { get; set; }
        string AmountOfDose { get; set; }
        string Detail { get; set; }
    }
    class Medication : IMedication
    {
        private string name;
        private string id;
        private string doseOfOnce;
        private string doseOfOneDay;
        private string amountOfDose;
        private string detail;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string DoseOfOnce
        {
            get
            {
                return this.doseOfOnce;
            }
            set
            {
                this.doseOfOnce = value;
            }
        }
        public string DoseOfOneDay
        {
            get
            {
                return this.doseOfOneDay;
            }
            set
            {
                this.doseOfOneDay = value;
            }
        }
        public string AmountOfDose
        {
            get
            {
                return this.amountOfDose;
            }
            set
            {
                this.amountOfDose = value;
            }
        }
        public string Detail
        {
            get
            {
                return this.Detail;
            }
            set
            {
                this.detail = value;
            }
        }
    }
}
