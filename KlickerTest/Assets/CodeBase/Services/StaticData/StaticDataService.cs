using CodeBase.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataWindowPath = "StaticData/UI/WindowStaticData";

        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void Load()
        {

            _windowConfigs = Resources
              .Load<WindowStaticData>(StaticDataWindowPath)
              .Configs
              .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowId) =>
          _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
            ? windowConfig
            : null;
    }
}
