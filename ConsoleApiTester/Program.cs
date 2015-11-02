using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.ConsoleApiTester {
    public class Program {
        static int Main(string[] args) {
            var commands = ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));

            if (args.Length == 0) {
                Console.Write("Command to execute: ");
                string subcommand = Console.ReadLine();
                args = new string[] { subcommand };
            }

            int result = ConsoleCommandDispatcher.DispatchCommand(
                commands: commands,
                arguments: args,
                consoleOut: Console.Out,
                skipExeInExpectedUsage: true
            );

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            return result;
        }
    }
}
