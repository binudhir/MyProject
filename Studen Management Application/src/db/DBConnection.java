package db;

import java.sql.Connection;
import java.sql.DriverManager;

public class DBConnection {
    static Connection con;

    public static Connection createConnection(){
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            String user="root";
            String pass="shradha@123";
            String url="jdbc:mysql://localhost:3306/student?autoReconnect=true&useSSL=false";

            con=DriverManager.getConnection(url, user, pass);
        } catch (Exception e) {
            //TODO: handle exception
            e.printStackTrace();
            System.out.println(e);
        }

        return con;
    }
}
