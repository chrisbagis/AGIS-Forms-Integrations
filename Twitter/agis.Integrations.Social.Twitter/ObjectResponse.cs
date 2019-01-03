using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Social.Twitter
{
    public class ObjectResponse<T>: RestResponse
    {
        public T Result { get; set; }
    }
}
