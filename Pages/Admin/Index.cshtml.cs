using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace EtudiantCRUD.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string username, string password)
        {
            if (username == "admin" && password=="123") {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, username)

                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.
                            AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                            return RedirectToPage("../Etudiants/Index");
                        }
                return Page();
         }
}
}

