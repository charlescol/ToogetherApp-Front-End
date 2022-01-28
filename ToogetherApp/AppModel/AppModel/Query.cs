using System;
using System.Collections.Generic;
using System.Text;

namespace AppModel
{
    namespace Query
    {
        public class BasicContent
        {
            public object Data { get; set; }
            public string Key { get; set; }
        }

        public class SendBlobData
        {
            public byte[] Data { get; set; }
            public string NameWithExt { get; set; }
            public string Container { get; set; }
        }
    }

}
