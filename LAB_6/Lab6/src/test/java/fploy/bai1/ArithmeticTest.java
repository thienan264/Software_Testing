package test.java.fploy.bai1;

import static org.junit.Assert.assertEquals;
import fploy.JUnitMessage;
import org.junit.Test;

public class ArithmeticTest {

    public String message = "Fpoly exception";
    JUnitMessage junitMessage = new JUnitMessage(message);

    @Test(expected = ArithmeticException.class)
    public void testJUnitMessage() {
        System.out.println("Fpoly JUnit Message exception is printing ");
        junitMessage.printMessage();
    }

    @Test
    public void testJUnitHiMessage() {
        message = "Hi!" + message;
        System.out.println("Fpoly JUnit Message is printing ");
        assertEquals(message, junitMessage.printHiMessage());
    }
}
