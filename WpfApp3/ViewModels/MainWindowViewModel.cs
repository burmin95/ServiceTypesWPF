using ServiceTypeService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Models;

namespace WpfApp3.ViewModels
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            _serviceTypesService = new ServiceTypeService.ServiceTypeService();
            ServiceTypesSource = _serviceTypesService.GetServiceTypesTree().Select(service => CreateServiceType(service)).ToList();
            
        }

        private readonly ServiceTypeService.ServiceTypeService _serviceTypesService;
        private List<ServiceTypeModel> servicetypessource;

        public List<ServiceTypeModel> ServiceTypesSource 
        {
            get { return servicetypessource; }
            set 
            {
                servicetypessource = value;


            }
        }

        public List<ServiceTypeModel> ServiceTypesDisplay { get; set; }
        
        private string searchstring;
        public string SearchString
        {
            get { return searchstring; }
            set
            {
                if (searchstring != null && searchstring == "")
                {
                    searchstring = value;
                    Search();
                }
            }
        }
        public void Search(ServiceTypeModel model)
        {
            if (model.Name == searchstring || model.Code == searchstring)
            {
                ServiceTypesSource.Clear();
                ServiceTypesSource.Add(model);
            }
            else
            {
                foreach (var child in model.ChildrenList)
                {
                    Search(child);
                }
            }
        }

        public static ServiceTypeModel CreateServiceType(ServiceTypeDto _serviceTypeDtos)
        {
            if (_serviceTypeDtos == null)
                return null;
            ServiceTypeModel result = new ServiceTypeModel { Id = _serviceTypeDtos.Id, Name = _serviceTypeDtos.Name, Code = _serviceTypeDtos.Code };

            foreach (var child in _serviceTypeDtos.ChildrenList)
            {
                result.ChildrenList.Add(CreateServiceType(child));
            }
            return result;
        }
    }
}
