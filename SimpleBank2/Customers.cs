using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    public class Customers
    {
        // Declare attributes.
        private static int _nextcID = 1;
        protected int _cID;
        private string _name;
        private string _phone;
        private string _address;
        protected double _feeReduction;

        // Constructor.
        public Customers()
        {
            _cID = _nextcID;
            _nextcID++;
        }

        public Customers(string name, string phone, string address) : this()
        {
            _name = name;
            _phone = phone;
            _address = address;
        }


        // Constructor for a sub-class having a varied fee reduction.
        protected Customers(string name, string phone, string address, double feereduction) : this()
        {
            _name = name;
            _phone = phone;
            _address = address;
            _feeReduction = feereduction;
        }


        public int NextCID { set => _nextcID = value; }

        // Read-only.
        public int ID { get => _cID; }

        // Public access for attirbutes.
        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
        public double FeeReduction { get => _feeReduction; set => _feeReduction = value; }

    }
}
