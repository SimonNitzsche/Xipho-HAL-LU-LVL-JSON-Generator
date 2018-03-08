using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xipho_HAL_LU_LVL_JSON_Generator.CommonDatatypes;
using Xipho_HAL_LU_LVL_JSON_Generator.LUZSceneStruct;
using static Xipho_HAL_LU_LVL_JSON_Generator.LUZTransition;
using static Xipho_HAL_LU_LVL_JSON_Generator.LUZPath;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    namespace WorldStructure {
        public struct LUZData {
            public UInt32 version;
            public UInt32 unknown1; // if version >= 0x24
            public Coordinate spawnPosition;
            public LUZScene[] scenes;
            public byte unknown2;
            public string terrainFilename;
            public string terrainName;
            public string terrainDescription;
            public SceneTransition[] sceneTransitions;
            public UInt32 lengthOfRestOfFileInBytes;
            public UInt32 unknown3;
            public LUZPath.Path[] paths;
        }
    }
}
