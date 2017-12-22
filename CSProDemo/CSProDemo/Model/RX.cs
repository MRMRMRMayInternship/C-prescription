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
        private string col1;
        private string col2;
        private string col3;
        private string col4;
        private string col5;
        private string col6;
        private System.Collections.ArrayList cols = new System.Collections.ArrayList();
        public RX() {}
        public RX(string c1, string c2, string c3, string c4, string c5, string c6)
        {
            
        }
        public string this[int index]{
            get
            {
                if (cols.Count < index && index > 0)
                    return (string)cols[index];
                else
                    return null;
            }
            set
            {
                if (cols.Count < index && index >0)
                    cols[index] = value;
                else if (cols.Count == index)
                {
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
