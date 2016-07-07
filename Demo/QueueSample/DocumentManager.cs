using System.Collections.Generic;

namespace Demo.QueueSample
{
    public class DocumentManager
    {
        private readonly Queue<Document> documentQueue = new Queue<Document>();

        public void AddDocument(Document doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public Document GetDocument()
        {
            Document doc;
            lock (this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }
    }
}
