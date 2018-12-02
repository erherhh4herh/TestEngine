using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine.Pipeline
{
    public enum AssetType
    {
        Unknown = 0,
        Texture = 1,
        Material = 2,
        Shader = 3,
        Audio = 4
    }

    public class Asset
    {
        // GUID or some shit
        public int ID;
        public string Name;
        public string Path;
        // In bytes
        public int Size;
        public AssetType Type;
    }
}
