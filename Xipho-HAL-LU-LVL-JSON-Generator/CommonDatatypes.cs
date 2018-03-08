using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    namespace CommonDatatypes {
        public struct Vector3 {
            public float x;
            public float y;
            public float z;

            public void ReadFromBinaryReader(ref BinaryReader br) {
                x = br.ReadSingle();
                y = br.ReadSingle();
                z = br.ReadSingle();
            }
        }
        public struct Quaternion {
            public float x;
            public float y;
            public float z;
            public float w;

            public void ReadFromBinaryReader(ref BinaryReader br, bool readWFirst = false) {
                if (readWFirst)
                    w = br.ReadSingle();
                x = br.ReadSingle();
                y = br.ReadSingle();
                z = br.ReadSingle();
                if (!readWFirst)
                    w = br.ReadSingle();
            }
        }

        public struct Coordinate {
            public Vector3 position;
            public Vector3 rotation;
        }
    }
}
