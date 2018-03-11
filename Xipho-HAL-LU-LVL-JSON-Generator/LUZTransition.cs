using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xipho_HAL_LU_LVL_JSON_Generator.CommonDatatypes;
using System.IO;
using Xipho_HAL_LU_LVL_JSON_Generator.WorldStructure;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public static class LUZTransition {
        public struct SceneTransition {
            public string sceneTransitionName;
            public SceneTransitionPoint[] sceneTransitionPoints;
            
            public void Read(ref BinaryReader br, LUZData myLUZ) {
                if(myLUZ.version<0x25) {
                    sceneTransitionName = StringUtils.ReadString(ref br);
                }
                sceneTransitionPoints = new SceneTransitionPoint[(myLUZ.version <= 0x21 || myLUZ.version >= 0x27) ? 2 : 5];
                for(int i = 0; i < sceneTransitionPoints.Length; ++i) {
                    sceneTransitionPoints[i].Read(ref br);
                }
            }
        }
        public struct SceneTransitionPoint {
            public UInt64 sceneID;
            public Vector3 position;

            public void Read(ref BinaryReader br) {
                sceneID = br.ReadUInt64();
                position.ReadFromBinaryReader(ref br);
            }
        }
    }
}
