using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Humanis.Infrastructure.CrossCutting
{
    public interface IApplicationSettings
    {
         MongoDBSettings MongoDBSettings { get; set; }
    }
}
