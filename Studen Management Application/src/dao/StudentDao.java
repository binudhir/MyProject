package dao;

import java.sql.*;
import db.DBConnection;
import model.Student;

public class StudentDao implements StudentDaoInterface{

    @Override
    public boolean insertStudent(Student s) {
        // TODO Auto-generated method stub
        boolean flag=false;
        try {
            Connection con=DBConnection.createConnection();
            String qry="INSERT INTO student_details(std_name,clg_nm,city_nm,std_mark,std_per) value (?, ?, ?, ?, ?)";
            PreparedStatement pst=con.prepareStatement(qry);
            pst.setString(1,s.getName());
            pst.setString(2, s.getClgname());
            pst.setString(3, s.getCity());
            pst.setInt(4, s.getMark());
            pst.setDouble(5, s.getPercentage());
            pst.executeUpdate();
            flag=true;
        } catch (Exception e) {
            //TODO: handle exception
            e.printStackTrace();
        }
        return flag;
    }

    @Override
    public boolean deleteStudednt(int roll) {
        // TODO Auto-generated method stub
        boolean flag=false;
        try {
            Connection con=DBConnection.createConnection();
            String qry="DELETE FROM student_details WHERE roll_num="+roll;
            PreparedStatement pst=con.prepareStatement(qry);
            pst.executeUpdate();
            flag=true;
        } catch (Exception e) {
            //TODO: handle exception
            e.printStackTrace();
        }
        return flag;
    }

    @Override
    public boolean updateStudent(int roll, String update, int ch, Student s) {
        // TODO Auto-generated method stub
        int choice=ch;
        boolean flag=false;
        try {
            Connection con=DBConnection.createConnection();
            String qry;
        if(choice==1){            
            qry="UPDATE student_details set std_name=? WHERE roll_num=?";
            PreparedStatement ps=con.prepareStatement(qry);
            ps.setString(1, update);
            ps.setInt(2, roll);
            ps.executeUpdate();
            flag=true;            
        }
        else if(choice==2){
            qry="UPDATE student_details set clg_nm=? WHERE roll_num=?";
            PreparedStatement ps=con.prepareStatement(qry);
            ps.setString(1, update);
            ps.setInt(2, roll);
            ps.executeUpdate();
            flag=true;
        }
        else if(choice==3){
            qry="UPDATE student_details set city_nm=? WHERE roll_num=?";
            PreparedStatement ps=con.prepareStatement(qry);
            ps.setString(1, update);
            ps.setInt(2, roll);
            ps.executeUpdate();
            flag=true;
        }
        else if(choice==4){
            qry="UPDATE student_details set std_mark=? WHERE roll_num=?";
            PreparedStatement ps=con.prepareStatement(qry);
            ps.setString(1, update);
            ps.setInt(2, roll);
            ps.executeUpdate();
            flag=true;
        }
        else if(choice==5){
            qry="UPDATE student_details set std_per=? WHERE roll_num=?";
            PreparedStatement ps=con.prepareStatement(qry);
            ps.setString(1, update);
            ps.setInt(2, roll);
            ps.executeUpdate();
            flag=true;
        }
        


        } catch (Exception e) {
            //TODO: handle exception
            e.printStackTrace();
        }


        return flag;
    }

    @Override
    public void showAllStudent() {
        // TODO Auto-generated method stub
        try {
            Connection con=DBConnection.createConnection();
            String qry="SELECT * FROM student_details";
            Statement stmt=con.createStatement();
            ResultSet rs=stmt.executeQuery(qry);
            while(rs.next()){
                System.out.println("Roll No :" + rs.getInt(1) +"\n"+
                "Name :"+ rs.getString(2)+"\n"+
                "Clg :"+ rs.getString(3)+"\n"+
                "City :"+ rs.getString(4)+"\n"+
                "Mark :"+ rs.getInt(5)+"\n"+
                "Percentage :"+ rs.getDouble(6)+"%");
                System.out.println("----------------------------");
            }
        } catch (Exception e) {
            //TODO: handle exception
            e.printStackTrace();
        }
    }

    @Override
    public boolean showStudentById(int roll) {
        // TODO Auto-generated method stub
        try {
            Connection con=DBConnection.createConnection();
            String qry="SELECT * FROM student_details WHERE roll_num="+roll;
            Statement stmt=con.createStatement();
            ResultSet rs=stmt.executeQuery(qry);
            while(rs.next()){
                System.out.println("Roll No :" + rs.getInt(1) +"\n"+
                "Name :"+ rs.getString(2)+"\n"+
                "Clg :"+ rs.getString(3)+"\n"+
                "City :"+ rs.getString(4)+"\n"+
                "Mark :"+ rs.getInt(5)+"\n"+
                "Percentage :"+ rs.getDouble(6)+"%");                
            }
        } catch (Exception e) {
            //TODO: handle exception
            e.printStackTrace();
        }
        return false;
    }
    
}
