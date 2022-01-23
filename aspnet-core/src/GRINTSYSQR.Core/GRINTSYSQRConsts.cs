using GRINTSYSQR.Debugging;

namespace GRINTSYSQR
{
    public class GRINTSYSQRConsts
    {
        public const string LocalizationSourceName = "GRINTSYSQR";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "eb8b41a181e243d59bd4d71106126fc4";
    }
}
