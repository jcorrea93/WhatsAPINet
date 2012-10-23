﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatsAppApi.Helper
{
    class Func
    {
        public static bool isShort(string value)
        {
            return value.Length < 256;
        }

        public static int strlen_wa(string str)
        {
            int len = str.Length;
            if (len >= 256)
                len = len & 0xFF00 >> 8;
            return len;
        }

        public static string _hex(int val)
        {
            return (val.ToString("X").Length%2 == 0) ? val.ToString("X") : ("0" + val.ToString("X"));
        }

        public static string random_uuid()
        {
            var mt_rand = new Random();
            return string.Format("{0}{1}-{2}-{3}-{4}-{5}{6}{7}",
                                 mt_rand.Next(0, 0xffff), mt_rand.Next(0, 0xffff),
                                 mt_rand.Next(0, 0xffff),
                                 mt_rand.Next(0, 0x0fff) | 0x4000,
                                 mt_rand.Next(0, 0x3fff) | 0x8000,
                                 mt_rand.Next(0, 0xffff), mt_rand.Next(0, 0xffff), mt_rand.Next(0, 0xffff)
                );
        }

        public static string strtohex(string str)
        {
            string hex = "0x";
            for (int i = 0; i < str.Length; i++)
                hex += ((int) str[i]).ToString("x");
            return hex;
        }

        public static string HexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        //function createIcon($file)
        //{
        //    $outfile = "thumb.jpg";
        //    $cmd = "convert $file -resize 100x100 $outfile";
        //    system($cmd);
        //    $fp = fopen($outfile, "r");
        //    $contents = fread($fp, filesize($outfile));
        //    fclose($fp);
        //    $b64 = base64_encode($contents);
        //    $outfile .= "b64";
        //    $fp = fopen($outfile, "w");
        //    fwrite($fp, $b64);
        //    fclose($fp);
        //}

        public static string EncodeTo64(string toEncode, Encoding enc)
        {
            byte[] toEncodeAsBytes = enc.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeTo64(string toDecode, Encoding enc)
        {
            byte[] toDecodeAsBytes = System.Convert.FromBase64String(toDecode);
            string returnValue = enc.GetString(toDecodeAsBytes);
            return returnValue;
        }

//        function startsWith($haystack, $needle , $pos=0){
//    $length = strlen($needle);
//    return (substr($haystack, $pos, $length) === $needle);
//}

//function endsWith($haystack, $needle){
//    $length = strlen($needle);
//    $start  = $length * -1; 
//    return (substr($haystack, $start) === $needle);
//}
    }
}