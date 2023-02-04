using Microsoft.AspNetCore.Http;
using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace iMES.Core.Utilities
{
    /// <summary>
    /// 汉字转换为拼音
    /// </summary>
    public static class ChnToPh
    {
        public static string convertCh(string Chstr)
        {
            string result = string.Empty;
            foreach (char item in Chstr)
            {
                try
                {
                    ChineseChar cc = new ChineseChar(item);
                    if (cc.Pinyins.Count > 0 && cc.Pinyins[0].Length > 0)
                    {
                        string temp = cc.Pinyins[0].ToString();
                        result += temp.Substring(0, temp.Length - 1);
                    }
                }
                catch (Exception)
                {
                    result += item.ToString();
                }
            }
            return result;//返回获取到的汉字拼音
        }
    }
}
