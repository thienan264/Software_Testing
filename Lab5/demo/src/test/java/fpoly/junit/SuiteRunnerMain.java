package fpoly.junit;

import org.junit.runner.JUnitCore;
import org.junit.runner.Result;

public class SuiteRunnerMain {
    public static void main(String[] args) {
        Result result = JUnitCore.runClasses(JunitTest.class);

        System.out.println("Runs: " + result.getRunCount());
        System.out.println("Errors: " + result.getFailureCount());
        System.out.println("Failures: " + result.getFailureCount());
        System.out.println("Success: " + result.wasSuccessful());
    }
}
