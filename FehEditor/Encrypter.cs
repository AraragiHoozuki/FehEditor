using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DSDecmp.Formats.Nitro;

namespace FehEditor
{
    class Encrypter
    {
        private static byte[] LZ11Compress(byte[] decompressed)
        {
            using (MemoryStream dstream = new MemoryStream(decompressed))
            {
                using (MemoryStream cstream = new MemoryStream())
                {
                    (new LZ11()).Compress(dstream, decompressed.Length, cstream);
                    return cstream.ToArray();
                }
            }
        }

        public static byte[] EncryptAndCompress(byte[] filedata)
        {
            var xorkey = BitConverter.ToUInt32(filedata, 0) >> 8;
            xorkey *= 0x8083;
            var lz = filedata.Skip(4).ToArray();
            lz = LZ11Compress(lz);
            var output = new byte[4 + lz.Length + (lz.Length % 4 == 0 ? 0 : 4 - lz.Length % 4)];
            filedata.Take(4).ToArray().CopyTo(output, 0);
            lz.CopyTo(output, 4);
            for (var i = 8; i < output.Length; i += 0x4)
            {
                BitConverter.GetBytes(BitConverter.ToUInt32(output, i) ^ xorkey).CopyTo(output, i);
                xorkey = BitConverter.ToUInt32(output, i);
            }
            return output;
        }
    }
}
