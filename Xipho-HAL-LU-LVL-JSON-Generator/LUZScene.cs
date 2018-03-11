using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Xipho_HAL_LU_LVL_JSON_Generator.WorldLoader;
using Xipho_HAL_LU_LVL_JSON_Generator.WorldStructure;
using Xipho_HAL_LU_LVL_JSON_Generator.CommonDatatypes;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    namespace LUZSceneStruct {
        public struct LUZScene {
            public string filename;
            public byte sceneID;
            public byte isAudioScene;
            public string sceneName;
            public LVLFile sceneData;

            public void Read(ref BinaryReader br, LUZData myLUZ) {
                filename = StringUtils.ReadString(ref br);
                sceneID = br.ReadByte();
                br.BaseStream.Position += 3; // Skip 3 bytes
                isAudioScene = br.ReadByte();
                br.BaseStream.Position += 3; // Skip 3 bytes
                sceneName = StringUtils.ReadString(ref br);
                br.BaseStream.Position += 3; // Skip 3 bytes
                /// TODO: sceneData
            }
        }
    }
}
