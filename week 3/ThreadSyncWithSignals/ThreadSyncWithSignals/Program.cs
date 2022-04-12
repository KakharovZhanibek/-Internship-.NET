
ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
AutoResetEvent _autoResetEvent = new AutoResetEvent(false);


Thread thread1 = new Thread(() => WaitUntilIamDone(_manualResetEvent)) { Name = "Thread 1" };
Thread thread2 = new Thread(() => WaitUntilIamDone(_autoResetEvent)) { Name = "Thread 2" };

Thread thread3 = new Thread(DoWorkAfterSignalFromFirstThread) { Name = "Thread 3" };
Thread thread4 = new Thread(DoWorkAfterSignalFromFirstThread) { Name = "Thread 4" };

Thread thread5 = new Thread(DoWorkAfterSignalFromSecondThread) { Name = "Thread 5" };
Thread thread6 = new Thread(DoWorkAfterSignalFromSecondThread) { Name = "Thread 6" };

thread1.Start();
thread2.Start();

thread3.Start();
thread4.Start();
thread5.Start();
thread6.Start();

void WaitUntilIamDone(EventWaitHandle eventWaitHandle)
{
    Console.WriteLine(Thread.CurrentThread.Name + " started!");
    eventWaitHandle.Reset();
    Thread.Sleep(1000);
    Console.WriteLine(Thread.CurrentThread.Name + " set signal!");
    eventWaitHandle.Set();
}

void DoWorkAfterSignalFromFirstThread()
{
    Thread.Sleep(500);
    Console.WriteLine(Thread.CurrentThread.Name + " is waiting for a manual signal from Thread 1.");
    _manualResetEvent.WaitOne();
    Console.WriteLine(Thread.CurrentThread.Name + " received a manual signal, continue working.");
}

void DoWorkAfterSignalFromSecondThread()
{
    Thread.Sleep(500);
    Console.WriteLine(Thread.CurrentThread.Name + " is waiting for an auto signal from Thread 2.");
    _autoResetEvent.WaitOne();
    Console.WriteLine(Thread.CurrentThread.Name + " received an auto signal, continue working.");
    _autoResetEvent.Set();
}