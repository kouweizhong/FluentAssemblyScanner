using System;

using JetBrains.Annotations;

namespace FluentAssemblyScanner
{
    internal static class AppDomainExtensions
    {
#if NET452
        [NotNull]
        public static string GetActualDomainPath([NotNull] this AppDomain @this)
        {
            return @this.RelativeSearchPath ?? @this.BaseDirectory;
        }       
#endif
    }
}
