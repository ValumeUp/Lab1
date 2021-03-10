using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab1_1
{
    public class Transaction: BooleansBase
    {
        private static int InstanceCount;
        private int _id;
        private decimal _sum;
        private Category _category;
        private string _currency;
        private string _description;
        private DateTime _date;
        private FileStream _file;

        public static int InstanceCount1 { get => InstanceCount; set => InstanceCount = value; }
        public int Id { get => _id; set => _id = value; }
        public decimal Sum { 
            get {
                return  _sum; 
            }
            set { _sum = value; 
                HasChanges = true;
            } 
        }
        public Category Category { 
            get { 
                return _category; 
            }
            set { 
                _category = value;
                HasChanges = true;
            } 
        }
        public string Currency { 
            get { 
                return _currency; 
            }
            set {
                _currency = value;
                HasChanges = true;
            } 
        }
        public string Description { get { 
                return _description; 
            } 
            set {
                _description = value;
                HasChanges = true;
            }
        }
        public DateTime Date { 
            get { 
                return _date; 
            }
            set { _date = value;
                HasChanges = true;
            }
        }
        public FileStream File { get 
            {
                return _file;
            } 
            set { 
                _file = value;
                HasChanges = true;
            } 
        }

        public void DeleteTransaction()
        {
            this._currency = null;
            this._category = null;
            this._sum = 0;
            this._description = null;
            this._date = default;
            this._description = null;
            this._file = null;

        }

        public Transaction()
        {
            InstanceCount += 1;
            _id = InstanceCount;
        }
        public Transaction(int id, decimal sum, Category category, string currency, string description, DateTime date, FileStream file)
        {
            _id = id;
            _sum = sum;
            _category = category;
            _currency = currency;
            _description = description;
            _date = date;
            _file = file;
        }
    }
}
