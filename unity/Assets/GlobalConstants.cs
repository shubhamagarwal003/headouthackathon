using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets
{
    static class GlobalConstants
    {
        //public static Vector3[][] positions = { { new Vector3(-12.87f, 5.5f, 5.16f), new Vector3(281.962f, 112.714f, 175.0805f), new Vector3(1, 1, 1)},
        //{ new Vector3(-13.15f, -5.53f, 4.93f), new Vector3(0.1434f, 26.8104f, 276.7333f), new Vector3(1, 1, 1) },
        //{ new Vector3(13.57f, 4.88f, 5.49f), new Vector3(289.6097f, 244.2556f, 183.997f), new Vector3(1, 1, 1) },
        //{ new Vector3(12.51f, -5.66f, 4.65f), new Vector3(285.1478f, 64.5125f, 3.1622f), new Vector3(1, 1, 1) },
        //{ new Vector3(0f, 0f, 21.3f), new Vector3(270.4f, 180f, 180f), new Vector3(3.5f, 3.5f, 3.5f) }
        //};
        public static Vector3[][] positions = { new Vector3[3] { new Vector3(-12.87f, 5.5f, 5.16f), new Vector3(281.962f, 112.714f, 175.0805f), new Vector3(1, 1, 1) }, new Vector3[3] { new Vector3(-13.15f, -5.53f, 4.93f), new Vector3(0.1434f, 26.8104f, 276.7333f), new Vector3(1, 1, 1) }, new Vector3[3] { new Vector3(13.57f, 4.88f, 5.49f), new Vector3(289.6097f, 244.2556f, 183.9597f), new Vector3(1, 1, 1) }, new Vector3[3] { new Vector3(12.51f, -5.66f, 4.65f), new Vector3(285.1478f, 64.5125f, 3.1622f), new Vector3(1, 1, 1) }, new Vector3[3] { new Vector3(0f, 0f, 21.3f), new Vector3(270.4f, 180f, 180f), new Vector3(3.5f, 3.5f, 3.5f) } };
        public static string[] positionMain = new string[] { "wiki", "video", "review", "map", "image" };
    }
}
