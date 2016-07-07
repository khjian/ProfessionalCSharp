using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.QueueSample
{
    public class ProcessDocuments
    {
        public ProcessDocuments(DocumentManager dm)
        {
            if(dm == null)
                throw new ArgumentNullException("dm");
            documentManager = dm;
        }

        public static void Start(DocumentManager dm)
        {
            Task.Factory.StartNew(new ProcessDocuments(dm).Run);
        }

        private DocumentManager documentManager;
        private void Run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvailable)
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine($"Processing ducument {doc.Title}");
                }
                Thread.Sleep(new Random().Next(20));
            }
        }
    }
}
