package fpoly.junit;

import org.junit.Test;
import static org.junit.Assert.*;

public class PaymentCalculatorTest {

    // CHILD
    @Test
    public void childAge0() {
        assertEquals(50, PaymentCalculator.calculate(PaymentCalculator.Type.CHILD, 0));
    }

    @Test
    public void childAge17() {
        assertEquals(50, PaymentCalculator.calculate(PaymentCalculator.Type.CHILD, 17));
    }

    @Test(expected = IllegalArgumentException.class)
    public void childAge18Invalid() {
        PaymentCalculator.calculate(PaymentCalculator.Type.CHILD, 18);
    }

    // MALE boundaries
    @Test
    public void male18() {
        assertEquals(100, PaymentCalculator.calculate(PaymentCalculator.Type.MALE, 18));
    }

    @Test
    public void male35() {
        assertEquals(100, PaymentCalculator.calculate(PaymentCalculator.Type.MALE, 35));
    }

    @Test
    public void male36() {
        assertEquals(120, PaymentCalculator.calculate(PaymentCalculator.Type.MALE, 36));
    }

    @Test
    public void male50() {
        assertEquals(120, PaymentCalculator.calculate(PaymentCalculator.Type.MALE, 50));
    }

    @Test
    public void male51() {
        assertEquals(140, PaymentCalculator.calculate(PaymentCalculator.Type.MALE, 51));
    }

    // FEMALE boundaries
    @Test
    public void female18() {
        assertEquals(80, PaymentCalculator.calculate(PaymentCalculator.Type.FEMALE, 18));
    }

    @Test
    public void female35() {
        assertEquals(80, PaymentCalculator.calculate(PaymentCalculator.Type.FEMALE, 35));
    }

    @Test
    public void female36() {
        assertEquals(110, PaymentCalculator.calculate(PaymentCalculator.Type.FEMALE, 36));
    }

    @Test
    public void female50() {
        assertEquals(110, PaymentCalculator.calculate(PaymentCalculator.Type.FEMALE, 50));
    }

    @Test
    public void female51() {
        assertEquals(140, PaymentCalculator.calculate(PaymentCalculator.Type.FEMALE, 51));
    }

    // Invalid ages
    @Test(expected = IllegalArgumentException.class)
    public void negativeAgeInvalid() {
        PaymentCalculator.calculate(PaymentCalculator.Type.MALE, -1);
    }

    @Test(expected = IllegalArgumentException.class)
    public void tooHighAgeInvalid() {
        PaymentCalculator.calculate(PaymentCalculator.Type.FEMALE, 146);
    }

    @Test(expected = IllegalArgumentException.class)
    public void adultButAge17Invalid() {
        PaymentCalculator.calculate(PaymentCalculator.Type.MALE, 17);
    }
}
