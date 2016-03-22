using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public class NgCollectionContext<TModel, TParent> : NgContext<NgCollectionContextWrapper<TModel,TParent>>
    {
        public NgCollectionContext(string modelName = null) : base(null,modelName)
        {
            
        }
    }
}
