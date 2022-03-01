using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class IndexAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is int index)
            {
                if(index >= 0)
                {
                    return true;
                }
                this.ErrorMessage = "Less than zero";
            }
            else
            {
                this.ErrorMessage = "Is not an int";
            }
            return false;
        }
    }
}
