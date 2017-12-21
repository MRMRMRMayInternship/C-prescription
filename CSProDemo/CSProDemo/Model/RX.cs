using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProDemo.Model
{
    interface Person{
        string Name{
            get;
            set;
        }
    }
    class Doctor : Person
    {
        private string id;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
    class Patient : Person{
        private string id;
        private string name;

        public string Name{
            get{
                return name;
            }
            set{
                this.name = value;
            }
        }
        public string ID{
            get{
                return id;
            }
            set{
                this.id = value;
            }
        }
    }
    interface IMedication
    {
        string Name { get; set; }
        string ID { get; set; }
        string DoseOfOnce { get; set; }
        string DoseOfOneDay { get; set; }
        string AmountOfDose { get; set; }
        string Detail { get; set; }
    }
    class medication : IMedication{
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
    /***
     * preID: the # of the prescription
     * date: Date the prescription be written
     * doctor: the docator who written the prescription
     ***/
    interface IPrescription
    {
        string PreID { get; set; }
        Doctor Doctor { get; set; }
        string Date { get; set; }
    }
    class Prescription : IPrescription 
    {
        private string preID;
        private Doctor doctor;
        private string date;
        public string PreID{
            get
            {
                return preID;
            }
            set
            {
                preID = value;
            }
        }
        public Doctor Doctor
        {
            get
            {
                return this.doctor;
            }
            set
            {
                doctor = value;
            }
        }
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
    }
    interface IRX
    {
        
    }
    public class RX{
        //Prescription prescription;
        //Patient patient;
        //Doctor doction;
        private string col1;
        private string col2;
        private string col3;
        private string col4;
        private string col5;
        private string col6;
        public string Col1
        {
            get
            {
                return this.col1;
            }
            set
            {
                this.col1 = value;
            }
        }
        public string Col2
        {
            get
            {
                return this.col2;
            }
            set
            {
                this.col2 = value;
            }
        }
        public string Col3
        {
            get
            {
                return this.col3;
            }
            set
            {
                this.col3 = value;
            }
        }
        public string Col4
        {
            get
            {
                return this.col4;
            }
            set
            {
                this.col4 = value;
            }
        }
        public string Col5
        {
            get
            {
                return this.col5;
            }
            set
            {
                this.col5 = value;
            }
        }
        public string Col6
        {
            get
            {
                return this.col6;
            }
            set
            {
                this.col6 = value;
            }
        }
    }
}
