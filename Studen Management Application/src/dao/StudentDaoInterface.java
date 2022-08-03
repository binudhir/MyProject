package dao;

import model.Student;

public interface StudentDaoInterface {
    public boolean insertStudent(Student s);
    public boolean deleteStudednt(int roll);
    public boolean updateStudent(int roll, String update, int ch, Student s);
    public void showAllStudent();
    public boolean showStudentById(int roll); 
}
