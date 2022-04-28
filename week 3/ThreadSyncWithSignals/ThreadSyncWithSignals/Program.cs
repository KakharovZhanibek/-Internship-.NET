/*
 * Thread 1 started 
 * Thread 2 started 
 * Thread 3 is waiting for a manual signal from Thread 1 
 * Thread 4 is waiting for a manual signal from Thread 1 
 * Thread 5 is waiting for an auto signal from Thread 2 
 * Thread 6 is waiting for an auto signal from Thread 2 
 * Thread 2 set signal 
 * Thread 5 received an auto signal, continue working 
 * Thread 1 set signal 
 * Thread 3 received a manual signal, continue working 
 * Thread 4 received a manual signal, continue working 
 * Thread 1 reset signal 
 * Thread 2 set signal 
 * Thread 6 received an auto signal, continue working
 */
if (System.Diagnostics.Process.GetProcessesByName(
        System.IO.Path.GetFileNameWithoutExtension(
            System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) 
    System.Diagnostics.Process.GetCurrentProcess().Kill();

ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

Thread thread1 = new Thread(() => ManualSignal(_manualResetEvent)) { Name = "Thread 1" };
Thread thread2 = new Thread(() => AutoSignal(_autoResetEvent)) { Name = "Thread 2" };

Thread thread3 = new Thread(DoWorkAfterSignalFromFirstThread) { Name = "Thread 3" };
Thread thread4 = new Thread(DoWorkAfterSignalFromFirstThread) { Name = "Thread 4" };

Thread thread5 = new Thread(DoWorkAfterSignalFromSecondThread) { Name = "Thread 5" };
Thread thread6 = new Thread(DoWorkAfterSignalFromSecondThread) { Name = "Thread 6" };

thread1.Start();
Thread.Sleep(10);
thread2.Start();
Thread.Sleep(20);
Thread.Sleep(20);
thread3.Start();
Thread.Sleep(30);
thread4.Start();
Thread.Sleep(20);

thread5.Start();
Thread.Sleep(20);
thread6.Start();


void ManualSignal(ManualResetEvent manualResetEvent)
{
    Console.WriteLine(Thread.CurrentThread.Name + " started!");
    manualResetEvent.Reset();
    Thread.Sleep(1100);
    Console.WriteLine(Thread.CurrentThread.Name + " set signal!");
    manualResetEvent.Set();
    
    Thread.Sleep(200);
    manualResetEvent.Reset();
    Console.WriteLine(Thread.CurrentThread.Name + " reset signal!");

}
void AutoSignal(AutoResetEvent autoResetEvent)
{
    Console.WriteLine(Thread.CurrentThread.Name + " started!");
    autoResetEvent.Reset();
    Thread.Sleep(500);
    Console.WriteLine(Thread.CurrentThread.Name + " set signal!");
    autoResetEvent.Set();
}

void DoWorkAfterSignalFromFirstThread()
{
    Console.WriteLine(Thread.CurrentThread.Name + " is waiting for a manual signal from Thread 1.");
    _manualResetEvent.WaitOne();
    if (Thread.CurrentThread.Name == "Thread 4")
        Thread.Sleep(20);
    Console.WriteLine(Thread.CurrentThread.Name + " received a manual signal, continue working.");
}
void DoWorkAfterSignalFromSecondThread()
{

    Console.WriteLine(Thread.CurrentThread.Name + " is waiting for an auto signal from Thread 2.");
    _autoResetEvent.WaitOne();
    Thread.Sleep(500);
    Console.WriteLine(Thread.CurrentThread.Name + " received an auto signal, continue working.");
    _autoResetEvent.Set();
}