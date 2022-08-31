using EmployeeAJAXCrud.Data;
using EmployeeAJAXCrud.Models;

namespace EmployeeAJAXCrud.Functions
{
    public class PersonDA
    {
        private readonly ApplicationDbContext _db;
        public PersonDA(ApplicationDbContext db)
        {
            _db = db;

        }
        public List<Basic> GetAll()
        {
            return _db.basics.ToList();
        }
        public Basic GetOne(int id)
        {
            return _db.basics.FirstOrDefault(x => x.Id == id);
        }
        public string Remove(int id)
        {
            string Result = string.Empty;
            var query = _db.basics.FirstOrDefault(x => x.Id == id);
            if (query != null)
            {
                _db.basics.Remove(query);
                _db.SaveChanges();
                Result = "pass";
            }
            return Result;
        }
        public string Save(Basic obj)
        {
            string Result = string.Empty;
            var query = _db.basics.FirstOrDefault(x => x.Id == obj.Id);

            if (query != null)
            {
                query.Fullname = obj.Fullname;
                query.Position = obj.Position;

                _db.SaveChanges();
                Result = "pass";
            }
            else
            {
                Basic basic = new Basic
                {
                    Fullname = obj.Fullname,
                    Position = obj.Position
                };
                _db.basics.Add(basic);
                _db.SaveChanges();
                Result = "pass";
            }
            return Result;
        }
      


    }

}
