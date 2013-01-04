using System.Diagnostics;

namespace ScrumBoard.Tests.Persistence.Mappings
{
    using System.Configuration;
    using System.IO;

    public static class DeployDatabaseUtil
    {
        public static string DeployTestDatabase()
        {
            var solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var dbSchemaDir = solutionDir + @"\DatabaseSchema\bin\Debug\DatabaseSchema.dacpac";

            var procInfo = new ProcessStartInfo
            {
                Arguments = string.Format(ConfigurationManager.AppSettings["SQL_PUBLISH_COMMAND_ARGUMENTS"], dbSchemaDir),
                CreateNoWindow = true,
                ErrorDialog = false,
                FileName = ConfigurationManager.AppSettings["SQL_PUBLISH_COMMAND"],
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            var proc = new Process
            {
                StartInfo = procInfo
            };

            proc.Start();
            return proc.StandardOutput.ReadToEnd();
        }
    }
}
