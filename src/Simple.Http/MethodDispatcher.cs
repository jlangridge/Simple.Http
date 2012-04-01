using System;
using System.Dynamic;

namespace Simple.Http
{
    public class MethodDispatcher : DynamicObject
    {
        public MethodDispatcher(ITransport transport)
        {
            Transport = transport;
        }

        protected ITransport Transport { get; private set; }

        /// <summary>
        /// Provides the implementation for operations that invoke a member. Classes derived from the <see cref="T:System.Dynamic.DynamicObject"/> class can override this method to specify dynamic behavior for operations such as calling a method.
        /// </summary>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a language-specific run-time exception is thrown.)
        /// </returns>
        /// <param name="binder">Provides information about the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the statement sampleObject.SampleMethod(100), where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject"/> class, binder.Name returns "SampleMethod". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param><param name="args">The arguments that are passed to the object member during the invoke operation. For example, for the statement sampleObject.SampleMethod(100), where sampleObject is derived from the <see cref="T:System.Dynamic.DynamicObject"/> class, <paramref name="args[0]"/> is equal to 100.</param><param name="result">The result of the member invocation.</param>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name.StartsWith("Get", StringComparison.InvariantCultureIgnoreCase))
            {
                var request = Transport.CreateRequest();
                request.HttpMethod = System.Net.WebRequestMethods.Http.Get;
                var argCount = 0;
                foreach (var argumentName in binder.CallInfo.ArgumentNames)
                {
                    request.QueryString += string.Format("{0}={1}", argumentName, args[argCount++]);
                }

                
                result = new object();
                return true;
            }
            return base.TryInvokeMember(binder, args, out result);
        }

    }
}
