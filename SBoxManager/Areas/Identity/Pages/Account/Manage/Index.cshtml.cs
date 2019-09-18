using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBoxManager.Data;
using SBoxManager.Data.DTOs;

namespace SBoxManager.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<EntidadUsuario> _userManager;
        private readonly SignInManager<EntidadUsuario> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _dbContext;

        Persona persona;

        public IndexModel(
            UserManager<EntidadUsuario> userManager,
            SignInManager<EntidadUsuario> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _dbContext = dbContext;


        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
                
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [StringLength(96)]
            public string Nombre { get; set; }

            [StringLength(128)]
            public string Apellido { get; set; }

            [EnumDataType(typeof(TipoSexo))]
            public TipoSexo Sexo { get; set; }

            [DisplayName("Fecha de Nacimiento")]
            [DataType(DataType.Date)]
            public DateTime DoB { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            await _userManager.Users.Include(u => u.Persona).SingleAsync(us => us.Persona.UsuarioId.Equals(user.Id));
            
            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                Nombre = user.Persona.Nombre,
                Apellido = user.Persona.Apellido,
                Sexo = user.Persona.Sexo,
                DoB = user.Persona.DoB
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            await _userManager.Users.Include(u => u.Persona).SingleAsync(us => us.Persona.UsuarioId.Equals(user.Id));
            bool IsNew = false;

            if (user.Persona == null)
            {
                user.Persona = new Persona();
                IsNew = true;
            }

            if (Input.Nombre != user.Persona.Nombre)
            {
                user.Persona.Nombre = Input.Nombre;
            }

            if (Input.Apellido != user.Persona.Apellido)
            {
                user.Persona.Apellido = Input.Apellido;
            }

            if (Input.Sexo != user.Persona.Sexo)
            {
                user.Persona.Sexo = Input.Sexo;
            }

            if (Input.DoB != user.Persona.DoB)
            {
                user.Persona.DoB = Input.DoB;
            }


            if (IsNew)
            {
                user.Persona.Codigo = Guid.NewGuid();
                user.Persona.Creado = DateTime.UtcNow;

                _dbContext.Personas.Add(user.Persona);
            }
            else
            {
                user.Persona.Modificado = DateTime.UtcNow;
                _dbContext.Update(user.Persona);
            }

            await _dbContext.SaveChangesAsync();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
