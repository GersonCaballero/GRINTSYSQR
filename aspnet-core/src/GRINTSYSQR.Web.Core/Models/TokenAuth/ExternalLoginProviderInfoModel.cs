using Abp.AutoMapper;
using GRINTSYSQR.Authentication.External;

namespace GRINTSYSQR.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
