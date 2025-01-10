using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ToastyQoL.Helpers
{
#nullable enable
    public class LazyLocalization(string localizationKey)
    {
        private readonly string _localizationKey = localizationKey;
        private string? _localizedValue = null;
        public override string ToString()
        {
            return _localizedValue ??= Language.GetTextValue(_localizationKey);
        }
    }
#nullable restore
}
