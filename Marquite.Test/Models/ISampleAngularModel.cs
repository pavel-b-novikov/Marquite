using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marquite.Angular;

namespace Marquite.Test.Models
{
    public interface ISampleAngularModel
    {
        string UserId { get; set; }

        string UserName { get; set; }

        int Age { get; set; }

        bool Gender { get; set; }

        void SaveResults();

        void HandleMove(IEvent mouseMoveEvent);
    }
}