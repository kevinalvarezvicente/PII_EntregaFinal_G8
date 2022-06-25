using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    public class ChainData
    {
        private static ChainData _instance;
        public Dictionary<string, string> userPostionHandler = new Dictionary<string, string>();

        public ChainData()
        {

        }
        public static ChainData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChainData();
                }
                return _instance;
            }
        }
    }
}