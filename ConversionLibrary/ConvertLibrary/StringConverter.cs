using System;

namespace ConvertLibrary
{
    public class StringConverter
    {
        /// <summary>
        /// シングルクォーテーションを含む文字列の場合、もう一つ追加する
        /// </summary>
        /// <param name="text">文字列</param>
        /// <returns>変換後の文字列</returns>
        public string AddSingleQuotation(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            var convertText = text.Replace("'", "''");

            return convertText;
        }
    }
}