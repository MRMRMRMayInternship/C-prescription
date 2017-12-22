using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProDemo.Model
{
    
    
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
        //private string col1;
        //private string col2;
        //private string col3;
        //private string col4;
        //private string col5;
        //private string col6;
        private System.Collections.ArrayList cols = new System.Collections.ArrayList();
        private int count = 0;
        public RX() {}
        public RX(string c1, string c2, string c3, string c4, string c5, string c6)
        {
            
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        public string this[int index]{
            get
            {
                if (cols.Count > index && index >= 0)
                    return (string)cols[index];
                else
                    return null;
            }
            set
            {
                if (cols.Count < index && index < 0)
                    cols[index] = value;
                else if (cols.Count == index)
                {
                    this.count++;
                    cols.Add(value);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("error");
                }
            }
        }
        public string Col1
        {
            get;
            set;
        }
        public string Col2
        {
            get;
            set;
        }
        public string Col3
        {
            get;
            set;
        }
        public string Col4
        {
            get;
            set;
        }
        public string Col5
        {
            get;
            set;
        }
        public string Col6
        {
            get;
            set;
        }
    }
}
