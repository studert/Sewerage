using System;
using System.Web.Mvc;
using System.Web.Security;
using Sewerage.Models;
using Sewerage.Resources.Models;

namespace Sewerage.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", ValidationStrings.WrongPassword);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null,
                                      passwordAnswer: null, isApproved: true, providerUserKey: null,
                                      status: out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, userIsOnline: true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", ValidationStrings.WrongOrInvalidPassword);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return ValidationStrings.DuplicateUserName;

                case MembershipCreateStatus.DuplicateEmail:
                    return ValidationStrings.DuplicateEmail;

                case MembershipCreateStatus.InvalidPassword:
                    return ValidationStrings.InvalidPassword;

                case MembershipCreateStatus.InvalidEmail:
                    return ValidationStrings.InvalidEmail;

                case MembershipCreateStatus.InvalidAnswer:
                    return ValidationStrings.InvalidAnswer;

                case MembershipCreateStatus.InvalidQuestion:
                    return ValidationStrings.InvalidQuestion;

                case MembershipCreateStatus.InvalidUserName:
                    return ValidationStrings.InvalidUserName;

                case MembershipCreateStatus.ProviderError:
                    return ValidationStrings.ProviderError;

                case MembershipCreateStatus.UserRejected:
                    return ValidationStrings.UserRejected;

                default:
                    return ValidationStrings.UnknownError;
            }
        }

        #endregion
    }
}
