using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xipho_HAL_LU_LVL_JSON_Generator.CommonDatatypes;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public static class LUZPath {
        public class Path {
            public UInt32 pathVersion;
            public string pathName;
            public PathType pathType;
            public UInt32 unknown1;
            public PathBehavior pathBehavior;
            public Waypoint[] waypoints;

            static public Path Create(ref BinaryReader br) {

                // We first have to test which path type we have
                // so we go to the path version, read it and then
                // go back to the point the path begins.
                long entryPoint = br.BaseStream.Position;

                br.ReadUInt32(); // Skip pathVersion
                br.BaseStream.Position += 2*br.ReadByte()+1; // Skip pathName

                PathType ourPathType = (PathType)br.ReadUInt32();
                br.BaseStream.Position = entryPoint; // We got it! Go back.

                switch (ourPathType) {
                    case PathType.Movement: {
                            return new PathMovement();
                        }
                    case PathType.MovingPlatform: {
                            return new PathMovingPlatform();
                        }
                    case PathType.Property: {
                            return new PathProperty();
                        }
                    case PathType.Camera: {
                            return new PathCamera();
                        }
                    case PathType.Spawner: {
                            return new PathSpawner();
                        }
                    case PathType.Showcase: {
                            return new PathShowcase();
                        }
                    case PathType.Race: {
                            return new PathRace();
                        }
                    case PathType.Rail: {
                            return new PathRail();
                        }
                    default: {
                            throw new NotImplementedException("Unknown PathType: " + ourPathType.ToString());
                        }
                }
            }

            public void CreateWaypoints<T>(ref BinaryReader br, Path myPath) where T : Waypoint {
                waypoints = new T[br.ReadUInt32()];
                for (int i = 0; i < waypoints.Length; ++i) {
                    waypoints[i] = Activator.CreateInstance<T>();
                    waypoints[i].Read(ref br, myPath);
                }
            }

            public virtual void Read(ref BinaryReader br) { }

            public void ReadBase(ref BinaryReader br) {
                pathVersion = br.ReadUInt32();
                pathName = StringUtils.ReadWString(ref br);
                pathType = (PathType)br.ReadUInt32();
                unknown1 = br.ReadUInt32();
                pathBehavior = (PathBehavior)br.ReadUInt32();
            }
        }

        public class Waypoint {
            public Vector3 position;

            public virtual void Read(ref BinaryReader br, Path myPath) { }

            public void ReadBase(ref BinaryReader br) {
                position.ReadFromBinaryReader(ref br);
            }

            public void checkType(PathType A, PathType B) {
                if (A != B) {
                    throw new UnauthorizedAccessException("Application tried to use a wrong WaypointType!");
                }
            }

            public void ReadConfig(ref Dictionary<string, string> configData, ref BinaryReader br) {
                if (configData == null) configData = new Dictionary<string, string>();
                UInt32 len = br.ReadUInt32();
                for(int i = 0; i < len; ++i)
                    configData.Add(StringUtils.ReadWString(ref br), StringUtils.ReadWString(ref br));
            }
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

        public class PathMovement : Path {
            public PathMovement() { }

            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);

                CreateWaypoints<WaypointMovement>(ref br, this);
            }
        }

        public class WaypointMovement : Waypoint {
            public Dictionary<string, string> configData;

            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.Movement);

                ReadConfig(ref configData, ref br);
            }
        }

        public class PathMovingPlatform : Path {
            public PathMovingPlatform() { }

            public byte unknown2;
            public string movingPlatformTravelSound;

            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);
                if (pathVersion >= 18) {
                    unknown2 = br.ReadByte();
                }
                else if (pathVersion >= 13) {
                    movingPlatformTravelSound = StringUtils.ReadWString(ref br);
                }

                CreateWaypoints<WaypointMovingPlatform>(ref br, this);
            }
        }

        public class WaypointMovingPlatform : Waypoint {
            public Quaternion rotation;
            public bool lockPlayerUntilNextWaypoint;
            public float speed;
            public float wait;
            public string departSound;
            public string arriveSound;

            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.MovingPlatform);

                rotation.ReadFromBinaryReader(ref br, true);
                lockPlayerUntilNextWaypoint = br.ReadBoolean();
                speed = br.ReadSingle();
                wait = br.ReadSingle();
                if (myPath.pathVersion >= 13) {
                    departSound = StringUtils.ReadWString(ref br);
                    arriveSound = StringUtils.ReadWString(ref br);
                }
            }
        }

        public class PathProperty : Path {
            public PathProperty() { }

            public enum PropertyRentalTimeUnit : Int32 {
                forever = 0,
                seconds,
                minutes,
                hours,
                days,
                weeks,
                months,
                years
            }

            public enum PropertyAchivement : Int32 {
                none = 0,
                builder,
                craftsman,
                senior_builder,
                journeyman,
                master_builder,
                architect,
                senior_architect,
                master_architect,
                visionary,
                exemplar
            }

            public Int32 unknown2;
            public Int32 price;
            public Int32 rentalTime;
            public Int64 associatedZone;
            public string displayName;
            public string displayDescription;
            public Int32 unknown3;
            public Int32 cloneLimit;
            public float reputationMultiplier;
            public PropertyRentalTimeUnit rentalTimeUnit;
            public PropertyAchivement achievementRequired;
            public Vector3 playerZoneCoordinate;
            public float maxBuildingHeight;

            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);

                unknown2 = br.ReadInt32();
                price = br.ReadInt32();
                rentalTime = br.ReadInt32();
                associatedZone = br.ReadInt64();
                displayName = StringUtils.ReadWString(ref br);
                displayDescription = StringUtils.ReadWString(ref br);
                unknown3 = br.ReadInt32();
                cloneLimit = br.ReadInt32();
                reputationMultiplier = br.ReadSingle();
                rentalTimeUnit = (PropertyRentalTimeUnit)br.ReadInt32();
                achievementRequired = (PropertyAchivement)br.ReadInt32();
                playerZoneCoordinate.ReadFromBinaryReader(ref br);
                maxBuildingHeight = br.ReadSingle();

                CreateWaypoints<WaypointProperty>(ref br, this);
            }
        }

        public class WaypointProperty : Waypoint {
            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.Property);
            }
        }

        public class PathCamera : Path {
            public PathCamera() { }

            public string nextPath;
            public byte unknown2;

            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);

                nextPath = StringUtils.ReadWString(ref br);
                if(pathVersion >= 14)
                    unknown2 = br.ReadByte();

                CreateWaypoints<WaypointCamera>(ref br, this);
            }
        }

        public class WaypointCamera : Waypoint {
            public Quaternion rotation;
            public float timeInSeconds;
            public float unknown1;
            public float tension;
            public float continuity;
            public float bias;

            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.Camera);

                rotation.ReadFromBinaryReader(ref br, true);
                timeInSeconds = br.ReadSingle();
                unknown1 = br.ReadSingle();
                tension = br.ReadSingle();
                continuity = br.ReadSingle();
                bias = br.ReadSingle();
            }
        }

        public class PathSpawner : Path {
            public PathSpawner() { }

            public UInt32 spawnedLOT;
            public UInt32 respawnTime;
            public Int32 maxToSpawn;
            public UInt32 numberToMaintain;
            public Int64 spawnerObjID;
            public bool activateSpawnerNetworkOnLoad;

            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);

                spawnedLOT = br.ReadUInt32();
                respawnTime = br.ReadUInt32();
                maxToSpawn = br.ReadInt32();
                numberToMaintain = br.ReadUInt32();
                spawnerObjID = br.ReadInt64();
                activateSpawnerNetworkOnLoad = br.ReadBoolean();

                CreateWaypoints<WaypointSpawner>(ref br, this);
            }
        }

        public class WaypointSpawner : Waypoint {
            public Quaternion rotation;
            public Dictionary<string, string> configData;

            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.Spawner);

                rotation.ReadFromBinaryReader(ref br, true);

                ReadConfig(ref configData, ref br);
            }
        }

        public class PathShowcase : Path {
            public PathShowcase() { }

            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);

                CreateWaypoints<WaypointShowcase>(ref br, this);
            }
        }

        public class WaypointShowcase : Waypoint {
            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.Showcase);

            }
        }

        public class PathRace : Path {
            public PathRace() { }
            
            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);

                CreateWaypoints<WaypointRace>(ref br, this);
            }
        }

        public class WaypointRace : Waypoint {
            public Quaternion rotation;
            public byte unknown1;
            public byte unknown2;
            public float unknown3;
            public float unknown4;
            public float unknown5;

            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.Race);

                rotation.ReadFromBinaryReader(ref br, true);
                unknown1 = br.ReadByte();
                unknown2 = br.ReadByte();
                unknown3 = br.ReadSingle();
                unknown4 = br.ReadSingle();
                unknown5 = br.ReadSingle();
            }
        }

        public class PathRail : Path {
            public PathRail() { }

            public override void Read(ref BinaryReader br) {
                ReadBase(ref br);

                CreateWaypoints<WaypointRail>(ref br, this);
            }
        }

        public class WaypointRail : Waypoint {
            public Quaternion rotation;
            public float unknown1;
            public Dictionary<string, string> configData;

            public override void Read(ref BinaryReader br, Path myPath) {
                ReadBase(ref br);
                checkType(myPath.pathType, PathType.Rail);

                rotation.ReadFromBinaryReader(ref br, true);
                if(myPath.pathVersion >= 17) {
                    unknown1 = br.ReadSingle();
                }

                ReadConfig(ref configData, ref br);
            }
        }
    }
}