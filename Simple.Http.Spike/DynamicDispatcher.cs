using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Simple.Http.Spike
{
    public class DynamicDispatcher : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.Write(binder.Name);
            return base.TryInvokeMember(binder, args, out result);
        }
    }
}
