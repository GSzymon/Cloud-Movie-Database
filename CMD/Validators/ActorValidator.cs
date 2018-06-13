using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public static class ActorValidator
    {
        public static bool IsValid(ActorViewModel actorVm)
        {
            if (string.IsNullOrEmpty(actorVm.FirstName) || string.IsNullOrEmpty(actorVm.LastName))
            {
                return false;
            }
            try
            {
                DateTime.ParseExact(actorVm.Birthday, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;

        }
    }
}
