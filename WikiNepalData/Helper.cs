using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiNepalData;
using WikiNepalData.Model;

namespace WikiNepalDataClassLibrary
{
    public interface HelperInterface
    {
        IEnumerable<NepalDataModel> GetData();
    }

    public class Helper : HelperInterface
    {
        private readonly NepalDataContext _context;

        public Helper(NepalDataContext context)
        {
            _context = context;
        }

        public IEnumerable<NepalDataModel> GetData()
        {
            return _context.Test.ToList();
        }
    }
}
