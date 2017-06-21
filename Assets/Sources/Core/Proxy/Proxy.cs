namespace Assets.Sources.Core.Proxy
{
    public class Proxy
    {
        public static Proxy Instance = new Proxy();

        private IInvocationHandler _invocationHandler;
        private object _target;
        private string _method;
        private object[] _args;

        private Proxy()
        {
        }

        public Proxy SetInvocationHandler(IInvocationHandler invocationHandler)
        {
            _invocationHandler = invocationHandler;
            return this;
        }

        public Proxy SetTarget(object target)
        {
            _target = target;
            return this;
        }

        public Proxy SetMethod(string method)
        {
            _method = method;
            return this;
        }

        public Proxy SetArgs(object[] args)
        {
            _args = args;
            return this;
        }

        public object Invoke()
        {
            var methodInfo = _target.GetType().GetMethod(_method);
            return _invocationHandler.Invoke(_target, methodInfo, _args);
        }
    }
}
