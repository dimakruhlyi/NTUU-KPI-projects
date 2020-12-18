package CPU;

import java.util.LinkedList;
import java.util.Queue;
import java.util.concurrent.ConcurrentLinkedQueue;

/**
 * Operates with processes: adds and removes from the queue
 */
public class CQueue {
    /**
     * the Queue object into which the processes are placed or removed from it
     */

    private Queue<Process> queue = new ConcurrentLinkedQueue<>();

    private int maxLength;

    /**
     * adds process to the queue
     *
     * @param process
     */
    public synchronized void addProcessToQueue(Process process) {
        queue.add(process);
        maxLength = (maxLength < getSize()) ? getSize() : maxLength;
    }

    /**
     * removes process from the queue
     */
    public synchronized Process removeProcessFromQueue() {
        Process rem = queue.remove();
        return rem;
    }

    public int getSize() {
        return queue.size();
    }

    @Override
    public String toString() {
        return queue.toString();
    }

    public int getMaxLength() {
        return maxLength;
    }
}
