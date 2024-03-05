// See https://aka.ms/new-console-template for more information

using System.IO;
using Spire.Pdf;

string rootDirectory = @"C:\Users\polarlights\Desktop\sample-pdf";

await IterateThroughFiles(rootDirectory);

static async Task IterateThroughFiles(string directoryPath)
{
    foreach(string filePath in Directory.GetFiles(directoryPath))
    {
        //Create a PdfDocument instance
        PdfDocument doc = new PdfDocument();

        //Load a PDF document
        doc.LoadFromFile(filePath);

        //string currentFolderName = Path.GetFileName(Path.GetDirectoryName(filePath));
        //var fileName = Path.GetFileName(filePath);
        var fileNameWithoutExtention = Path.GetFileNameWithoutExtension(filePath);

        //Console.WriteLine("Current Folder Name: " + currentFolderName);
        Console.WriteLine("File Name: " + fileNameWithoutExtention);

        //Set built-in document properties
        doc.DocumentInformation.Title = fileNameWithoutExtention;

        //Save to file
        doc.SaveToFile(filePath);

    }

    //// Recursively process files in subdirectories
    //foreach(string subdirectory in Directory.GetDirectories(directoryPath))
    //{
    //    Console.WriteLine("\nSubdirectory Path: " + subdirectory);
    //    Console.WriteLine("Subdirectory Name: " + Path.GetFileName(subdirectory));

    //    Console.WriteLine("Parent Folder Path: " + Path.GetDirectoryName(subdirectory));
    //    Console.WriteLine("Parent Folder Name: " + Path.GetFileName(Path.GetDirectoryName(subdirectory)));

    //    IterateThroughFiles(subdirectory);
    //}
}

//// Recursive Sample Function
//int test = 3;

//printFunc(test);
//static void printFunc(int test)
//{
//    Console.WriteLine("\nThe number analyzing - " + test);
//    if(test < 1)
//    {
//        Console.WriteLine("\nNumber less then 1 - " + test);
//        return;
//    }
//    else
//    {
//        Console.Write(test + " - Before Print Function ");

//        printFunc(test - 1);

//        Console.WriteLine(test + " - After Print Function ");
//        return;
//    }
//}