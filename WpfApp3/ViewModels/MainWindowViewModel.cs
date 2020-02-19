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
        public List<ServiceTypeModel> ServiceTypesSource { get; set; }


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
