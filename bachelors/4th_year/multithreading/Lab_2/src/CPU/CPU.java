package CPU;

import MVC.View;

import java.util.List;


/**
 * CPU serves the processes from the ProcessFlow
 */
public class CPU implements Runnable {
    static View view = new View();
    /**
     * list of ProcessFlows that are maintained by the CPU
     */
    private List<ProcessFlow> flows;
    /**
     * time during which the processes are maintained by CPU
     */
    private int operationTime;
    /**
     * name of CPU
     */
    private String name;
    /**
     * number of maintained processes
     */
    private int workedProcesses;

    /**
     * @param name  of CPU
     * @param flows - list of ProcessFlows to be served by the CPU
     */
    public CPU(String name, List<ProcessFlow> flows) {
        this.name = name;
        this.flows = flows;
        operationTime = generateRandOperTime(1, 10);//generates initial random operation time of CPU
    }



    /**
     * generates random value
     *
     * @param min -lower bound of the random generator
     * @param max - upper bound of the random generator
     * @return
     */
    public int generateRandOperTime(int min, int max) {
        int number = (int) (min + Math.random() * (max - min + 1)) * 100;
        return number;
    }

    /**
     * defines whether CPU serves one ProcessFlow or several:
     * first and second CPUs maintain the first and second ProcessFlows correspondingly,
     * while the third one takes processes from the first queue. if it is empty it takes from the second
     */
    @Override
    public void run() {
        if (flows.size() == 1) {
            operateOneFlow();
        } else {
            operateTwoFlows();
        }
    }

    /**
     * method operates the processes of one ProcessFlow while flag of processFlow is set as false
     * or if queue size is not zero
     */
    public void operateOneFlow() {
        ProcessFlow processFlow = flows.get(0);
        CQueue cQueue = processFlow.getQueue();
        while (!processFlow.isFlag() || cQueue.getSize() != 0) {
            if (cQueue.getSize() == 0) {
                waiting();
            } else {
                operating(cQueue);
            }
        }
    }

    /**
     * Method operates the processes from 2 ProcessFlows. If first queue is empty, the processes are taken from second
     * queue. The operations are not finished until the flag of any ProcessFlow is set to false (there are no more processes
     * in the queue) or size of any queue !=0
     */
    public void operateTwoFlows() {
        ProcessFlow processFlow1 = flows.get(0);
        ProcessFlow processFlow2 = flows.get(1);
        CQueue cQueue1 = processFlow1.getQueue();
        CQueue cQueue2 = processFlow2.getQueue();
        while (!processFlow1.isFlag() || !processFlow2.isFlag() || cQueue1.getSize() != 0 || cQueue2.getSize() != 0) {
            if (cQueue1.getSize() != 0) {
                operating(cQueue1);
            } else if (cQueue2.getSize() != 0) {
                operating(cQueue2);
            } else {
                waiting();
            }
        }
    }

    /**
     * removes the process from the queue and increments the number of served processes
     * @param cQueue
     */
    public void operating(CQueue cQueue) {
        try {
            view.printMessage(getName() + "\t" + View.HANDLING_PROCESS + operationTime
                    + "\t" + cQueue.removeProcessFromQueue().toString());
            workedProcesses++;
            Thread.sleep(generateRandOperTime(1, 5));
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    /**
     * waits during 10 ms
     */
    public void waiting() {
        try {
            view.printMessage(getName() + View.WAITING_FOR_PROCESS);
            Thread.sleep(10);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        return "CPU{" +
                "name='" + name + '\'' +
                '}';
    }

    public List<ProcessFlow> getFlows() {
        return flows;
    }

    public void setFlows(List<ProcessFlow> flows) {
        this.flows = flows;
    }

    public int getWorkedProcesses() {
        return workedProcesses;
    }
}

