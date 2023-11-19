using System;
using System.IO;
using System.Collections.Generic;

namespace DesignPatterns
{
    //Example 1
    public class StudentManager
    {
        private static StudentManager _instance;
        private Dictionary<string, string> students;

        private StudentManager()
        {
            // private constructor
            students = new Dictionary<string, string>();
        }

        public static StudentManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentManager();
                }

                return _instance;
            }
        }

        public string? GetStudent(string key)
        {
            if (students.ContainsKey(key))
            {
                return students[key];
            }
            else
            {
                return null; 
            }
        }

        public void SetStudent(string key, string value)
        {
            students[key] = value;
        }
    }
    //Example 2
    public class Logger
    {
        private static Logger _instance;
        private string logFilePath;

        private Logger()
        {
            logFilePath = "log.txt"; // Default log file path
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {

                    _instance = new Logger();

                }
                return _instance;
            }
        }

        public void LogMessage(string message)
        {
            // Log the message to the configured log file
            string formattedMessage = $"{DateTime.Now}: {message}\n";
            File.AppendAllText(logFilePath, formattedMessage);
        }

    }

}
