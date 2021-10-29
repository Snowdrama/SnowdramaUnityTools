using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama
{
    public class SnowHash : MonoBehaviour
    {
        /// <summary>
        /// A C# implementatiion based on the example hash function
        /// in Squirrel Eiserloh's GDC Talk 
        /// https://www.youtube.com/watch?v=LWFzPP8ZbdU
        /// </summary>
        /// <param name="position">Some positional value in the noise array</param>
        /// <param name="seed">The noise functions seed</param>
        /// <returns></returns>
        public uint Squirrel3(int position, uint seed = 69420)
        {
            const uint NOISE_1 = 0xB5297A4D;
            const uint NOISE_2 = 0x68E31DA4;
            const uint NOISE_3 = 0x1B56C4E9;

            uint mangled = (uint)position;
            mangled *= NOISE_1;
            mangled += seed;
            mangled ^= mangled >> 8;
            mangled *= NOISE_2;
            mangled ^= mangled << 8;
            mangled *= NOISE_3;
            mangled ^= mangled >> 8;
            return mangled;
        }


        /// <summary>
        /// A modified 64 bit version of the Squirrel3 hash function from:
        /// Squirrel Eiserloh's GDC Talk 
        /// https://www.youtube.com/watch?v=LWFzPP8ZbdU
        /// 
        /// Totally untested on how random it actually is, how performant it is
        /// or how quality the random is.
        /// 
        /// This function is intended to be a joke... unless it works... :P
        /// </summary>
        /// <param name="position">Some positional value in the noise array</param>
        /// <param name="seed">The noise functions seed</param>
        /// <returns></returns>
        public long Snow64(int position, long seed = 69420717580085)
        {
            const long NOISE_1 = 0xB5297A4D;
            const long NOISE_2 = 0x68E31DA4;
            const long NOISE_3 = 0x1B56C4E9;

            long mangled = (long)position;
            mangled *= NOISE_1;
            mangled += seed;
            mangled ^= mangled >> 16;
            mangled *= NOISE_2;
            mangled ^= mangled << 16;
            mangled *= NOISE_3;
            mangled ^= mangled >> 16;
            return mangled;
        }
    }

}