using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Data
{
    public class ActionMessage
    {
        public static string NationalIdVerificationFalse = "Customer information cannot be verified.";
        public static string AlreadyAddedCustomer = "The customer you are trying to add has been already added.";
        public static string AddCustomerSuccess = "The customer successfully added.";
        public static string NoCustomerRelatedToId = "No customer related to id : {0}";
        public static string DeleteCustomerSuccess = "The customer successfully deleted.";
        public static string FillAtLeastNameOrNationalId = "First name and last name OR National Id Number should be typed.";
        public static string FillBothNames = "First name and last name should be typed.";
    }
}
