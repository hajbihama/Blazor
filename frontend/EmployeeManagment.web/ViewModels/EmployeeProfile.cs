﻿namespace EmployeeManagment.web.ViewModels
{
    using AutoMapper;

    using Models;

    namespace EmployeeManagement.Web.Models
    {
        public class EmployeeProfile : Profile
        {
            public EmployeeProfile()
            {
                CreateMap<Employee, EditEmployeeModel>()
                    .ForMember(dest => dest.ConfirmEmail,
                        opt => opt.MapFrom(src => src.Email));

                CreateMap<EditEmployeeModel, Employee>();
            }
        }
    }

}
