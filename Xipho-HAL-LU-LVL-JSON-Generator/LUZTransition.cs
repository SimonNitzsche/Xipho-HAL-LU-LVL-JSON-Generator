using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xipho_HAL_LU_LVL_JSON_Generator.CommonDatatypes;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public static class LUZTransition {
        public struct SceneTransition {
            public string sceneTransitionName;
            public SceneTransitionPoints[] sceneTransitionPoints;
        }
        public struct SceneTransitionPoints {
            public UInt64 sceneID;
            public Vector3 position;
        }
    }
}
