using Akka.Actor;
using Akka.Util.Internal;
using ChartAppNew.Actors;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartAppNew
{
    public partial class Main : Form
    {
        private IActorRef _chartActor;
        private IActorRef _coordinatorActor;
        private Dictionary<CounterType, IActorRef> _toggleActors = new();

        public Main()
        {
            InitializeComponent();
            this.Load += Main_Load;
            this.FormClosing += Main_FormClosing;
        }

        private void Main_Load(object? sender, System.EventArgs e)
        {
            _chartActor = Program.ChartActors.ActorOf(Props.Create(() =>
                    new ChartingActor(sysChart, pauseResumeBtn)), "charting");
            _chartActor.Tell(new ChartingActor.InitializeChart(null)); //no initial series

            _coordinatorActor = Program.ChartActors.ActorOf(Props.Create(() =>
                    new PerformanceCounterCoordinatorActor(_chartActor)), "counters");

            // CPU button toggle actor
            _toggleActors[CounterType.Cpu] = Program.ChartActors.ActorOf(
                Props.Create(() => new ButtonToggleActor(_coordinatorActor, cpuBtn,
                CounterType.Cpu, false))
                .WithDispatcher("akka.actor.synchronized-dispatcher"));

            // MEMORY button toggle actor
            _toggleActors[CounterType.Memory] = Program.ChartActors.ActorOf(
               Props.Create(() => new ButtonToggleActor(_coordinatorActor, memBtn,
                CounterType.Memory, false))
                .WithDispatcher("akka.actor.synchronized-dispatcher"));

            // DISK button toggle actor
            _toggleActors[CounterType.Disk] = Program.ChartActors.ActorOf(
               Props.Create(() => new ButtonToggleActor(_coordinatorActor, diskBtn,
               CounterType.Disk, false))
               .WithDispatcher("akka.actor.synchronized-dispatcher"));

            // Set the CPU toggle to ON so we start getting some data
            _toggleActors[CounterType.Cpu].Tell(new ButtonToggleActor.Toggle());
        }

        private void Main_FormClosing(object? sender, FormClosingEventArgs e)
        {
            //shut down the charting actor
            _chartActor.Tell(PoisonPill.Instance);

            //shut down the ActorSystem
            Program.ChartActors?.Terminate();
        }

        private void cpuBtn_Click(object sender, System.EventArgs e)
        {
            _toggleActors[CounterType.Cpu].Tell(new ButtonToggleActor.Toggle());
        }

        private void memBtn_Click(object sender, System.EventArgs e)
        {
            _toggleActors[CounterType.Memory].Tell(new ButtonToggleActor.Toggle());
        }

        private void diskBtn_Click(object sender, System.EventArgs e)
        {
            _toggleActors[CounterType.Disk].Tell(new ButtonToggleActor.Toggle());
        }

        private void pauseResumeBtn_Click(object sender, System.EventArgs e)
        {
            _chartActor.Tell(new ChartingActor.TogglePause());
        }
    }
}
