package fpoly.junit;

import java.sql.*;

public class CustomerDAO {

    public boolean existsCustomerCode(String code) throws SQLException {
        String sql = "SELECT 1 FROM Customers WHERE CustomerCode = ?";
        try (Connection c = Db.getConnection();
             PreparedStatement ps = c.prepareStatement(sql)) {
            ps.setString(1, code);
            try (ResultSet rs = ps.executeQuery()) {
                return rs.next();
            }
        }
    }

    public boolean existsEmail(String email) throws SQLException {
        String sql = "SELECT 1 FROM Customers WHERE Email = ?";
        try (Connection c = Db.getConnection();
             PreparedStatement ps = c.prepareStatement(sql)) {
            ps.setString(1, email);
            try (ResultSet rs = ps.executeQuery()) {
                return rs.next();
            }
        }
    }

    public void insert(String code, String name, String email, String phone, String address,
                       String passwordHash, Date dob, String gender) throws SQLException {
        String sql = """
            INSERT INTO Customers(CustomerCode, FullName, Email, Phone, Address, PasswordHash, Dob, Gender)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?)
        """;
        try (Connection c = Db.getConnection();
             PreparedStatement ps = c.prepareStatement(sql)) {
            ps.setString(1, code);
            ps.setString(2, name);
            ps.setString(3, email);
            ps.setString(4, phone);
            ps.setString(5, address);
            ps.setString(6, passwordHash);
            if (dob == null) ps.setNull(7, Types.DATE);
            else ps.setDate(7, dob);
            if (gender == null) ps.setNull(8, Types.NVARCHAR);
            else ps.setString(8, gender);
            ps.executeUpdate();
        }
    }
}
