namespace Microsoft.Practices.ServiceLocation
{
    using Microsoft.Practices.ServiceLocation.Properties;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public abstract class ServiceLocatorImplBase : IServiceLocator, IServiceProvider
    {
        protected ServiceLocatorImplBase()
        {
        }

        protected abstract IEnumerable<object> DoGetAllInstances(Type serviceType);
        protected abstract object DoGetInstance(Type serviceType, string key);
        protected virtual string FormatActivateAllExceptionMessage(Exception actualException, Type serviceType)
        {
            return string.Format(CultureInfo.CurrentUICulture, Resources.ActivateAllExceptionMessage, new object[] { serviceType.Name });
        }

        protected virtual string FormatActivationExceptionMessage(Exception actualException, Type serviceType, string key)
        {
            return string.Format(CultureInfo.CurrentUICulture, Resources.ActivationExceptionMessage, new object[] { serviceType.Name, key });
        }

        public virtual IEnumerable<TService> GetAllInstances<TService>()
        {
            return new <GetAllInstances>d__0<TService>(-2) { <>4__this = this };
        }

        public virtual IEnumerable<object> GetAllInstances(Type serviceType)
        {
            IEnumerable<object> enumerable;
            try
            {
                enumerable = this.DoGetAllInstances(serviceType);
            }
            catch (Exception exception)
            {
                throw new ActivationException(this.FormatActivateAllExceptionMessage(exception, serviceType), exception);
            }
            return enumerable;
        }

        public virtual TService GetInstance<TService>()
        {
            return (TService) this.GetInstance(typeof(TService), null);
        }

        public virtual TService GetInstance<TService>(string key)
        {
            return (TService) this.GetInstance(typeof(TService), key);
        }

        public virtual object GetInstance(Type serviceType)
        {
            return this.GetInstance(serviceType, null);
        }

        public virtual object GetInstance(Type serviceType, string key)
        {
            object obj2;
            try
            {
                obj2 = this.DoGetInstance(serviceType, key);
            }
            catch (Exception exception)
            {
                throw new ActivationException(this.FormatActivationExceptionMessage(exception, serviceType, key), exception);
            }
            return obj2;
        }

        public virtual object GetService(Type serviceType)
        {
            return this.GetInstance(serviceType, null);
        }

        [CompilerGenerated]
        private sealed class <GetAllInstances>d__0<TService> : IEnumerable<TService>, IEnumerable, IEnumerator<TService>, IEnumerator, IDisposable
        {
            private int <>1__state;
            private TService <>2__current;
            public ServiceLocatorImplBase <>4__this;
            public IEnumerator<object> <>7__wrap2;
            private int <>l__initialThreadId;
            public object <item>5__1;

            [DebuggerHidden]
            public <GetAllInstances>d__0(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            private void <>m__Finally3()
            {
                this.<>1__state = -1;
                if (this.<>7__wrap2 != null)
                {
                    this.<>7__wrap2.Dispose();
                }
            }

            private bool MoveNext()
            {
                bool flag;
                try
                {
                    switch (this.<>1__state)
                    {
                        case 0:
                            this.<>1__state = -1;
                            this.<>7__wrap2 = this.<>4__this.GetAllInstances(typeof(TService)).GetEnumerator();
                            this.<>1__state = 1;
                            goto Label_007F;

                        case 2:
                            this.<>1__state = 1;
                            goto Label_007F;

                        default:
                            goto Label_0092;
                    }
                Label_004B:
                    this.<item>5__1 = this.<>7__wrap2.Current;
                    this.<>2__current = (TService) this.<item>5__1;
                    this.<>1__state = 2;
                    return true;
                Label_007F:
                    if (this.<>7__wrap2.MoveNext())
                    {
                        goto Label_004B;
                    }
                    this.<>m__Finally3();
                Label_0092:
                    flag = false;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
                return flag;
            }

            [DebuggerHidden]
            IEnumerator<TService> IEnumerable<TService>.GetEnumerator()
            {
                if ((Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId) && (this.<>1__state == -2))
                {
                    this.<>1__state = 0;
                    return (ServiceLocatorImplBase.<GetAllInstances>d__0<TService>) this;
                }
                return new ServiceLocatorImplBase.<GetAllInstances>d__0<TService>(0) { <>4__this = this.<>4__this };
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.System.Collections.Generic.IEnumerable<TService>.GetEnumerator();
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose()
            {
                switch (this.<>1__state)
                {
                    case 1:
                    case 2:
                        try
                        {
                        }
                        finally
                        {
                            this.<>m__Finally3();
                        }
                        return;
                }
            }

            TService IEnumerator<TService>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }
        }
    }
}

