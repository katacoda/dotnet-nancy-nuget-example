namespace Nancy.Demo.Hosting.Docker
{
    using System;
    using Nancy.Hosting.Self;
    using Mono.Unix;
    using Mono.Unix.Native;

    class Program
    {
        static void Main()
        {
            var port = 8080;

            var host = new NancyHost(new Uri("http://localhost:" + port));
            host.Start();

            Console.WriteLine("Nancy started. Listening on http://+:" + port);

            if (IsRunningOnMono())
            {
                var terminationSignals = GetUnixTerminationSignals();
                UnixSignal.WaitAny(terminationSignals);
            }
            else
            {
                Console.ReadLine();
            }

            Console.WriteLine("Stopping Nancy");
            host.Stop();
        }

        private static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        private static UnixSignal[] GetUnixTerminationSignals()
        {
            return new[]
            {
              new UnixSignal(Signum.SIGINT),
              new UnixSignal(Signum.SIGTERM),
              new UnixSignal(Signum.SIGQUIT),
              new UnixSignal(Signum.SIGHUP)
            };
        }
    }
}
