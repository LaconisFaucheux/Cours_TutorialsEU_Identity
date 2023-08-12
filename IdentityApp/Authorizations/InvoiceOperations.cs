using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Runtime.InteropServices;

namespace IdentityApp.Authorizations
{
    public class InvoiceOperations
    {
        public static OperationAuthorizationRequirement Create = new()
        {
            Name = Constants.CreateOperationName
        };
        public static OperationAuthorizationRequirement Read = new ()
        {
            Name = Constants.ReadOperationName
        };
        public static OperationAuthorizationRequirement Update = new ()
        {
            Name = Constants.UpdateOperationName
        };
        public static OperationAuthorizationRequirement Delete = new ()
        {
            Name = Constants.DeleteOperationName
        };
        public static OperationAuthorizationRequirement Approved = new ()
        {
            Name = Constants.ApprovedOperationName
        };
        public static OperationAuthorizationRequirement Rejected = new ()
        {
            Name = Constants.RejectedOperationName
        };
    }

    public class Constants
    {
        public static readonly string CreateOperationName   = "Create";
        public static readonly string ReadOperationName     = "Read";
        public static readonly string UpdateOperationName   = "Update";
        public static readonly string DeleteOperationName   = "Delete";

        public static readonly string ApprovedOperationName = "Approved";
        public static readonly string RejectedOperationName = "Rejected";

        public static readonly string InvoiceManagersRole   = "InvoiceManager";
    }
}
