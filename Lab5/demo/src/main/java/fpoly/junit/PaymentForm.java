package fpoly.junit;

import javax.swing.*;
import java.awt.*;

public class PaymentForm extends JFrame {

    private final JRadioButton rMale = new JRadioButton("Male");
    private final JRadioButton rFemale = new JRadioButton("Female");
    private final JRadioButton rChild = new JRadioButton("Child (0 - 17 years)");

    private final JTextField txtAge = new JTextField(10);
    private final JTextField txtPayment = new JTextField(10);

    public PaymentForm() {
        super("Calculate the Payment for the Patient");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        // group radio
        ButtonGroup group = new ButtonGroup();
        group.add(rMale);
        group.add(rFemale);
        group.add(rChild);

        // default select
        rMale.setSelected(true);

        txtPayment.setEditable(false);

        JButton btnCalc = new JButton("Calculate");
        btnCalc.addActionListener(e -> calculate());

        JPanel top = new JPanel(new FlowLayout(FlowLayout.LEFT));
        top.add(rMale);
        top.add(rFemale);
        top.add(rChild);

        JPanel center = new JPanel(new GridBagLayout());
        GridBagConstraints g = new GridBagConstraints();
        g.insets = new Insets(6, 6, 6, 6);
        g.anchor = GridBagConstraints.WEST;

        g.gridx = 0; g.gridy = 0;
        center.add(new JLabel("Age (Years)"), g);
        g.gridx = 1;
        center.add(txtAge, g);
        g.gridx = 2;
        center.add(btnCalc, g);

        g.gridx = 0; g.gridy = 1;
        center.add(new JLabel("Payment is"), g);
        g.gridx = 1;
        center.add(txtPayment, g);
        g.gridx = 2;
        center.add(new JLabel("euro €"), g);

        setLayout(new BorderLayout());
        add(top, BorderLayout.NORTH);
        add(center, BorderLayout.CENTER);

        pack();
        setLocationRelativeTo(null);
    }

    private void calculate() {
        try {
            int age = Integer.parseInt(txtAge.getText().trim());

            PaymentCalculator.Type type =
                    rChild.isSelected() ? PaymentCalculator.Type.CHILD :
                    rFemale.isSelected() ? PaymentCalculator.Type.FEMALE :
                    PaymentCalculator.Type.MALE;

            int payment = PaymentCalculator.calculate(type, age);
            txtPayment.setText(String.valueOf(payment));
        } catch (NumberFormatException ex) {
            JOptionPane.showMessageDialog(this, "Age must be a number!", "Error", JOptionPane.ERROR_MESSAGE);
        } catch (IllegalArgumentException ex) {
            JOptionPane.showMessageDialog(this, ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new PaymentForm().setVisible(true));
    }
}
