using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public static class LUZPath {
        public struct Path {
            public UInt32 pathVersion;
            public string pathName;
            public PathType pathType;
            public UInt32 unknown1;
            public PathBehavior pathBehavior;
            /* Todo: PathPropery (The following) */
        }
        public enum PathType : UInt32 {
            Movement = 0,
            MovingPlatform,
            Property,
            Camera,
            Spawner,
            Showcase,
            Race,
            Rail
        }
        public enum PathBehavior : UInt32 {
            Loop = 0,
            Bounce,
            Rail
        }
    }
}
