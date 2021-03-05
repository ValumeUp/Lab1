using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab1_1
{
    public class Transaction
    {
        private static int InstanceCount;
        private int _id;
        private double _sum;
        private Category _category;
        private string _currency;
        private string _description;
        private DateTime _date;
        private FileStream _file;

        public static int InstanceCount1 { get => InstanceCount; set => InstanceCount = value; }
        public int Id { get => _id; set => _id = value; }
        public double Sum { get => _sum; set => _sum = value; }
        public Category Category { get => _category; set => _category = value; }
        public string Currency { get => _currency; set => _currency = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public FileStream File { get => _file; set => _file = value; }

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
        public Transaction(int id, double sum, Category category, string currency, string description, DateTime date, FileStream file)
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
