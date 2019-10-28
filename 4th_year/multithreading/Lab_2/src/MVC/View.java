package MVC;

/**
 * View generates an output to the user.
 */
public class View {
    // Text's constants
    public static final String GENERATE_FLOW = "Generating flow, consisting of processes= ";
    public static final String PROCESS = " Process  has been added to the queue: ";
    public static final String TIME_BETWEEN_PROCESSES = "The next process will be generated  in= ";
    public static final String HANDLING_PROCESS=" Process has been handled in CPU for a period= ";
    public static final String CPU_NAME="CPU name is: ";
    public static final String WAITING_FOR_PROCESS=" is waiting until any process will be added to the queue";
    public static final String MAXIMUM_QUEUE_LENGTH=" Maximum queue length is: ";
    public static final String QUEUE1=" Queue1 ";
    public static final String QUEUE2=" Queue2 ";
    public static final String PROCESSED_REQUESTS=" The amount of processed requests is: ";
    public static final String TAKEN= " took from";
    /**
     * prints 1 String
     *
     * @param message
     */
    public void printMessage(String message) {
        System.out.println(message);
    }

    /**
     * prints 1-to many strings
     *
     * @param message
     */
    public void concatenationAndPrint(String... message) {
        StringBuilder concatString = new StringBuilder();
        for (String v : message) {
            concatString = concatString.append(v);
        }
        printMessage(new String(concatString));
    }

}
