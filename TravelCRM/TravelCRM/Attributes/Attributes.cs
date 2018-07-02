using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelCRM.Attributes
{
 
    [AttributeUsage(AttributeTargets.Property)]

    public class ColumnVisibility:Attribute
    {
        public int HideinGrid { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property)]

    public class ToolTip : Attribute
    {
        public string ToolTipText { get; set; }
    }

    public class AddEditMode : Attribute
    {
        public int AddEditNotRequired { get; set; }
    }

    public class RequiredIfAttribute:ValidationAttribute
    {
        private String PropertyName { get; set; }

        private new String ErrorMessage { get; set; }

        private List<string> DesiredValue { get; set; }

        public RequiredIfAttribute(String propertyname,string desiredvalue,String errormessage)
        {
            this.PropertyName = propertyname;
            this.DesiredValue = desiredvalue.Split(',').ToList();
            this.ErrorMessage = errormessage;
        }

        protected override ValidationResult IsValid(object value,ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object propertyvalue = type.GetProperty(PropertyName)?.GetValue(instance, null);
            if (propertyvalue!=null&&(DesiredValue.Exists(x=>x==propertyvalue.ToString())&& value==null))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}