namespace bt
{
    public class SimpleNode
    {
        public int Data { get; set; }
        public SimpleNode RigthNode { get; set; }
        public SimpleNode LeftNode { get; set; }
    }
}
/*
public class IntoHoldingStatusPoller : IIntoHoldingStatusPoller
    {
        private readonly IBookIncomingManager bookIncomingManager;
        private CancellationTokenSource cts;
        private bool isStarted;
        private IActionHandler pollingHandler = new IntoHoldingStatusPollingHandler();

        public static readonly object singletonLock = new object();
        public static IIntoHoldingStatusPoller Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (singletonLock)
                    {
                        if (instance == null)
                            instance = new IntoHoldingStatusPoller();
                    }
                }
                return instance;
            }
            set { instance = value; }
        }

        private static IIntoHoldingStatusPoller instance;

        public IntoHoldingStatusPoller()
        {
            bookIncomingManager = new BookIncomingManager();
        }
        
        public void Start()
        {
            if (isStarted)
                return;

            isStarted = true;

            if (cts == null)
                cts = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                int pollingInterval = ServiceSettings.Instance.GetIntValue("IntoHoldingStatusPoller.PollFrequencyInSeconds", 30);
                var serviceContext = ServiceContextManager.Instance.CurrentContext;
                while (!cts.Token.WaitHandle.WaitOne(new TimeSpan(TimeSpan.TicksPerSecond * pollingInterval)))
                {
                    try
                    {
                        pollingHandler.Handle(serviceContext.Guid,
                            serviceContext.HostName,
                            UpdateStatus,
                            pollingInterval);
                        
                    }
                    catch (Exception ex)
                    {
                        EventLogger.Instance.WriteExceptionToEventLog(ex);
                    }
                }
            }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public void Stop()
        {
            try
            {
                if (cts != null)
                {
                    cts.Cancel();
                    cts.Dispose();
                }
            }
            catch (Exception ex)
            {
                EventLogger.Instance.WriteExceptionToEventLog(ex, "IntoHoldingStatusPoller", "Error happened during IntoHoldingStatusPoller stop.");
            }
        }

        void UpdateStatus()
        {
            bookIncomingManager.CheckAndUpdateOrdersFundedStatus();
        }
    }
*/
