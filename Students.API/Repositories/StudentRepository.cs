using Dapper;
using Students.API.Models;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Students.API.Repositories
{
    public class StudentRepository
    {
        private readonly SqlConnection sqlConnection;
        private readonly DynamicParameters parameters = new DynamicParameters();
        private readonly CommandType cmd = CommandType.StoredProcedure;

        public StudentRepository(ConnectionStrings connection)
        {
            sqlConnection = new SqlConnection(connection.Value);
        }

        public async Task<AllStudent> GetAllStudents()
        {
            var sp = "SP_GetAllStudents";

            var list = new AllStudent
            {
                AllStudents = await sqlConnection.QueryAsync<Student>(sp, parameters, commandType: cmd)
            };

            return list;
        }

        public async Task<AllStudent> GetStudent(int Id)
        {
            var sp = "SP_GetStudent";
            parameters.Add("Id", Id);

            var list = new AllStudent
            {
                AllStudents = await sqlConnection.QueryAsync<Student>(sp, parameters, commandType: cmd)
            };

            return list;
        }

        public async Task<int> CreateUpdateStudent(Student student)
        {
            var sp = "SP_CreateUpdateStudent";
            parameters.AddDynamicParams(student);
            var result = await sqlConnection.ExecuteAsync(sp, parameters, commandType: cmd);

            return result;
        }

        public async Task<int> DeleteStudent(int Id)
        {
            var sp = "SP_DeleteStudent";
            parameters.Add("Id", Id);
            var result = await sqlConnection.ExecuteAsync(sp, parameters, commandType: cmd);

            return result;
        }
    }
}
