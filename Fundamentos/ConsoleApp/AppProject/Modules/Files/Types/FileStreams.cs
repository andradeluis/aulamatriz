﻿using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

namespace AppProject.Modules.Files.Types
{
    public class FileStreams : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        private string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private const string file = @"Modules\\Files\\Resources\\File1.txt";
        private string fileFullPath = string.Empty;
        private string streamDirectoryName = "StreamDirectory";
        private string streamDirectoryFullPath = string.Empty;
        private string temporalFilePath = @"C:\\inetpub\\wwwroot\\";
        //private string temporalFilePath = AppDomain.CurrentDomain.BaseDirectory;

        //Encodings:
        //UTF7
        //UTF8
        //UTF16
        //UTF32
        //ASCII 

        public FileStreams() : base(new ConsolePrinter())
        {

            _printer = new ConsolePrinter();
            fileFullPath = Path.Combine(appPath + file);
            streamDirectoryFullPath = Path.Combine(temporalFilePath, streamDirectoryName);
        }

        public void Init()
        {
            //CreateFolderAndGrantAccess();
            UpperCaseFileContent();
            UpperCaseFileLine();
            ReadSpecificEncoding();
            WriteSpecificEncoding();
            AppendText();
            AppendTextWithSpecificEncoding();
        }

        private void CreateFolderAndGrantAccess()
        {
            Directory.CreateDirectory(streamDirectoryFullPath);
            DirectoryInfo dInfo = new DirectoryInfo(streamDirectoryFullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }

        private void UpperCaseFileContent()
        {
            string originalText = File.ReadAllText(fileFullPath);
            string processedText = originalText.ToUpperInvariant();
            File.WriteAllText(streamDirectoryFullPath, processedText);
        }

        private void UpperCaseFileLine()
        {
            string[] lines = File.ReadAllLines(fileFullPath);
            lines[1] = lines[1].ToUpperInvariant();
            File.WriteAllLines(streamDirectoryFullPath, lines);
        }

        private void ReadSpecificEncoding()
        {
            string fileText = File.ReadAllText(fileFullPath, Encoding.UTF8);
            _printer.Print(fileText);

            string[] fileLines = File.ReadAllLines(fileFullPath, Encoding.UTF8);

            foreach (var line in fileLines)
            {
                _printer.Print(line);
            }
        }

        private void WriteSpecificEncoding()
        {
            string content = "This is my content";
            string[] lines = new string[]{ "This", "is", "my", "content" };

            var fullFile1Path = Path.Combine(streamDirectoryFullPath, "file1");
            File.WriteAllText(fullFile1Path, content, Encoding.UTF8);

            var fullFile2Path = Path.Combine(streamDirectoryFullPath, "file2");
            File.WriteAllLines(fullFile2Path, lines, Encoding.UTF8);
        }

        private void AppendText()
        {
            string contentToBeAdded = "This is my new content";
            string[] linesToBeAdded = new string[] { "This", "is", "my", "new", "content" };

            var fullFile1Path = Path.Combine(streamDirectoryFullPath, "file1");
            File.AppendAllText(fullFile1Path, contentToBeAdded);

            var fullFile2Path = Path.Combine(streamDirectoryFullPath, "file2");
            File.AppendAllLines(fullFile2Path, linesToBeAdded);
        }

        private void AppendTextWithSpecificEncoding()
        {
            string contentToBeAdded = "This is my new content";
            string[] linesToBeAdded = new string[] { "This", "is", "my", "new", "content" };

            var fullFile1Path = Path.Combine(streamDirectoryFullPath, "file1");
            File.AppendAllText(fullFile1Path, contentToBeAdded, Encoding.UTF8);

            var fullFile2Path = Path.Combine(streamDirectoryFullPath, "file2");
            File.AppendAllLines(fullFile2Path, linesToBeAdded, Encoding.UTF8);
        }

    }
}
