using System.Collections.Generic;

namespace IotDemo.Serial
{
    public static class CrcModbus
    {
        // Compute the MODBUS RTU CRC
        /// <summary>
        /// 获取CRC字节数组
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static byte[] Get(byte[] buf)
        {
            var crc = 0xFFFF;

            for (int pos = 0; pos < buf.Length; pos++)
            {
                crc ^= buf[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {      // If the LSB is set
                        crc >>= 1;                    // Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                        crc >>= 1;                    // Just shift right
                }
            }
            // Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)

            var bytes = new List<byte>();
            bytes.Add((byte)crc);
            crc >>= 8;
            bytes.Add((byte)crc);
            return bytes.ToArray();
        }
    }
}