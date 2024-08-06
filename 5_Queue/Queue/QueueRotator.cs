using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public static class QueueRotator
    {
        public static void Rotate<T>(int offset, IQueue<T> queue)
        {
            for (int i = 0; i < offset; i++)
                if (queue.Size() > 0)
                    queue.Enqueue(queue.Dequeue());
        }
    }
}

