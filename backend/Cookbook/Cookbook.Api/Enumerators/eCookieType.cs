using System.ComponentModel;

namespace Cookbook.Api.Enumerators
{
    public enum eCookieType
    {
        None,
        [Description("X-Access-Token")]
        AccessToken,
        [Description("X-Refresh-Token")]
        RefreshToken
    }
}
