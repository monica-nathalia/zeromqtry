namespace Sub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    
    using System.Threading;
    using CommandLine;
    using ZeroMQ;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var options = new Options();
                var parser = new CommandLineParser(new CommandLineParserSettings(Console.Error));
                if (!parser.ParseArguments(args, options))
                    Environment.Exit(1);

                using(var ctx = ZmqContext.Create())
                {
                    using (var socket = ctx.CreateSocket(SocketType.SUB))
                    {
                        if (options.subscriptionPrefixes.Count() == 0)
                        { 
                            socket.SubscribeAll();
                            Console.WriteLine("Subscribing...");
                        }
                        else
                            foreach (var subscriptionPrefix in options.subscriptionPrefixes)
                                socket.Subscribe(Encoding.UTF8.GetBytes(subscriptionPrefix));

                        foreach (var endPoint in options.connectEndPoints)
                        {   
                            socket.Connect(endPoint);
                            Console.WriteLine("Connected");
                        }

                        while (true)
                        {
                            Thread.Sleep(options.delay);
                            Console.WriteLine("Test");
                            var msg = socket.Receive(Encoding.UTF8);

                            Console.WriteLine("Received: " + msg);
                            RootObject ourlisting = JsonConvert.DeserializeObject<RootObject>(msg);
                            Console.WriteLine("FIT101 (PLC): " + ourlisting.FIT101.PLC);
                            Console.WriteLine("FIT101 (IC): " + ourlisting.FIT101.IC);
                            Console.WriteLine("FIT101 (State): " + ourlisting.FIT101.State);
                            Console.WriteLine("Final State: " + ourlisting.PlantState);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }

    public class FIT101
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class LIT101
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class MV101
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P101
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P102
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT201
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT202
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT203
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT201
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class MV201
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P201
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P202
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P203
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P204
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P205
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P206
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class DPIT301
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT301
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class LIT301
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class MV301
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class MV302
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class MV303
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class MV304
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P301
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P302
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT401
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT402
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT401
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class LIT401
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P401
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P402
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P403
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P404
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class UV401
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT501
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT502
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT503
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class AIT504
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT501
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT502
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT503
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT504
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P501
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P502
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class PIT501
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class PIT502
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class PIT503
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class FIT601
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P601
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P602
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class P603
    {
        public string PLC { get; set; }
        public string IC { get; set; }
        public string State { get; set; }
    }

    public class RootObject
    {
        public FIT101 FIT101 { get; set; }
        public LIT101 LIT101 { get; set; }
        public MV101 MV101 { get; set; }
        public P101 P101 { get; set; }
        public P102 P102 { get; set; }
        public AIT201 AIT201 { get; set; }
        public AIT202 AIT202 { get; set; }
        public AIT203 AIT203 { get; set; }
        public FIT201 FIT201 { get; set; }
        public MV201 MV201 { get; set; }
        public P201 P201 { get; set; }
        public P202 P202 { get; set; }
        public P203 P203 { get; set; }
        public P204 P204 { get; set; }
        public P205 P205 { get; set; }
        public P206 P206 { get; set; }
        public DPIT301 DPIT301 { get; set; }
        public FIT301 FIT301 { get; set; }
        public LIT301 LIT301 { get; set; }
        public MV301 MV301 { get; set; }
        public MV302 MV302 { get; set; }
        public MV303 MV303 { get; set; }
        public MV304 MV304 { get; set; }
        public P301 P301 { get; set; }
        public P302 P302 { get; set; }
        public AIT401 AIT401 { get; set; }
        public AIT402 AIT402 { get; set; }
        public FIT401 FIT401 { get; set; }
        public LIT401 LIT401 { get; set; }
        public P401 P401 { get; set; }
        public P402 P402 { get; set; }
        public P403 P403 { get; set; }
        public P404 P404 { get; set; }
        public UV401 UV401 { get; set; }
        public AIT501 AIT501 { get; set; }
        public AIT502 AIT502 { get; set; }
        public AIT503 AIT503 { get; set; }
        public AIT504 AIT504 { get; set; }
        public FIT501 FIT501 { get; set; }
        public FIT502 FIT502 { get; set; }
        public FIT503 FIT503 { get; set; }
        public FIT504 FIT504 { get; set; }
        public P501 P501 { get; set; }
        public P502 P502 { get; set; }
        public PIT501 PIT501 { get; set; }
        public PIT502 PIT502 { get; set; }
        public PIT503 PIT503 { get; set; }
        public FIT601 FIT601 { get; set; }
        public P601 P601 { get; set; }
        public P602 P602 { get; set; }
        public P603 P603 { get; set; }
        public string PlantState { get; set; }
    }
}
