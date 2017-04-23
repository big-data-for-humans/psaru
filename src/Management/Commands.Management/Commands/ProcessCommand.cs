using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSaru.Management
{
    [Cmdlet(VerbsLifecycle.Invoke, "Process", DefaultParameterSetName = "WithPositionalArgs")]
    [Alias("~", "ipr")]    
    public class ProcessCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("PSPath")]
        [ValidateNotNullOrEmpty()]
        public string FilePath { get; set; }

        [Parameter(Position = 1, ParameterSetName = "WithArgumentList")]
        [Alias("Args")]
        [ValidateNotNullOrEmpty()]
        public string[] ArgumentList { get; set; }

        [Parameter(Position = 1, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg1")]
        [ValidateNotNullOrEmpty()]
        public string Argument1 { get; set; }

        [Parameter(Position = 2, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg2")]
        [ValidateNotNullOrEmpty()]
        public string Argument2 { get; set; }

        [Parameter(Position = 3, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg3")]
        [ValidateNotNullOrEmpty()]
        public string Argument3 { get; set; }

        [Parameter(Position = 4, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg4")]
        [ValidateNotNullOrEmpty()]
        public string Argument4 { get; set; }

        [Parameter(Position = 5, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg5")]
        [ValidateNotNullOrEmpty()]
        public string Argument5 { get; set; }

        [Parameter(Position = 6, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg6")]
        [ValidateNotNullOrEmpty()]
        public string Argument6 { get; set; }

        [Parameter(Position = 7, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg7")]
        [ValidateNotNullOrEmpty()]
        public string Argument7 { get; set; }

        [Parameter(Position = 8, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg8")]
        [ValidateNotNullOrEmpty()]
        public string Argument8 { get; set; }

        [Parameter(Position = 9, ParameterSetName = "WithPositionalArgs")]
        [Alias("Arg9")]
        [ValidateNotNullOrEmpty()]
        public string Argument9 { get; set; }

        [Parameter()]
        [ValidateNotNullOrEmpty()]

        public string WorkingDirectory { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        private List<string> datas = new List<string>();        

        public void ProcessRecord(bool fake)
        {
            this.ProcessRecord();
        }

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "WithPositionalArgs")
            {
                ArgumentList = new string[] { Argument1, Argument2, Argument3, Argument4, Argument5, Argument6, Argument7, Argument8, Argument9 }.Where(a => a != null ).ToArray();
            }
            
            string argumentList = ArgumentList == null ? "" : string.Join(" ", ArgumentList);

            WriteVerbose(string.Format("running '{0}' with args '{1}'", FilePath, argumentList));

            var startInfo = new ProcessStartInfo(FilePath, argumentList)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = WorkingDirectory ?? SessionState.Path.CurrentLocation.Path
            };

            var process = new Process()
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true,
            };

            process.OutputDataReceived += Process_OutputDataReceived;
            process.Start();
            process.BeginOutputReadLine();

            while (!process.WaitForExit(100))
            {

                WriteObject(datas, true); //need a lock
                this.datas.Clear();
            }

            var errorData = process.StandardError.ReadToEnd();

            if (process.ExitCode != 0)
            {
                string errorDetails = string.Format("Process exited with non-zero exit code '{0}'. Details: {1}", process.ExitCode, errorData);
                WriteError(new ErrorRecord(new Exception(errorDetails), "InvokeProcessError", ErrorCategory.FromStdErr, this.FilePath));
            }
            else if (errorData.Length != 0)
            {
                string errorDetails = string.Format("Process exited with success but wrote to stderr. Details: {0}", process.ExitCode, errorData);
                WriteError(new ErrorRecord(new Exception(errorDetails), "InvokeProcessError", ErrorCategory.FromStdErr, this.FilePath));
            }

            process.Close();

            WriteObject(datas, true);
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                datas.Add(e.Data);
            }
            catch (Exception)
            {
                //TODO need to do something here
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

    }
}
