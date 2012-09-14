using System;
using System.Collections.Generic;

namespace Services
{
    public class StringService
    {
        /// <summary>
        /// Find all indexes of a substring inside a baseString. Search is case insensitive.
        /// </summary>
        /// <returns>Collection of all found indexes</returns>
        public IEnumerable<int> GetAllIndexesOf(string baseString, string substring)
        {
            ValidateInput(baseString, substring);

            baseString = baseString.ToLower();
            substring = substring.ToLower();

            var foundIndexes = new List<int>();
            var indexStart = 0;
            bool isComparing = false;

            // The basic idea is to iterate over all characters in a baseString just once.
            // When a first character of a substring is found, try to match all other characters later on.
            for (int i = 0; i < baseString.Length; i++)
            {
                // Begin comparsion of basestring and substring - compare first character
                if (!isComparing && baseString[i] == substring[0])
                {
                    indexStart = i;
                    isComparing = true;
                }

                // compare all other then first characters between string and substring
                if (isComparing && baseString[i] == substring[i - indexStart])
                {
                    if (i - indexStart == substring.Length - 1)
                    {
                        // It's a substring
                        foundIndexes.Add(indexStart + 1);
                        isComparing = false;
                    }
                }
                else
                {
                    isComparing = false;
                    indexStart = 0;
                }
            }

            return foundIndexes;
        }

        /// <summary>
        /// Validates an input against null values.
        /// </summary>
        /// <exception cref="ArgumentException">Throws when input is incorrect.</exception>
        private void ValidateInput(string baseString, string substring)
        {
            if (baseString == null)
            {
                throw new ArgumentException("BaseString can not be null.");
            }

            if (substring == null)
            {
                throw new ArgumentException("Substring can not be null.");
            }
        }
    }
}
