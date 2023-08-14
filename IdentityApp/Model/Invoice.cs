using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [Display(Name = "Montant")]
        public double InvoiceAmount { get; set; }
        [Display(Name = "Mois")]
        public string InvoiceMonth { get; set; }
        [Display(Name = "Destinataire")]
        public string InvoiceOwner { get; set; }//Person who receives the invoice        
        public string CreatorId { get; set; }
        [Display(Name = "Statut")]
        public InvoiceStatus Status { get; set; }
    }
    public enum InvoiceStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
