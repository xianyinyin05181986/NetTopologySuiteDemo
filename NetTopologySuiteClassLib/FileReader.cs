using NetTopologySuite.IO.ShapeFile.Extended;
using System;

namespace NetTopologySuiteClassLib
{
    public class FileReader
    {
        ILog _log;
        /// <summary>
        /// simple interface with a Log (string message)
        /// </summary>
        public FileReader()
        {
            _log = new Logger();
        }
        /// <summary>
        /// simple interface with a Log (string message)
        /// </summary>
        public FileReader(ILog log)
        {
            _log = log;
        }


        ShapeDataReader reader;
        private double sum;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="shapeFileName"></param>
        /// <returns></returns>
        public double GetAttributeValueSum(string attributeName, string shapeFileName)
        {
            SetupReader(shapeFileName);

            LogEachRow(attributeName);

            return sum;
        }
        /// <summary>
        /// open the shapefile
        /// </summary>
        /// <param name="shapeFileName"></param>
        public void SetupReader(string shapeFileName)
        {
            try
            {
                reader = new ShapeDataReader(shapeFileName);

            }
            catch (Exception)
            {
                Logging($"{shapeFileName} might be an invalid path");
                throw;
            }
        }
        /// <summary>
        /// Read each row in the file and sum up the value in each row for the attribute specified 
        /// </summary>
        /// <param name="attributeName"></param>
        public void LogEachRow(string attributeName)
        {
            if (String.IsNullOrEmpty(attributeName) || String.IsNullOrWhiteSpace(attributeName))
                throw new InvalidOperationException("attributeName cant be null or empty");

            try
            {
                sum = 0;
                var mbr = reader.ShapefileBounds;

                var result = reader.ReadByMBRFilter(mbr);

                var coll = result.GetEnumerator();

                while (coll.MoveNext())
                {
                    var item = coll.Current;
                    try
                    {
                        foreach (string att in item.Attributes.GetNames())
                        {


                            var obj = item.Attributes.GetOptionalValue(attributeName);
                            ///We would like to have the value for each row logged
                            if (obj is double num)
                            {
                                Logging($"[Item:{item.FeatureId}]  contains numberic value of {num} for [Attribute:{attributeName}]");
                                sum += num;

                            }
                            else if (obj == null)
                            {
                                Logging($"[Item:{item.FeatureId}] does not contains a value of [Attribute:{attributeName}] ");
                            }
                            else
                            {
                                Logging($"[Item:{item.FeatureId}] contains a non-numberic value of {obj} for [Attribute:{attributeName}]. ");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Logging($"Error occurs while reading data from {item.FeatureId.ToString()}");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Logging Logic it is here
        /// </summary>
        /// <param name="message"></param>
        public void Logging(string message)
        {
            _log.Log = String.Format("{0}{1}{2}", _log.Log, Environment.NewLine, message);
        }
        /// <summary>
        /// Displaying the log
        /// </summary>
        /// <returns>Log Content</returns>
        public string ShowLog()
        {
            return _log.Log;
        }
    }
}
