namespace Nancy.Demo.Hosting.Docker
{
    using Microsoft.Owin.Hosting;
    using System;
    using Mono.Unix;
    using Mono.Unix.Native;

    class Program
    {
        static void Main()
        {
            var port = 8080;

            using (WebApp.Start<Startup>(string.Format("http://+:{0}", port)))
            {
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
            }
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
