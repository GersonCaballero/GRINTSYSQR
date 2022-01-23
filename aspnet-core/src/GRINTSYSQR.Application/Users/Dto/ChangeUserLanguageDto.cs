using System.ComponentModel.DataAnnotations;

namespace GRINTSYSQR.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}