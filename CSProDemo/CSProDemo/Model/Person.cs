using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProDemo.Model
{
    internal interface Person
    {
        string Name
        {
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
    class Patient : Person
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
                this.name = value;
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
                this.id = value;
            }
        }
    }
}
