package fpoly.junit;

import java.sql.Connection;
import java.sql.DriverManager;

public class TestDbConnect {
    public static void main(String[] args) throws Exception {
        String url = "jdbc:sqlserver://localhost:1433;databaseName=Lab5;encrypt=true;trustServerCertificate=true";
        Connection c = DriverManager.getConnection(url, "sa", "Password123!");
        System.out.println("A CONNECTED OK!");
        c.close();
    }
}
