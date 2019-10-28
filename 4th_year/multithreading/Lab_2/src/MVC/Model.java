package MVC;

import CPU.CPU;
import CPU.ProcessFlow;

import java.util.LinkedList;
import java.util.List;

/**
 * Creates 2 processFlows, 3 CPUs and runs them
 * provides the statistics on queue length and cpu computational properties
 */
public class Model {
    /**
     * instantiates  ProcessFlow objects with the amount of randomly generated processes between values in brackets
     */
    ProcessFlow process1 = new ProcessFlow(20, 20);
    ProcessFlow process2 = new ProcessFlow(20, 20);
    /**
     * declares 3 CPU variables
     */
    CPU cpu1, cpu2, cpu3;

    /**
     * creates and runs 3 cpu and 2 process threads
     * above mentioned threads join the main thread
     */
    public void createServiceSystem() {
        cpu1 = createCPU("CPU1", process1);
        cpu2 = createCPU("CPU2", process2);
        cpu3 = createCPU("CPU3", process1, process2);
        Thread p1 = new Thread(process1);
        Thread p2 = new Thread(process2);
        Thread c1 = new Thread(cpu1);
        Thread c2 = new Thread(cpu2);
        Thread c3 = new Thread(cpu3);
        p1.start();
        p2.start();
        c1.start();
        c2.start();
        c3.start();
        try {
            p1.join();
            p2.join();
            c1.join();
            c2.join();
            c3.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    /**
     * returns the maximum amount of processes that were simultaneously in the queue
     *
     * @param processFlow
     * @return int value of processes
     */
    public int maximumQueuelength(ProcessFlow processFlow) {
        return processFlow.getQueue().getMaxLength();
    }

    /**
     * returns the amount of processes maintained by CPU
     *
     * @param cpu
     * @return int value of processes
     */
    public int getProcessedTasks(CPU cpu) {
        return cpu.getWorkedProcesses();
    }

    /**
     * creates CPU object
     *
     * @param CPU_name - String name of CPU
     * @param proc     array of processFlows
     * @return CPU object
     */
    public CPU createCPU(String CPU_name, ProcessFlow... proc) {
        List list = new LinkedList<>();
        list.add(proc[0]);
        if (proc.length == 2) {//if there are 2 ProcessFlows, second one is also considered in CPU constructor
            list.add(proc[1]);
        }
        CPU cpu = new CPU(CPU_name, list);
        return cpu;
    }


    /**
     * calculates share of the processes of the specific ProcessFlow to the overall amount of processes
     * maintained by given CPU
     *
     * @param processFlow
     * @param cpu
     * @return
     */
    public int calculateShare(ProcessFlow processFlow, CPU cpu) {
        return 100 * (processFlow.getProcessNumber() - cpu.getWorkedProcesses()) / processFlow.getProcessNumber();
    }


    public ProcessFlow getProcess2() {
        return process2;
    }

    public ProcessFlow getProcess1() {
        return process1;
    }

    public CPU getCpu1() {
        return cpu1;
    }

    public CPU getCpu2() {
        return cpu2;
    }

    public CPU getCpu3() {
        return cpu3;
    }
}
