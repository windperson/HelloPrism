using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloPrism.DataEntities
{
    public class Student : INotifyPropertyChanged
    {

        private string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }

        private string _name;
            
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }

        private uint _age;

        public uint Age
        {
            get { return _age; }
            set { _age = value; RaisePropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
