using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiNepalData;
using WikiNepalData.Model;
using WikiNepalDataClassLibrary;

namespace NepalDataClass
{
    interface NepalDataInterface
    {
        IEnumerable<NepalDataModel> GetAllData();
        IEnumerable<NepalDataModel> Search(string searchString);


        void Update(NepalDataModel newData);
        void Delete(int id);
    }
    public class NepalData : NepalDataInterface
    {
        private readonly NepalDataContext _context;

        public NepalData(NepalDataContext context)
        {
            _context = context;
        }

        public void Update(NepalDataModel newData)
        {
            _context.Add(newData);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }


        public IEnumerable<NepalDataModel> Search(string searchString)
        {

            var Datas = from d in _context.Test select d;
            return Datas.Where(d => d.Title.Contains(searchString) || d.Paragraph.Contains(searchString));

        }

        public IEnumerable<NepalDataModel> GetAllData()
        {
            return _context.Test.ToList();
        }
    }
}
