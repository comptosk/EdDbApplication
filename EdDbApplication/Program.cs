using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EdDbLib;


namespace EdDbApplication {
   public class Program {
        static void Main() {
            TestConnection();
        }
        static void TestConnection() {
            var connection = new Connection("localhost", "sqlexpress", "EdDb");
            var studentsCtrl = new StudentsController(connection);
            

            var newStudent = new Student() {
                Firstname = "Frederick",
                Lastname = "Flintstone",
                StateCode = "SA",
                SAT = 1000,
                GPA = 2.5M,
                MajorId = null
            };

            //var itWorked = studentsCtrl.Insert(newStudent);

            var fred = new Student(61) {
                Firstname = "Fred",
                Lastname = "Flintstone",
                StateCode = "SA",
                SAT = 1000,
                GPA = 2.5M,
                MajorId = null
            };
            var itWorked = studentsCtrl.Update(fred);
            itWorked = studentsCtrl.Delete(61);


            var student = studentsCtrl.GetByPK(10);
                var noStudent = studentsCtrl.GetByPK(-1);
                var students = studentsCtrl.GetAll();
            
            
           
            connection.Close();
        }
        static void Test1() {

            var conn = @"server=localhost\sqlexpress;database=EdDb;trusted_connection=true;";
            var sqlConn = new SqlConnection(conn);
            sqlConn.Open();
            if(sqlConn.State != ConnectionState.Open) { 
                throw new Exception("Connection Failed!");
            }
            
            sqlConn.Close();
        }
    }
}
