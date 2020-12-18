package CPU;

import MVC.View;

import java.util.Random;

/**
 * Simulates the  process flow, consisting of the randomly generated number of processes.
 */
public class ProcessFlow implements Runnable {
    /**
     * flag is true when all amount of processes has been generated, else false
     */
    private boolean flag;
    static View view = new View();
    /**
     * number of the processes  to be generated
     */
    private int processNumber;
    /**
     * Queue into which the processes of the flow  will be placed
     */
    private CQueue queue = new CQueue();

    /**
     * random number of processes is generated via constructor
     *
     * @param min
     * @param max
     */
    public ProcessFlow(int min, int max) {
        processNumber = generateRandomNumber(min, max);
    }

    /**
     * generates a random number of processes with random time interval between processes
     * between each generation of the process, generator sleeps for the duration of the time field of the process
     * all generated processes are added to the queue
     */
    @Override
    public void run() {
        view.printMessage(Thread.currentThread() + "\t" + View.GENERATE_FLOW + processNumber);
        int rand;
        Process process = null;
        for (int i = 0; i < processNumber; i++) {
            rand = generateRandomNumber(1, 10);
            process = new Process(rand, 2 * rand);
           // view.printMessage(Thread.currentThread() + "\t" + View.PROCESS + process);
            queue.addProcessToQueue(process);
            try {
           //     view.printMessage(Thread.currentThread() + "\t" + View.TIME_BETWEEN_PROCESSES + process.getTime() + "\n");
                Thread.sleep(process.getTime());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        flag = true;
        synchronized (this) {
            notifyAll();
        }
    }

    /**
     * generates the random value according to the upper and lower bounds
     *
     * @param min int bound
     * @param max int bound
     * @return int random value
     */

    public int generateRandomNumber(int min, int max) {
        return (int) (min + Math.random() * (max - min + 1));
    }

    public CQueue getQueue() {
        return queue;
    }

    public int getProcessNumber() {
        return processNumber;
    }

    public boolean isFlag() {
        return flag;
    }

    public void setFlag(boolean flag) {
        this.flag = flag;
    }
}
