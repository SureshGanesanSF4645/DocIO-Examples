﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.IO;


namespace Open_and_save_Word_document.Data
{
    public class WordService
    {
        public MemoryStream CreateWord()
        {
            using (FileStream sourceStreamPath = new FileStream(@"wwwroot/data/HelloWorld.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Opening a document.
                using (WordDocument document = new WordDocument(sourceStreamPath, FormatType.Automatic))
                {
                    //Appends text to the last paragraph of the document.
                    document.LastParagraph.AppendText("Hello World");

                    //Saves the Word document to MemoryStream.
                    MemoryStream stream = new MemoryStream();
                    document.Save(stream, FormatType.Docx);
                    stream.Position = 0;
                    return stream;
                }
            }
        }
    }
}