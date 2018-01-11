using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.Models.ViewModels.pListLoadingProgressView
{
    public class LoadingProgressValue : INotifyPropertyChanged
    {
        private double _ProgressPercentValue = 0;
        public double ProgressPercentValue
        {
            get
            {
                return _ProgressPercentValue;
            }
            set
            {
                _ProgressPercentValue = value;
                OnPropertychanged("ProgressPercentValue");
            }
        }
        private int _DoingValue = 0;
        public int DoingValue
        {
            get
            {
                return _DoingValue;
            }
            set
            {
                _DoingValue = value;
            }
        }
        private int _TotalValue = 0;
        public int TotalValue
        {
            get
            {
                return _TotalValue;
            }
            set
            {
                _TotalValue = value;
            }
        }
        /// <summary>
        /// 进度值改变
        /// </summary>
        /// <param name="value"></param>
        public void ProgressValue_Changed(int value)
        {
            DoingValue = value;
            ProgressPercentValue = DoingValue == 0 || TotalValue == 0 ? 0 : DoingValue * 100.0 / TotalValue;
            ProgressValue = string.Format("{0}/{1}", value, TotalValue);
        }
        private string _ProgressValue = string.Empty;
        public string ProgressValue
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_ProgressValue))
                    _ProgressValue = "No loading";
                return _ProgressValue;
            }
            set
            {
                if (!_ProgressValue.Equals(value))
                {
                    _ProgressValue = value;
                    OnPropertychanged("ProgressValue");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertychanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
