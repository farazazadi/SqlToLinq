using System;
using System.Drawing;
using FastColoredTextBoxCore;

namespace SqlToLinq.WinUi.Extensions
{
    public static class FastColoredTextBoxExt
    {
        public enum LogType
        {
            Info,
            Warning,
            Error,
            Text
        }


        public static void Log(this FastColoredTextBox fastColoredTextBox, string text, LogType logType)
        {

            fastColoredTextBox.BeginUpdate();
            
            fastColoredTextBox.AppendText($"-- {logType.ToString()}: {text}\r\n");

            fastColoredTextBox.GoEnd();
            

            fastColoredTextBox.EndUpdate();

        }

    }

}
