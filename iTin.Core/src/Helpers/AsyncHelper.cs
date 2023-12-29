
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iTin.Core.Helpers;

/// <summary>
/// A helper class providing methods for running asynchronous tasks synchronously on the current thread.
/// </summary>
public static class AsyncHelper
{
    /// <summary>
    /// Runs an asynchronous task synchronously on the current thread.
    /// </summary>
    /// <param name="task">The asynchronous task to run synchronously.</param>
    /// <remarks>
    /// This method is intended for scenarios where synchronous execution of an asynchronous task is necessary,
    /// such as in console applications, entry points, or Main methods.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input task is <see langword="null"/>.</exception>
    /// <exception cref="Exception">Thrown if the asynchronous task encounters an exception during execution.</exception>
    public static void RunSync(Func<Task> task)
    {
        var oldContext = SynchronizationContext.Current;
        var synch = new ExclusiveSynchronizationContext();
        SynchronizationContext.SetSynchronizationContext(synch);
        synch.Post(async _ =>
        {
            try
            {
                await task();
            }
            catch (Exception e)
            {
                synch.InnerException = e;
                throw;
            }
            finally
            {
                synch.EndMessageLoop();
            }
        }, null);
        synch.BeginMessageLoop();

        SynchronizationContext.SetSynchronizationContext(oldContext);
    }

    /// <summary>
    /// Runs an asynchronous task synchronously on the current thread and returns the result.
    /// </summary>
    /// <typeparam name="T">The type of the result returned by the asynchronous task.</typeparam>
    /// <param name="task">The asynchronous task to run synchronously.</param>
    /// <returns>
    /// The result of the asynchronous task.
    /// </returns>
    /// <remarks>
    /// This method is intended for scenarios where synchronous execution of an asynchronous task is necessary,
    /// such as in console applications, entry points, or Main methods.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the input task is <see langword="null"/>.</exception>
    /// <exception cref="Exception">Thrown if the asynchronous task encounters an exception during execution.</exception>
    public static T RunSync<T>(Func<Task<T>> task)
    {
        var oldContext = SynchronizationContext.Current;
        var synch = new ExclusiveSynchronizationContext();
        SynchronizationContext.SetSynchronizationContext(synch);
        T ret = default;
        synch.Post(async _ =>
        {
            try
            {
                ret = await task();
            }
            catch (Exception e)
            {
                synch.InnerException = e;
                throw;
            }
            finally
            {
                synch.EndMessageLoop();
            }
        }, null);

        synch.BeginMessageLoop();
        SynchronizationContext.SetSynchronizationContext(oldContext);
        return ret;
    }


    private sealed class ExclusiveSynchronizationContext : SynchronizationContext
    {
        private bool done;
        public Exception InnerException { get; set; }
        readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);

        readonly Queue<Tuple<SendOrPostCallback, object>> items = new Queue<Tuple<SendOrPostCallback, object>>();

        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException("We cannot send to our same thread");
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            lock (items)
            {
                items.Enqueue(Tuple.Create(d, state));
            }

            workItemsWaiting.Set();
        }

        public void EndMessageLoop()
        {
            Post(_ => done = true, null);
        }

        public void BeginMessageLoop()
        {
            while (!done)
            {
                Tuple<SendOrPostCallback, object> task = null;
                lock (items)
                {
                    if (items.Count > 0)
                    {
                        task = items.Dequeue();
                    }
                }

                if (task != null)
                {
                    task.Item1(task.Item2);
                    if (InnerException != null) // the method threw an exeption
                    {
                        throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
                    }
                }
                else
                {
                    workItemsWaiting.WaitOne();
                }
            }
        }

        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
    }
}
