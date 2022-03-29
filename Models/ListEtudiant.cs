

using System.ComponentModel.DataAnnotations;
namespace EtudiantCRUD.Models
{
    public class ListEtudiant
    {
        public int ID { get; set; }
       [Required(ErrorMessage ="Please Enter your First Name")]
       [Display(Name = " First Name: ")]
        public String FirstName { get; set; }
       

        [Required(ErrorMessage = "Please Enter your Last Name")]
        [Display(Name = " Last Name: ")]
        public String LastName { get; set; }
        


        [Required(ErrorMessage = "Please Enter your Email")]
        [Display(Name = " Email: ")]
        public String Email { get; set; }
      
       
    }
}
