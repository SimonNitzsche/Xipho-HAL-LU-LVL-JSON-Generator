using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xipho_HAL_LU_LVL_JSON_Generator.WorldStructure;
using Xipho_HAL_LU_LVL_JSON_Generator.LUZSceneStruct;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public static class WorldLoader {
        public static class LUZFile {
            private static BinaryReader reader = null;
            private static string fileName = null;
            
            public static LUZData data { get; private set; }

            private static void Open(string fileName) {
                if(reader==null&&fileName==null) {

                } else {
                    throw new Exception("Another world is already open");
                }
            }

            private static void Close() {
                if(reader!=null) {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }

                fileName = null;
                foreach(LUZScene scene in data.scenes) {
                    scene.sceneData.Close();
                }
            }
        }
        public class LVLFile {
            public void Close() {

            }
        }
    }
}
