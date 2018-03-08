using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Xipho_HAL_LU_LVL_JSON_Generator.WorldLoader;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    namespace LUZSceneStruct {
        public struct LUZScene {
            public string filename;
            public UInt32 sceneID;
            public UInt32 isAudioScene;
            public string sceneName;
            public LVLFile sceneData;
        }
    }
}
