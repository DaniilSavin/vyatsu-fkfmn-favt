


public class WorkingDirectory {
    private static WorkingDirectory instance;
    String directoryName;

    private WorkingDirectory(String directoryName) {
        this.directoryName = directoryName;
    }

    public static WorkingDirectory getInstance(String directoryName) {
        if (instance == null) {
            instance = new WorkingDirectory(directoryName);
        }
        return instance;
    }

    public static void main(String[] args) {
        System.out.println(instance.directoryName);
    }

}

