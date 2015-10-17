using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public interface IAngularInExpression<TElement, TParent> : IAngularInExpressionNongeneric
    {
        NgCollectionContext<TElement, TParent> Context { get; }

        string Tracking { get; set; }
    }

    public interface IAngularInExpressionNongeneric : IAngularExpression
    {
        
    }
}
