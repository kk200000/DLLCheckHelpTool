using System;
using System.Collections.Generic;
using System.Text;

namespace dllCheck
{
    public class DLLInfo
    {
        public string AppKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string downloadUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string engineVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string git_version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string md5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string version { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public List<DLLInfo> data { get; set; }
    }

    public class RootData
    {
        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ret { get; set; }
    }
}
