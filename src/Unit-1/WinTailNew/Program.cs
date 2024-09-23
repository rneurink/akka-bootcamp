using System;
using System.Diagnostics;
using Akka.Actor;
using Akka.Actor.Setup;

namespace WinTailNew
{
    internal class Program
    {
        private static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            MyActorSystem = ActorSystem.Create(nameof(MyActorSystem));

            Props consoleWriterProps = Props.Create<ConsoleWriterActor>();
            IActorRef consoleWriterActor = MyActorSystem.ActorOf(consoleWriterProps, nameof(consoleWriterActor));
            
            Props validationActorProps = Props.Create<ValidationActor>(consoleWriterActor);
            IActorRef validationActor = MyActorSystem.ActorOf(validationActorProps, nameof(validationActor));

            Props consoleReaderProps = Props.Create<ConsoleReaderActor>(validationActor);
            IActorRef consoleReaderActor = MyActorSystem.ActorOf(consoleReaderProps, nameof(consoleReaderActor));

            // tell console reader to begin
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            MyActorSystem.WhenTerminated.Wait();
        }
    }
}
