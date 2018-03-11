using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xipho_HAL_LU_LVL_JSON_Generator.WorldStructure;
using Xipho_HAL_LU_LVL_JSON_Generator.LUZSceneStruct;
using Newtonsoft.Json;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public static class WorldLoader {
        public static class LUZFile {
            private static BinaryReader reader = null;
            private static string fileName = null;

            private static LUZData data;

            public static void Open(string filename) {
                if(reader==null&&fileName==null) {
                    fileName = filename;
                    reader = new BinaryReader(File.Open(fileName, FileMode.Open));
                    data = new LUZData();
                    data.Read(ref reader);
                    File.WriteAllText(data.terrainDescription+".json",JsonConvert.SerializeObject(data));
                } else {
                    Close();
                    throw new Exception("Another world is already open");
                }
            }

            public static void Close() {
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

            public static LUZData GetLUZData() {
                return data;
            }
        }
        public class LVLFile {
            public void Close() {

            }
        }
    }
}
