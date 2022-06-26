using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    public class ChainData
    {
        private static ChainData _instance;
        public Dictionary<string, Collection<string>> userPostionHandler = new Dictionary<string, Collection<string>>();

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