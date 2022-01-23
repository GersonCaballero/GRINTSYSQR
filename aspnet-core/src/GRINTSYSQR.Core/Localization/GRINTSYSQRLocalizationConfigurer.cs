using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace GRINTSYSQR.Localization
{
    public static class GRINTSYSQRLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(GRINTSYSQRConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(GRINTSYSQRLocalizationConfigurer).GetAssembly(),
                        "GRINTSYSQR.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
