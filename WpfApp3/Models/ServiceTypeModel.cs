using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    class ServiceTypeModel
    {
        public ServiceTypeModel()
        {
            ChildrenList = new List<ServiceTypeModel>();
        }
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; } = true;
        public List<ServiceTypeModel> ChildrenList { get; set; }
    }
}
