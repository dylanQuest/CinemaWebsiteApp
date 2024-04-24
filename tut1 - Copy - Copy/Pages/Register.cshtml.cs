using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tut1.Pages.PageViewModels;
using RP1.Models.Models;
using System.Threading.Tasks;

namespace tut1.Pages
{
	[BindProperties]
	public class RegisterModel : PageModel
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public Register Register { get; set; }

		public string Passcode { get; set; }

		public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				// Check if the passcode matches the expected value
				if (Passcode != "staffAdmin")
				{
					ModelState.AddModelError("", "Invalid passcode.");
					return Page();
				}

				var user = new IdentityUser()
				{
					UserName = Register.EmailAddress,
					Email = Register.EmailAddress
				};

				var result = await _userManager.CreateAsync(user, Register.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, false);
					return RedirectToPage("Index");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return Page();
		}
	}
}
