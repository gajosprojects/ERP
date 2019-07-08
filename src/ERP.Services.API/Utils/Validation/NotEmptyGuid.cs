using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.Utils.Validation
{
    public class NotEmptyGuid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((Guid) value == Guid.Empty) return false;
            return true;
        }
    }
}