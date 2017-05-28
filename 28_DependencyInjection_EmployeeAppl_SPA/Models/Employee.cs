using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee
    {
        
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        [Required]
        [Key]
        public string EmployeeCode { get; set; }
        [Required]
        [StringLength(5)]
        public string EmployeeName { get; set; }

        protected decimal _empSal;
        public virtual decimal EmployeeSalary
        {
            get
            {
                return _empSal;
            }
            set
            {
                _empSal = value;
            }
        }

        protected int _discount;
        public int Discount 
        { 
            get
            {
                return _discount;
            }
        }

        protected string _empType = "J";
        public string EmployeeType 
        { 
            get
            {
                return _empType;
            }
        }

        protected DateTime _eDoJ;
        public DateTime EmployeeDOJ { get; set; }

        public int EmployeeAge { get; set; }


    }

    public class EmpDiscountbyAge:Employee
    {
        public override decimal EmployeeSalary
        {
            get
            {
                return base.EmployeeSalary;
            }
            set
            {
                //Custom Logic
                if(this.EmployeeAge > 50)
                {
                    this._discount = 50;
                    this._empType = "A";
                }
                base.EmployeeSalary = value;
            }
        }

    }

    
    public class EmpDiscountbySalary:Employee
    {
        public override decimal EmployeeSalary
        {
            get
            {
                return base.EmployeeSalary;
            }
            set
            {
                if(_empSal > 5000)
                {
                    this._discount = 20;
                    this._empType = "S";
                }
                base.EmployeeSalary = value;
            }
        }
    }

    public class EmpDiscountbyDOJ:Employee
    {
        private DateTime eDateLimit = new DateTime(2000, 08, 06);
        public override decimal EmployeeSalary
        {
            get
            {
                return base.EmployeeSalary;
            }
            set
            {   
                if(_eDoJ.Date > eDateLimit.Date)
                {
                    this._discount = 15;
                    this._empType = "J";
                }
                base.EmployeeSalary = value;
            }
        }
    }



}