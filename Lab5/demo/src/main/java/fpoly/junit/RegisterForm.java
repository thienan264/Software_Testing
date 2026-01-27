package fpoly.junit;

import javax.swing.*;
import java.awt.*;
import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.sql.Date;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.Period;
import java.time.format.DateTimeParseException;
import java.util.regex.Pattern;

public class RegisterForm extends JFrame {

    // 1) Mã KH: 6-10, chữ+số
    private static final Pattern CODE_PATTERN = Pattern.compile("^[a-zA-Z0-9]{6,10}$");
    // 3) Email hợp lệ (basic)
    private static final Pattern EMAIL_PATTERN = Pattern.compile("^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$");
    // 4) Phone: bắt đầu 0, 10-12 số
    private static final Pattern PHONE_PATTERN = Pattern.compile("^0\\d{9,11}$");
    // 2) Họ tên: 5-50, cho phép unicode + khoảng trắng (VN có dấu)
    private static final Pattern NAME_PATTERN = Pattern.compile("^[\\p{L} ]{5,50}$");

    private final JTextField txtCode = new JTextField(25);
    private final JTextField txtName = new JTextField(25);
    private final JTextField txtEmail = new JTextField(25);
    private final JTextField txtPhone = new JTextField(25);
    private final JTextArea txtAddress = new JTextArea(3, 25);
    private final JPasswordField txtPass = new JPasswordField(25);
    private final JPasswordField txtPass2 = new JPasswordField(25);
    private final JTextField txtDob = new JTextField(25); // yyyy-MM-dd

    private final JRadioButton rMale = new JRadioButton("Nam");
    private final JRadioButton rFemale = new JRadioButton("Nữ");
    private final JRadioButton rOther = new JRadioButton("Khác");

    private final JCheckBox chkTerms = new JCheckBox("Tôi đồng ý với các điều khoản dịch vụ *");

    private final JButton btnRegister = new JButton("Đăng ký");
    private final JButton btnReset = new JButton("Nhập lại");

    private final CustomerDAO dao = new CustomerDAO();

    public RegisterForm() {
        super("ĐĂNG KÝ TÀI KHOẢN KHÁCH HÀNG");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        // gender optional
        ButtonGroup g = new ButtonGroup();
        g.add(rMale); g.add(rFemale); g.add(rOther);

        txtAddress.setLineWrap(true);
        txtAddress.setWrapStyleWord(true);

        btnRegister.addActionListener(e -> onRegister());
        btnReset.addActionListener(e -> resetForm());

        JPanel root = new JPanel(new BorderLayout());
        root.setBorder(BorderFactory.createEmptyBorder(16, 16, 16, 16));

        JLabel title = new JLabel("ĐĂNG KÝ TÀI KHOẢN KHÁCH HÀNG", SwingConstants.CENTER);
        title.setFont(title.getFont().deriveFont(Font.BOLD, 18f));
        root.add(title, BorderLayout.NORTH);

        JPanel form = new JPanel(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();
        c.insets = new Insets(8, 8, 8, 8);
        c.fill = GridBagConstraints.HORIZONTAL;
        c.anchor = GridBagConstraints.WEST;

        int row = 0;

        row = addRow(form, c, row, "Mã Khách Hàng *", txtCode, "6-10 ký tự, chỉ chữ và số");
        row = addRow(form, c, row, "Họ và Tên *", txtName, "Nhập họ tên đầy đủ");
        row = addRow(form, c, row, "Email *", txtEmail, "ví dụ: nguyenvana@email.com");
        row = addRow(form, c, row, "Số điện thoại *", txtPhone, "Bắt đầu bằng số 0, 10-12 số");
        row = addRowArea(form, c, row, "Địa chỉ *", txtAddress, "Nhập địa chỉ chi tiết");
        row = addRow(form, c, row, "Mật khẩu *", txtPass, "Ít nhất 8 ký tự");
        row = addRow(form, c, row, "Xác nhận Mật khẩu *", txtPass2, "Nhập lại mật khẩu");
        row = addRow(form, c, row, "Ngày sinh", txtDob, "yyyy-MM-dd (không bắt buộc)");

        // Gender row
        c.gridx = 0; c.gridy = row;
        form.add(new JLabel("Giới tính"), c);
        c.gridx = 1;
        JPanel genderPanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 10, 0));
        genderPanel.add(rMale);
        genderPanel.add(rFemale);
        genderPanel.add(rOther);
        form.add(genderPanel, c);
        row++;

        // Terms row
        c.gridx = 1; c.gridy = row;
        form.add(chkTerms, c);
        row++;

        root.add(form, BorderLayout.CENTER);

        JPanel buttons = new JPanel(new FlowLayout(FlowLayout.CENTER, 16, 10));
        buttons.add(btnRegister);
        buttons.add(btnReset);
        root.add(buttons, BorderLayout.SOUTH);

        setContentPane(root);
        pack();
        setLocationRelativeTo(null);
    }

    private int addRow(JPanel form, GridBagConstraints c, int row, String label, JComponent input, String hint) {
        c.gridx = 0; c.gridy = row;
        form.add(new JLabel(label), c);
        c.gridx = 1;
        form.add(input, c);
        c.gridx = 2;
        JLabel h = new JLabel(hint);
        h.setForeground(Color.GRAY);
        form.add(h, c);
        return row + 1;
    }

    private int addRowArea(JPanel form, GridBagConstraints c, int row, String label, JTextArea area, String hint) {
        c.gridx = 0; c.gridy = row;
        form.add(new JLabel(label), c);
        c.gridx = 1;
        form.add(new JScrollPane(area), c);
        c.gridx = 2;
        JLabel h = new JLabel(hint);
        h.setForeground(Color.GRAY);
        form.add(h, c);
        return row + 1;
    }

    private void onRegister() {
        try {
            // Validate all fields
            String code = txtCode.getText().trim();
            String name = txtName.getText().trim();
            String email = txtEmail.getText().trim();
            String phone = txtPhone.getText().trim();
            String address = txtAddress.getText().trim();
            String pass = new String(txtPass.getPassword());
            String pass2 = new String(txtPass2.getPassword());
            String dobText = txtDob.getText().trim();

            // 1) Code
            if (code.isEmpty()) fail("Mã Khách Hàng là bắt buộc.");
            if (!CODE_PATTERN.matcher(code).matches()) fail("Mã Khách Hàng phải 6-10 ký tự và chỉ gồm chữ + số.");

            // 2) Name
            if (name.isEmpty()) fail("Họ và Tên là bắt buộc.");
            if (!NAME_PATTERN.matcher(name).matches()) fail("Họ và Tên phải 5-50 ký tự, chỉ chữ và khoảng trắng.");

            // 3) Email
            if (email.isEmpty()) fail("Email là bắt buộc.");
            if (!EMAIL_PATTERN.matcher(email).matches()) fail("Email không đúng định dạng.");

            // 4) Phone
            if (phone.isEmpty()) fail("Số điện thoại là bắt buộc.");
            if (!PHONE_PATTERN.matcher(phone).matches()) fail("Số điện thoại phải bắt đầu bằng 0 và dài 10-12 chữ số.");

            // 5) Address
            if (address.isEmpty()) fail("Địa chỉ là bắt buộc.");
            if (address.length() > 255) fail("Địa chỉ tối đa 255 ký tự.");

            // 6) Password
            if (pass.isEmpty()) fail("Mật khẩu là bắt buộc.");
            if (pass.length() < 8) fail("Mật khẩu tối thiểu 8 ký tự.");

            // 7) Confirm
            if (pass2.isEmpty()) fail("Xác nhận mật khẩu là bắt buộc.");
            if (!pass.equals(pass2)) fail("Xác nhận mật khẩu không khớp.");

            // 8) DOB optional >= 18
            Date dob = null;
            if (!dobText.isEmpty()) {
                try {
                    LocalDate d = LocalDate.parse(dobText); // yyyy-MM-dd
                    int years = Period.between(d, LocalDate.now()).getYears();
                    if (years < 18) fail("Người dùng phải đủ 18 tuổi.");
                    dob = Date.valueOf(d);
                } catch (DateTimeParseException ex) {
                    fail("Ngày sinh không đúng định dạng yyyy-MM-dd.");
                }
            }

            // 9) Gender optional
            String gender = null;
            if (rMale.isSelected()) gender = "Nam";
            else if (rFemale.isSelected()) gender = "Nữ";
            else if (rOther.isSelected()) gender = "Khác";

            // 10) Terms required
            if (!chkTerms.isSelected()) fail("Bạn phải đồng ý với điều khoản dịch vụ.");

            // DB unique checks
            if (dao.existsCustomerCode(code)) fail("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác!");
            if (dao.existsEmail(email)) fail("Email đã tồn tại. Vui lòng nhập email khác!");

            // Insert
            String hash = sha256(pass);
            dao.insert(code, name, email, phone, address, hash, dob, gender);

            JOptionPane.showMessageDialog(this, "Đăng ký tài khoản thành công!", "OK", JOptionPane.INFORMATION_MESSAGE);

        } catch (ValidationException ex) {
            JOptionPane.showMessageDialog(this, ex.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
        } catch (SQLException ex) {
            JOptionPane.showMessageDialog(this, "Lỗi CSDL: " + ex.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Lỗi: " + ex.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void resetForm() {
        txtCode.setText("");
        txtName.setText("");
        txtEmail.setText("");
        txtPhone.setText("");
        txtAddress.setText("");
        txtPass.setText("");
        txtPass2.setText("");
        txtDob.setText("");
        rMale.setSelected(false);
        rFemale.setSelected(false);
        rOther.setSelected(false);
        chkTerms.setSelected(false);
        txtCode.requestFocus();
    }

    private static String sha256(String input) throws Exception {
        MessageDigest md = MessageDigest.getInstance("SHA-256");
        byte[] bytes = md.digest(input.getBytes(StandardCharsets.UTF_8));
        StringBuilder sb = new StringBuilder();
        for (byte b : bytes) sb.append(String.format("%02x", b));
        return sb.toString();
    }

    private void fail(String msg) throws ValidationException {
        throw new ValidationException(msg);
    }

    static class ValidationException extends Exception {
        ValidationException(String msg) { super(msg); }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new RegisterForm().setVisible(true));
    }
}
