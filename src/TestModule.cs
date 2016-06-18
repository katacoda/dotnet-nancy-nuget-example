namespace Nancy.Demo.Hosting.Docker
{
    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get("/", args => {
                System.Console.WriteLine("Visit: / on " + System.Environment.MachineName);
                return View["staticview", this.Request.Url];
            });

            Get("/machine", args => {
                System.Console.WriteLine("Visit: /machine on " + System.Environment.MachineName);
                return "Request processed by " + System.Environment.MachineName + "\r\n";
            });
        }
    }
}
