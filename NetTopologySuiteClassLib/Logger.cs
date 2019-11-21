namespace NetTopologySuiteClassLib
{
    public class Logger : ILog
    {
        private string message;
        public string Log
        {
            get
            {
                if (message == null)
                {
                    message = string.Empty;
                }
                return message;
            }
            set { message = value; }

        }
    }
}