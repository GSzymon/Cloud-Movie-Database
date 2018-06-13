using System;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public static class MovieValidator
    {
        public static bool IsValid(MovieViewModel modelVm)
        {
            if (string.IsNullOrEmpty(modelVm.Title) ||
                (modelVm.Year > DateTime.Now.Year) ||
                (modelVm.Year < 1901) ||
                (modelVm.StarringActorsIds.Count==0))
            {
                return false;
            }
            return true;
        }
    }
}
