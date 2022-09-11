using Microsoft.VisualBasic;
using System;

namespace SecretOfManaSaveEditor {
    public static class Globals {
        /// <summary>
        /// Prompts the user to enter a number as an int
        /// </summary>
        /// <param name="prompt">The message to display on the prompt</param>
        /// <param name="title">The title for the input dialog</param>
        /// <param name="startValue">The starting value in the input box</param>
        /// <param name="minValue">The minimum accepted value</param>
        /// <param name="maxValue">The maximum accepted value</param>
        /// <param name="newValue">The new value that the user entered</param>
        /// <returns>True if the user entered a new value within the given range, or False if the user cancelled or entered a blank string</returns>
        /// <remarks>Set minValue and maxValue to the same value (eg both to 0) to disable range checking</remarks>
        public static bool InputNumber(string prompt, string title, int startValue, int minValue, int maxValue, out int newValue) {
            // Supplement the prompt if a range was given
            if (minValue != maxValue) {
                prompt += $"\r\n\r\nMinimum: {minValue:N0}\r\nMaximum: {maxValue:N0}";
            }

            while (true) {
                // Get a new value from the user
                string strValue = Interaction.InputBox(prompt, title, startValue.ToString());

                // Trim thousands separator, just in case they copy/pasted from somewhere
                strValue = strValue.Replace(",", "");

                // If they aborted, then return false
                if (string.IsNullOrWhiteSpace(strValue)) {
                    newValue = startValue;
                    return false;
                }

                // Try to parse their value as an integer, and return true if it's within the acceptable range
                if (int.TryParse(strValue, out newValue)) {
                    if ((minValue == maxValue) || ((newValue >= minValue) && (newValue <= maxValue))) {
                        return true;
                    }
                }

                // If we get here it means it wasn't an int, or wasn't within the range, so we'll loop and prompt again
            }
        }

        /// <summary>
        /// Prompts the user to enter a number as a byte
        /// </summary>
        /// <param name="prompt">The message to display on the prompt</param>
        /// <param name="title">The title for the input dialog</param>
        /// <param name="startValue">The starting value in the input box</param>
        /// <param name="minValue">The minimum accepted value</param>
        /// <param name="maxValue">The maximum accepted value</param>
        /// <param name="newValue">The new value that the user entered</param>
        /// <returns>True if the user entered a new value within the given range, or False if the user cancelled or entered a blank string</returns>
        /// <remarks>Set minValue and maxValue to the same value (eg both to 0) to disable range checking</remarks>
        public static bool InputNumber(string prompt, string title, int startValue, int minValue, int maxValue, out byte newValue) {
            bool result = InputNumber(prompt, title, startValue, minValue, maxValue, out int intValue);
            newValue = Convert.ToByte(intValue);
            return result;
        }
    }
}
