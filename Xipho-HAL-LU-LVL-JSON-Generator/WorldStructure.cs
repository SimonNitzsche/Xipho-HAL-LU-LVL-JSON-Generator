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
            public UInt32 worldID;
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

            public void Read(ref BinaryReader br) {
                version = br.ReadUInt32();
                if(version>=0x24)
                    unknown1 = br.ReadUInt32();
                worldID = br.ReadUInt32();
                if(version >= 0x26) {
                    spawnPosition.position.ReadFromBinaryReader(ref br);
                    spawnPosition.rotation.ReadFromBinaryReader(ref br);
                }
                scenes = new LUZScene[(version < 0x25 ? br.ReadByte() : br.ReadUInt32())];
                for(int i=0; i<scenes.Length; ++i) {
                    scenes[i].Read(ref br, this);
                }
                unknown2 = br.ReadByte();
                terrainFilename = StringUtils.ReadString(ref br);
                terrainName = StringUtils.ReadString(ref br);
                terrainDescription = StringUtils.ReadString(ref br);
                sceneTransitions = new SceneTransition[br.ReadUInt32()];
                for (int i = 0; i < sceneTransitions.Length; ++i) {
                    sceneTransitions[i].Read(ref br, this);
                }
                lengthOfRestOfFileInBytes = br.ReadUInt32();
                unknown3 = br.ReadUInt32();
                paths = new LUZPath.Path[br.ReadUInt32()];
                for(int i = 0; i<paths.Length; ++i) {
                    paths[i] = LUZPath.Path.Create(ref br);
                    paths[i].Read(ref br);
                }
            }
        }
    }
}
