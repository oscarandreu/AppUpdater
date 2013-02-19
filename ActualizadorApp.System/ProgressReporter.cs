////-----------------------------------------------------------------------
//// <copyright file="ProgressReporter.cs" company="ApexSQL">
////     Copyright (c) ApexSQL LLC.  All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
//using System;

//namespace ApexSql.Diff
//{
//    /// <summary>
//    /// Simple class to show progress in console
//    /// </summary>
//    public class ProgressReporter : IProgressInfo
//    {
//        private bool stopNeeded;
//        public bool SuppressOutput
//        {
//            get { return suppressOutput; }
//            set { suppressOutput = value; }
//        }
//        public bool suppressOutput;

//        /// <summary>
//        /// Set progress text
//        /// </summary>
//        /// <param name="text">Progress Text</param>
//        public void SetText(string text)
//        {
//            Console.WriteLine(text);
//        }

//        /// <summary>
//        /// Set min progress value
//        /// </summary>
//        /// <param name="minValue">Min progress value</param>
//        public void SetMin(int minValue)
//        {
//        }

//        /// <summary>
//        /// Set max progress value
//        /// </summary>
//        /// <param name="maxValue">Max progress value</param>
//        public void SetMax(int maxValue)
//        {
//        }

//        /// <summary>
//        /// Increment progress
//        /// </summary>
//        public void SetTo(int value)
//        {
//        }

//        /// <summary>
//        /// Increment progress
//        /// </summary>
//        public void Inc()
//        {
//        }

//        /// <summary>
//        /// Return true if stop needed
//        /// </summary>
//        public bool StopNeeded
//        {
//            get { return stopNeeded; }
//            set { stopNeeded = value; }
//        }
//    }
//}
