using System;
using System.Diagnostics;
using Akka.Actor;
using Akka.Actor.Setup;

namespace WinTailNew
{
    internal class Program
    {
        private static ActorSystem? MyActorSystem;

        static void Main(string[] args)
        {
            MyActorSystem = ActorSystem.Create(nameof(MyActorSystem));

            Props tailCoordinatorProps = Props.Create<TailCoordinatorActor>();
            IActorRef tailCoordinatorActor = MyActorSystem.ActorOf(tailCoordinatorProps, nameof(tailCoordinatorActor));

            Props consoleWriterProps = Props.Create<ConsoleWriterActor>();
            IActorRef consoleWriterActor = MyActorSystem.ActorOf(consoleWriterProps, nameof(consoleWriterActor));
            
            Props fileValidatorActorProps = Props.Create<FileValidatorActor>(consoleWriterActor);
            IActorRef fileValidatorActor = MyActorSystem.ActorOf(fileValidatorActorProps, nameof(fileValidatorActor));

            Props consoleReaderProps = Props.Create<ConsoleReaderActor>();
            IActorRef consoleReaderActor = MyActorSystem.ActorOf(consoleReaderProps, nameof(consoleReaderActor));

            // tell console reader to begin
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            MyActorSystem.WhenTerminated.Wait();
        }
    }
}
