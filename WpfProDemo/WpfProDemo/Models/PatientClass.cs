﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.Models
{
    public class PatientClass:PersonClass
    {
        public string SymptomDescription { get; set; }
        public string PatientID { get; set; }
    }
}
