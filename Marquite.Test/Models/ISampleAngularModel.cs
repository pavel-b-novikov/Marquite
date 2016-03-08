using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marquite.Angular;

namespace Marquite.Test.Models
{
    public interface ISampleAngularModel
    {
        SampleFormModel User { get; set; }

        void SaveResults();

        void HandleMove(IEvent mouseMoveEvent);

        void Simple(int v);
    }
}