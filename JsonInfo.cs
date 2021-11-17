using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace dllCheck
{
    public class JsonInfo : INotifyPropertyChanged
    {
        private string url;
        private string appkey;
        private string engine_version;
        // 是否被选中
        public bool Ischecked ;

        // 归属于哪个工具哪个环境
        public string belong;

        public string BeLong { get => belong; set { belong = value; NotifyPropertyChanged("BeLong"); } }
        /// <summary>
        /// 
        /// </summary>
        public string URL { get => url; set { url = value; NotifyPropertyChanged("URL"); } }
        /// <summary>
        /// 
        /// </summary>
        public string appKey { get => appkey; set { appkey = value; NotifyPropertyChanged("appKey"); } }
        /// <summary>
        /// 
        /// </summary>
        public string engineVersion { get => engine_version; set { engine_version = value; NotifyPropertyChanged("engineVersion"); } }

       

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
         {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }
}

    public class Data : IEnumerable
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonInfo first_dll { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public Data  data { get; set; }
    }
}
