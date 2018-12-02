using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    public enum KeyCode
    {
        fuck = 0,
        dat = 1,
        shit = 2
    }

    public static class Input
    {
        // Don't know how the fuck I'm gunna set this
        public static bool GetKey(KeyCode keyCode)
        {
            return false;
        }

        public static bool GetKeyDown(KeyCode keyCode)
        {
            return false;
        }

        public static bool GetKeyUp(KeyCode keyCode)
        {
            return false;
        }
    }
}
